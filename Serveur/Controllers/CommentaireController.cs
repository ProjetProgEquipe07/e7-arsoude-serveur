using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Mvc;

namespace arsoudeServeur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentaireController : BaseController
    {
        private CommentaireService _commentaireService;
        public CommentaireController(CommentaireService commentaire, UtilisateursService utilisateursService) :base(utilisateursService) 
        { 
            _commentaireService = commentaire;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Commentaire>> GetCommentaire(int id)
        {
           var list = _commentaireService.GetCommentaires(id);
           return list;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCommentaire([FromBody] CommentaireDTO commentaire)
        {
            Utilisateur user = UtilisateurCourant;

            _commentaireService.CreateCommentaire(commentaire, user);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> DeleteCommentaire(int id)
        {
            Utilisateur user = UtilisateurCourant;
            _commentaireService.DeleteCommentaire(id, user);
            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> EditCommentaire(int id, [FromBody] CommentaireDTO commentaire)
        {
            Utilisateur user = UtilisateurCourant;
             _commentaireService.PutCommentaire(id, commentaire, user);
            return Ok();
        }


        
    }
}
