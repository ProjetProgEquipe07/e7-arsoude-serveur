using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Services;
using arsoudServeur.Data;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace arsoudeServeur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PublicationController : BaseController
    {
        private ApplicationDbContext _context;
        private PublicationService _PublicationService;
        public PublicationController(PublicationService publicationService,UtilisateursService utilisateursService, ApplicationDbContext context) : base(utilisateursService)
        {
            _PublicationService = publicationService;
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicationDTOSend>>> GetPublications()
        {
            Utilisateur user = _context.utilisateurs.Where(u => u.id == 1).FirstOrDefault();

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
            //Utilisateur user = UtilisateurCourant;
            Utilisateur user = _context.utilisateurs.Where(u => u.id == 1).FirstOrDefault();
            var publi = await _PublicationService.LikePublication(user, publiId);
            return publi;
        }

        [HttpGet("{UtilisateurId}")]
        public async Task<ActionResult<IEnumerable<PublicationDTOSend>>> GetUserPublications(int utilisateurId)
        {
          
            var list = await _PublicationService.GetPublicationsUser(utilisateurId);
            return Ok(list);
        }
    }
}
