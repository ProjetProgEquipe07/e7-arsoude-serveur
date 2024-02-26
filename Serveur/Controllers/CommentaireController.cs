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
        public const string CreateCommentaireInterdit = "CreateCommentaireInterdit"; //unauthorized
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

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Commentaire>>> GetCommentaires(int id)
        {
            try
            {
                var commentaires = await _commentaireService.GetCommentaires(id);
                return Ok(commentaires);
            }
            catch (NullRandonneeException)
            {
                return NotFound(ExceptionStrings.RandonneeExistePas);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCommentaire([FromBody] CommentaireDTO commentaireDTO)
        {
            try
            {
                var commentaire = await _commentaireService.CreateCommentaire(commentaireDTO, UtilisateurCourant);
                return Ok(commentaire);
            }
            catch (UnauthorizedCreateCommentaireException)
            {
                return Unauthorized(ExceptionStrings.CreateCommentaireInterdit);
            }
            //Les exceptions dessous sont dans PeutCommenter
            catch (NullRandonneeException)
            {
                return NotFound(ExceptionStrings.RandonneeExistePas);
            }
            catch (NoTraceFoundException)
            {
                return NotFound(ExceptionStrings.RandonnePasFaite);
            }
            catch (AlreadyExistsCommentaireExeption)
            {
                return Unauthorized(ExceptionStrings.PublicationDejaComment);
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

        [HttpPut("{id}")]
        public async Task<ActionResult> EditCommentaire(int id, [FromBody] CommentaireDTO commentaireDTO)
        {
            try
            {
                var commentaire = await _commentaireService.PutCommentaire(id, commentaireDTO, UtilisateurCourant);
                return Ok(commentaire);
            }
            catch (NullRandonneeException)
            {
                return NotFound(ExceptionStrings.RandonneeExistePas);
            }
            catch (NullCommentaireException)
            {
                return NotFound(ExceptionStrings.CommentaireExistePas);
            }
            catch (UnauthorizedModifyCommentaireException)
            {
                return NotFound(ExceptionStrings.ModifyCommentaireInterdit);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCommentaire(int id)
        {
            try
            {
                var commentaire = await _commentaireService.DeleteCommentaire(id, UtilisateurCourant);
                return Ok(commentaire);
            }
            catch (NullCommentaireException)
            {
                return NotFound(ExceptionStrings.CommentaireExistePas);
            }
            catch (AlreadyDeletedException)
            {
                return NotFound(ExceptionStrings.CommentaireDejaDelete);
            }
            catch (UnauthorizedDeleteCommentaireException)
            {
                return Unauthorized(ExceptionStrings.DeleteCommentaireInterdit);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{randonneeId}")]
        public async Task<ActionResult> UtilisateurPeutCommenter(int randonneeId)
        {
            try
            {
                var peutCommenter = await _commentaireService.PeutCommenter(randonneeId, UtilisateurCourant);
                return Ok(peutCommenter);
            }
            catch (NullRandonneeException)
            {
                return NotFound(ExceptionStrings.RandonneeExistePas);
            }
            catch (NoTraceFoundException)
            {
                return NotFound(ExceptionStrings.RandonnePasFaite);
            }
            catch (AlreadyExistsCommentaireExeption)
            {
                return Unauthorized(ExceptionStrings.PublicationDejaComment);
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
        [HttpGet("{commentaireId}")]
        public async Task<ActionResult> AjoutLikeCommentaire(int commentaireId)
        {
            try
            {
               var likes = await _commentaireService.AjoutLikeCommentaire(commentaireId, UtilisateurCourant);
                return Ok(likes);
            }
            catch (NullCommentaireException)
            {
                return NotFound(ExceptionStrings.CommentaireExistePas);
            }
            catch (AlreadyLikedCommentaireException)
            {
                return Unauthorized(ExceptionStrings.CommentaireDejaLike);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("{commentaireId}")]
        public async Task<ActionResult> EnleveLikeCommentaire(int commentaireId)
        {
            try
            {
               var likes = await _commentaireService.EnleveLikeCommentaire(commentaireId, UtilisateurCourant);
                return Ok(likes);
            }
            catch (NullCommentaireException)
            {
                return NotFound(ExceptionStrings.CommentaireExistePas);
            }
            catch (AlreadyUnlikedCommentaireException)
            {
                return Unauthorized(ExceptionStrings.CommentaireDejaUnlike);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
