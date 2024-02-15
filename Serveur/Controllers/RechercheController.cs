using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace arsoudeServeur.Controllers
{
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



        [HttpPost]
        public async Task<ActionResult<IEnumerable<RandonneeListDTO>>> GetNearSearch([FromBody] SearchDTO searchDTO)
        {

                IEnumerable<Randonnee> result;
                if (UtilisateurCourant != null)
                { 
                 result = await _rechercheService.GetNearSearchWithAuth(searchDTO.recherche, UtilisateurCourant, searchDTO.value, searchDTO.owned);
                }
                else
                {
                result = await _rechercheService.GetNearSearchNoAuth(searchDTO.recherche, searchDTO.value);

                }
                 var resultDTO = await _randonneeService.PutRandonneesFavorisAsync(result.ToList(), UtilisateurCourant);

            return Ok(resultDTO);

        }
    }
    
}
