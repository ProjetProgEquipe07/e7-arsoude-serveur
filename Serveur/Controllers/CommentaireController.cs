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

        //LikeCommentaire

        //UnlikeCommentaire

        [HttpGet("{id}")]
        public async Task<IEnumerable<Commentaire>> GetCommentaires(int id)
        {
            try
            {
                var list = await _commentaireService.GetCommentaires(id);
                return list;
            }
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCommentaire(int id)
        {
            try
            {
                await _commentaireService.DeleteCommentaire(id, UtilisateurCourant);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{randonneeId}")]
        public async Task<ActionResult> UtilisateurPeutCommenter(int randonneeId)
        {
            try
            {
                await _commentaireService.PeutCommenter(randonneeId, UtilisateurCourant);
                return Ok();
            }
            catch (NoTraceFoundException)
            {
                return NotFound("Aucun tracé fait dans la randonnée");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("{commentaireId}")]
        public async Task<ActionResult> AjoutLikeCommentaire(int commentaireId)
        {
            try
            {

                await _commentaireService.AjoutLikeCommentaire(commentaireId, UtilisateurCourant);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("{commentaireId}")]
        public async Task<ActionResult> EnleveLikeCommentaire(int commentaireId)
        {
            try
            {
                await _commentaireService.EnleveLikeCommentaire(commentaireId, UtilisateurCourant);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
