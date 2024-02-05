using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
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
        RandonneesService _randonneeService;

        public RechercheController(UtilisateursService utilisateursService, RechercheService rechercheService, RandonneesService randonneService) : base(utilisateursService)
        {
            _rechercheService = rechercheService;
            _randonneeService = randonneService;
        }



        [HttpGet("{recherche}/{value}")]
        public async Task<ActionResult<IEnumerable<RandonneeListDTO>>> GetNearSearch(string recherche, string value)
        {
            Utilisateur? user = UtilisateurCourant;
            try
            {
                var result = await _rechercheService.GetNearSearch(recherche, user.codePostal, value);
                var resultDTO = await _randonneeService.PutRandonneesFavorisAsync(result.ToList(), user);
                
                return Ok(resultDTO);
            } catch (NoLocationException)
            {
                return BadRequest("NO_LOCATION_ERROR");
            }
        }
    }
    
}
