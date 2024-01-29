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
        public async Task<ActionResult<IEnumerable<Randonnee>>> GetRandonnees(int idMin, int idMax)
        {
            return await _randonneeService.GetAllRandonneesAsync(idMin, idMax);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Randonnee>> GetRandonnee(int id)
        {
            var randonnee = await _randonneeService.GetRandonneeByIdAsync(id);

            if (randonnee == null)
            {
                return NotFound();
            }

            return randonnee;
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
    }
}
