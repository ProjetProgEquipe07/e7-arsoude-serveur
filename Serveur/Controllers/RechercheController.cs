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



        [HttpGet()]
        public async Task<ActionResult<IEnumerable<RandonneeListDTO>>> GetNearSearch([FromBody] SearchDTO searchDTO)
        {
            Utilisateur? user = UtilisateurCourant;
            if (user !=null)
            {

                 var result = await _rechercheService.GetNearSearch(searchDTO.recherche, user, searchDTO.value, searchDTO.owned);
                 var resultDTO = await _randonneeService.PutRandonneesFavorisAsync(result.ToList(), user);

                    return Ok(resultDTO);
                
            }
            else
            { 
                var result = await _rechercheService.GetNearSearch(searchDTO.recherche, searchDTO.value);
                var resultDTO = await _randonneeService.PutRandonneesFavorisAsync(result.ToList(), user);

                return Ok(resultDTO);
            }

        }
    }
    
}
