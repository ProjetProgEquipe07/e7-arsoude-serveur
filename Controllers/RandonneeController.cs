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

        [HttpGet("{idMin}/{idMax}")]
        public async Task<ActionResult<IEnumerable<RandonneeListDTO>>> GetRandonnees(int idMin, int idMax)
        {
            return await _randonneeService.GetAllRandonneesAsync(idMin, idMax, UtilisateurCourant);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RandonneeDetailDTO>> GetRandonnee(int id)
        {
            var randonnee = await _randonneeService.GetRandonneeByIdAsync(id, UtilisateurCourant);

            if (randonnee == null)
            {
                return NotFound();
            }

            return randonnee;
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<RandonneeListDTO>>> GetRandonneesFavoris()
        {
            return await _randonneeService.GetRandonneesFavorisAsync(UtilisateurCourant);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Randonnee>> CreateRandonnee(RandonneeDTO randonneeDTO)
        {
            Utilisateur? user = UtilisateurCourant;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newRandonnee = await _randonneeService.CreateRandonneeAsync(randonneeDTO, user);
            return CreatedAtAction(nameof(GetRandonnee), new { id = newRandonnee.id }, newRandonnee);
        }

        [HttpPost("{id}")]
        //[Authorize]
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

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRandonnee(int id)
        {
            var success = await _randonneeService.DeleteRandonneeAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateRandonneeTrace(TraceRandoDTO randonnee)
        {
            await _randonneeService.CreateRandonneeTraceAsync(randonnee);

            return Ok();   

        }
    }
}
