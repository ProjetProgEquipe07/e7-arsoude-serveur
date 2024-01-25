﻿using arsoudeServeur.Models;
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
        private readonly RandonneesService _randonnéeService;
        public RandonneeController(UtilisateursService utilisateursService, RandonneesService randonnéeService) : base(utilisateursService)
        {
            _randonnéeService = randonnéeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Randonnee>>> GetRandonnees()
        {
            return await _randonnéeService.GetAllRandonneesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Randonnee>> GetRandonnee(int id)
        {
            var randonnee = await _randonnéeService.GetRandonneeByIdAsync(id);

            if (randonnee == null)
            {
                return NotFound();
            }

            return randonnee;
        }

        [HttpPost]
        public async Task<ActionResult<Randonnee>> CreateRandonnee(Randonnee randonnee)
        {
            var newRandonnee = await _randonnéeService.CreateRandonneeAsync(randonnee);
            return CreatedAtAction(nameof(GetRandonnee), new { id = newRandonnee.id }, newRandonnee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditRandonnee(int id, Randonnee randonnee)
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
