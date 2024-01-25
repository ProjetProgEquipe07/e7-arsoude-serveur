using arsoudeServeur.Models;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace arsoudeServeur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class RandonneeController : BaseController
    {
        private readonly RandonnéesService _randonnéeService;
        public RandonneeController(UtilisateursService utilisateursService, RandonnéesService randonnéeService) : base(utilisateursService)
        {
            _randonnéeService = randonnéeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Randonnée>>> GetRandonnees()
        {
            return await _randonnéeService.GetAllRandonneesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Randonnée>> GetRandonnee(int id)
        {
            var randonnee = await _randonnéeService.GetRandonneeByIdAsync(id);

            if (randonnee == null)
            {
                return NotFound();
            }

            return randonnee;
        }

        [HttpPost]
        public async Task<ActionResult<Randonnée>> CreateRandonnee(Randonnée randonnee)
        {
            var newRandonnee = await _randonnéeService.CreateRandonneeAsync(randonnee);
            return CreatedAtAction(nameof(GetRandonnee), new { id = newRandonnee.id }, newRandonnee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditRandonnee(int id, Randonnée randonnee)
        {
            var success = await _randonnéeService.UpdateRandonneeAsync(id, randonnee);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRandonnee(int id)
        {
            var success = await _randonnéeService.DeleteRandonneeAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
