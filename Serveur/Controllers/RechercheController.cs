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
            var languageHeader = HttpContext.Request.Headers["Accept-Language"].ToString();

            if (UtilisateurCourant != null)
            { 
                
                result = await _rechercheService.GetNearSearch(searchDTO.recherche, UtilisateurCourant, searchDTO.value, searchDTO.owned, searchDTO.moyenne, languageHeader);
                var resultDTO = await _randonneeService.PutRandonneesFavorisAsync(result.ToList(), UtilisateurCourant);

            return Ok(resultDTO);

            }
            else
            { 
                result = await _rechercheService.GetNearSearch(searchDTO.recherche, searchDTO.value, searchDTO.moyenne, languageHeader);
                var resultDTO = await _randonneeService.PutRandonneesFavorisAsync(result.ToList(), null);
                return Ok(resultDTO);
            }
           

        }
    }
    
}
