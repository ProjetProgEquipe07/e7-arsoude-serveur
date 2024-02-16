using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Mvc;

namespace arsoudeServeur.Controllers
{
    public class PublicationController : BaseController
    {
        private PublicationService _PublicationService;
        public PublicationController(PublicationService publicationService,UtilisateursService utilisateursService) : base(utilisateursService)
        {
            _PublicationService = publicationService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publication>>> GetPublications()
        {
            Utilisateur user = UtilisateurCourant;

            var list = await _PublicationService.GetPublications(user);
            return list;
        }

        [HttpPost]
        public async Task<ActionResult<Publication>> CreatePublication([FromBody] PublicationDTO publication)
        {
            Utilisateur user = UtilisateurCourant;

            await _PublicationService.CreatePublication(publication, user);
            return Ok();
        }

        [HttpPost("{publiId}")]
        public async Task<ActionResult<Publication>> LikePublication(int publiId)
        {
            Utilisateur user = UtilisateurCourant;
            var publi = await _PublicationService.LikePublication(user, publiId);
            return publi;
        }

        [HttpGet("{UtilisateurId}")]
        public async Task<ActionResult<IEnumerable<Publication>>> GetUserPublications(int utilisateurId)
        {
          
            var list = await _PublicationService.GetPublicationsUser(utilisateurId);
            return Ok(list);
        }
    }
}
