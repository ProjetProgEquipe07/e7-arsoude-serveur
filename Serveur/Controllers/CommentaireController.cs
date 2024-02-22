using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace arsoudeServeur.Controllers
{
    public static class ExceptionMessage
    {
        public const string NULL_COMMENTAIRE = "$CommentaireExistePas";
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

        //TODO: Enlever et mettre try catch précis dans chaques actions
        private async Task<ActionResult> TryCatch<T>(Func<Task<T>> func)
        {
            try
            {
                var result = await func();
                return Ok(result);
            }
            catch (NullCommentaireException)
            {
                return NotFound(ExceptionMessage.NULL_COMMENTAIRE);
            }
            catch (NullRandonneeException)
            {
                return NotFound("$RandonneeExistePas");
            }
            catch (NullUtilisateursException)
            {
                return NotFound("$UserExistePas");
            }
            catch (UnauthorizedDeleteCommentaireException)
            {
                return Unauthorized("$DeleteCommentaireInterdit");
            }
            catch (UnauthorizedModifyCommentaireException)
            {
                return Unauthorized("$ModifyCommentaireInterdit");
            }
            catch (AlreadyDeletedException)
            {
                return NotFound("$CommentaireDejaDelete");
            }
            catch (AlreadyExistsCommentaireExeption)
            {
                return BadRequest("$PublicationDejaComment");
            }
            catch (AlreadyLikedCommentaireException)
            {
                return Unauthorized("$CommentaireDejaLike");
            }
            catch (AlreadyUnlikedCommentaireException)
            {
                return Unauthorized("$CommentaireDejaUnlike");
            }
            catch (NoTraceFoundException)
            {
                return Unauthorized("$RandonnePasFaite");
            }
            catch (RandonneeNotPublicException)
            {
                return Unauthorized("$RandonnePrivee");
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
