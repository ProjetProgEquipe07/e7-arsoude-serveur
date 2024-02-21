using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace arsoudeServeur.Controllers
{
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
                return NotFound("Le commentaire n'existe pas");
            }
            catch (NullRandonneeException)
            {
                return NotFound("La randonnée n'existe pas");
            }
            catch (NullUtilisateursException)
            {
                return NotFound("L'utilisateur n'existe pas");
            }
            catch (UnauthorizedDeleteCommentaireException)
            {
                return Unauthorized("Vous n'avez pas le droit de supprimer ce commentaire");
            }
            catch (UnauthorizedModifyCommentaireException)
            {
                return Unauthorized("Vous n'avez pas le droit de modifier ce commentaire");
            }
            catch (AlreadyDeletedException)
            {
                return NotFound("Le commentaire a déjà été supprimé");
            }
            catch (AlreadyExistsCommentaireExeption)
            {
                return Unauthorized("Vous avez déjà commenté la publication");
            }
            catch (AlreadyLikedCommentaireException)
            {
                return Unauthorized("Vous avez déjà 'aimé' ce commentaire");
            }
            catch (AlreadyUnlikedCommentaireException)
            {
                return Unauthorized("Vous avez déjà enlevé votre 'j'aime' de ce commentaire");
            }
            catch (NoTraceFoundException)
            {
                return Unauthorized("Vous ne pouvez pas commenter tant que la randonnée n'a pas été faite");
            }
            catch (RandonneeNotPublicException)
            {
                return Unauthorized("Vous ne pouvez pas commenter une randonnée privée");
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
