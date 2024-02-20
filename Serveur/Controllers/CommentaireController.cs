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
        public CommentaireController(CommentaireService commentaire, UtilisateursService utilisateursService) :base(utilisateursService) 
        { 
            _commentaireService = commentaire;
        }

        //LikeCommentaire

        //UnlikeCommentaire

        [HttpGet("{id}")]
        public async Task<IEnumerable<Commentaire>> GetCommentaire(int id)
        {
           var list = _commentaireService.GetCommentaires(id);
           return list;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCommentaire([FromBody] CommentaireDTO commentaire)
        {
            _commentaireService.CreateCommentaire(commentaire, UtilisateurCourant);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCommentaire(int id, [FromBody] CommentaireDTO commentaire)
        {
             _commentaireService.PutCommentaire(id, commentaire, UtilisateurCourant);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCommentaire(int id)
        {
            _commentaireService.DeleteCommentaire(id, UtilisateurCourant);
            return Ok();
        }

        [HttpGet("{randonneeId}")]
        public async Task<bool> UtilisateurPeutCommenter(int randonneeId)
        {
            return _commentaireService.PeutCommenter(randonneeId, UtilisateurCourant);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> AjouteLikeCommentaire(int id)
        {
            await _commentaireService.AjouteLikeCommentaire(id, UtilisateurCourant);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> EnleveLikeCommentaire(int id)
        {
            _commentaireService.EnleveLikeCommentaire(id, UtilisateurCourant);
            return Ok();
        }

    }
}
