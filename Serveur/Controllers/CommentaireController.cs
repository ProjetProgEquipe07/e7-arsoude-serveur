using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace arsoudeServeur.Controllers
{
    public static class ExceptionStrings
    {
        public const string CommentaireExistePas = "CommentaireExistePas"; //not found
        public const string RandonneeExistePas = "RandonneeExistePas"; //not found
        public const string UserExistePas = "UserExistePas"; //not found
        public const string DeleteCommentaireInterdit = "DeleteCommentaireInterdit"; //unauthorized
        public const string ModifyCommentaireInterdit = "ModifyCommentaireInterdit"; //unauthorized
        public const string CommentaireDejaDelete = "CommentaireDejaDelete"; //not found
        public const string PublicationDejaComment = "PublicationDejaComment"; //unauthorized
        public const string CommentaireDejaLike = "CommentaireDejaLike"; //unauthorized
        public const string CommentaireDejaUnlike = "CommentaireDejaUnlike"; //unauthorized
        public const string RandonnePasFaite = "RandonnePasFaite"; //unauthorized
        public const string RandonnePrivee = "RandonnePrivee"; //unauthorized
    }

    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CommentaireController : BaseController
    {
        private CommentaireService _commentaireService;
        public CommentaireController(CommentaireService commentaire, UtilisateursService utilisateursService) : base(utilisateursService)
        {
            _commentaireService = commentaire;
        }

        private async Task<ActionResult> TryCatch<T>(Func<Task<T>> func)
        {
            try
            {
                var result = await func();
                return Ok(result);
            }
            catch (NullCommentaireException)
            {
                return NotFound(ExceptionStrings.CommentaireExistePas);
            }
            catch (NullRandonneeException)
            {
                return NotFound(ExceptionStrings.RandonneeExistePas);
            }
            catch (NullUtilisateursException)
            {
                return NotFound(ExceptionStrings.UserExistePas);
            }
            catch (UnauthorizedDeleteCommentaireException)
            {
                return Unauthorized(ExceptionStrings.DeleteCommentaireInterdit);
            }
            catch (UnauthorizedModifyCommentaireException)
            {
                return Unauthorized(ExceptionStrings.ModifyCommentaireInterdit);
            }
            catch (AlreadyDeletedException)
            {
                return NotFound(ExceptionStrings.CommentaireDejaDelete);
            }
            catch (AlreadyExistsCommentaireExeption)
            {
                return Unauthorized(ExceptionStrings.PublicationDejaComment);
            }
            catch (AlreadyLikedCommentaireException)
            {
                return Unauthorized(ExceptionStrings.CommentaireDejaLike);
            }
            catch (AlreadyUnlikedCommentaireException)
            {
                return Unauthorized(ExceptionStrings.CommentaireDejaUnlike);
            }
            catch (NoTraceFoundException)
            {
                return Unauthorized(ExceptionStrings.RandonnePasFaite);
            }
            catch (RandonneeNotPublicException)
            {
                return Unauthorized(ExceptionStrings.RandonnePrivee);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Commentaire>>> GetCommentaires(int id)
        {
            return await TryCatch(async () =>
            {
                var commentaires = await _commentaireService.GetCommentaires(id);
                return commentaires;
            });
        }

        [HttpPost]
        public async Task<ActionResult> CreateCommentaire([FromBody] CommentaireDTO commentaireDTO)
        {
            return await TryCatch(async () =>
            {
                var commentaire = await _commentaireService.CreateCommentaire(commentaireDTO, UtilisateurCourant);
                return commentaire;
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditCommentaire(int id, [FromBody] CommentaireDTO commentaireDTO)
        {
            return await TryCatch(async () =>
            {
                var commentaire = await _commentaireService.PutCommentaire(id, commentaireDTO, UtilisateurCourant);
                return commentaire;
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCommentaire(int id)
        {
            return await TryCatch(async () =>
            {
                var commentaire = await _commentaireService.DeleteCommentaire(id, UtilisateurCourant);
                return commentaire;
            });
        }

        [HttpGet("{randonneeId}")]
        public async Task<ActionResult> UtilisateurPeutCommenter(int randonneeId)
        {
            return await TryCatch(async () =>
            {
                var peutCommenter = await _commentaireService.PeutCommenter(randonneeId, UtilisateurCourant);
                return peutCommenter;
            });
        }
        [HttpGet("{commentaireId}")]
        public async Task<ActionResult> AjoutLikeCommentaire(int commentaireId)
        {
            return await TryCatch(async () =>
            {
                await _commentaireService.AjoutLikeCommentaire(commentaireId, UtilisateurCourant);
                return "";
            });
        }
        [HttpGet("{commentaireId}")]
        public async Task<ActionResult> EnleveLikeCommentaire(int commentaireId)
        {
            return await TryCatch(async () =>
            {
                await _commentaireService.EnleveLikeCommentaire(commentaireId, UtilisateurCourant);
                return "";
            });
        }
    }
}
