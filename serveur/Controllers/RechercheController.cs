using arsoudeServeur.Models;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace arsoudeServeur.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RechercheController : BaseController
    {
        RechercheService _rechercheService;

        public RechercheController(UtilisateursService utilisateursService, RechercheService rechercheService) : base(utilisateursService)
        {
            _rechercheService = rechercheService;
        }

        [HttpGet("{recherche}/{value}")]
        public async Task<ActionResult<IEnumerable<Randonnee>>> GetNearSearch(string recherche, string value)
        {
            Utilisateur? user = UtilisateurCourant;
            try
            {
                return await _rechercheService.GetNearSearch(recherche, user.codePostal, value);
            } catch (NoLocationException)
            {
                return BadRequest("NO_LOCATION_ERROR");
            }
        }
    }
    
}
