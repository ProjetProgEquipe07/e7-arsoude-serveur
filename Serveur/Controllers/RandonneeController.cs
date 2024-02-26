using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace arsoudeServeur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class RandonneeController : BaseController
    {
        private readonly RandonneesService _randonneeService;
        public RandonneeController(UtilisateursService utilisateursService, RandonneesService randonneeService) : base(utilisateursService)
        {
            _randonneeService = randonneeService;
        }

        [HttpGet("{listSize}")]
        public async Task<ActionResult<IEnumerable<RandonneeListDTO>>> GetRandonnees(int listSize)
        {
            if (UtilisateurCourant !=null)
                return await _randonneeService.GetRandonneesAFaireAsync(listSize, UtilisateurCourant);
            else
                return await _randonneeService.GetRandonneesAFaireAsync(listSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RandonneeDetailDTO>> GetRandonnee(int id)
        {
            try
            {
                var randonnee = await _randonneeService.GetRandonneeByIdAsync(id, UtilisateurCourant);
                return randonnee;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("{listSize}")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<RandonneeListDTO>>> GetRandonneesFavoris(int listSize)
        {
            return await _randonneeService.GetRandonneesFavorisAsync(listSize, UtilisateurCourant);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<int>> GetRandonneesUtilisateur(int id)
        {
            try 
            { 
                int i = await _randonneeService.GetRandonneesUtilisateur(id, UtilisateurCourant);
                return Ok(i);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Randonnee>> CreateRandonnee(RandonneeDTO randonneeDTO)
        {
            try
            {
                var newRandonnee = await _randonneeService.CreateRandonneeAsync(randonneeDTO, UtilisateurCourant);
                return Ok(CreatedAtAction(nameof(GetRandonnee), new { newRandonnee.id }, newRandonnee));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost("{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> UpdateFavoris(int id)
        {
            var favoris = await _randonneeService.UpdateFavoritesAsync(id, UtilisateurCourant);

            if (favoris == null)
            {
                return NotFound();
            }

            return favoris;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditRandonnee(int id, Randonnee randonnee)
        {
            var success = await _randonneeService.UpdateRandonneeAsync(id, randonnee);

            if (!success)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRandonnee(int id)
        {
            var success = await _randonneeService.DeleteRandonneeAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return Ok();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateRandonneeTrace(TraceRandoDTO randonnee)
        {
            
            var rando = await _randonneeService.CreateRandonneeTraceAsync(randonnee, UtilisateurCourant);

            if (rando == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
