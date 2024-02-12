using arsoudeServeur.Models;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Mvc;

namespace arsoudeServeur.Controllers
{
    public class CommentaireController : BaseController
    {
       

        private CommentaireService _commentaireService;

        public CommentaireController(CommentaireService commentaire, UtilisateursService utilisateursService) :base(utilisateursService) 
        { 
            _commentaireService = commentaire;
        }

        [HttpGet("{id}")]
        public Task<ActionResult<IEnumerable<Commentaire>>> GetCommentaire(int id)
        {
            return _commentaireService.GetCommentaire(id);
        }


        
    }
}
