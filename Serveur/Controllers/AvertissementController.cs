using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace arsoudeServeur.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize]
    [ApiController]
    public class AvertissementController : BaseController
    {
        private readonly AvertissementService _avertissementService;
        public AvertissementController(UtilisateursService utilisateursService, AvertissementService avertissementService) : base(utilisateursService)
        {
            _avertissementService = avertissementService;
        }

        [HttpPost]
        public async Task<ActionResult<Avertissement>> CreateAvertissement(AvertissementDTO avertissementdto)
        {

            var avertissement = await _avertissementService.CreateAvertissementAsync(avertissementdto);


            if (avertissement == null)
            {
                return NotFound();
            }

            return avertissement;
        }

        [HttpGet("{avertissementId}")]
        public async Task<IActionResult> AddTime(int avertissementId)
        {
            var success = await _avertissementService.AddTimeAvertissementAsync(avertissementId);

            if (!success)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("{avertissementId}")]
        public async Task<IActionResult> DeleteAvertissement(int avertissementId)
        {
            var success = await _avertissementService.DeleteAvertissementAsync(avertissementId);

            if (!success)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
