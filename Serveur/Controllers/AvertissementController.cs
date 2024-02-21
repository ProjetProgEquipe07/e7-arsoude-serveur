using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static arsoudeServeur.Services.AvertissementService;

namespace arsoudeServeur.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
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
            try
            {
                var avertissement = await _avertissementService.CreateAvertissementAsync(avertissementdto);

                return Ok(avertissement);
            }
            catch (RandonneeNotFoundException) 
            {
                return NotFound(new { Error = "RandonneeNotFound" });
            }
            catch (GPSOutOfBoundsException)
            {
                return BadRequest(new { Error = "GpsOutOfBounds" });
            }
            catch (TypeAvertissementNotFoundException)
            {
                return BadRequest(new { Error = "TypeAvertissementNotFound" });
            }
            catch (DescriptionOutOfBoundsException)
            {
                return BadRequest(new { Error = "DescriptionOutOfBounds" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{avertissementId}")]
        public async Task<IActionResult> AddTime(int avertissementId)
        {
            try
            {
                var success = await _avertissementService.AddTimeAvertissementAsync(avertissementId);

                return Ok();
            }
            catch (AvertissementNotFoundException)
            {
                return NotFound(new { Error = "AvertissmentNotFound" });
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpGet("{avertissementId}")]
        public async Task<IActionResult> DeleteAvertissement(int avertissementId)
        {
            try
            {
                var success = await _avertissementService.DeleteAvertissementAsync(avertissementId);

                return Ok();
            }
            catch (AvertissementNotFoundException) 
            {
                return NotFound(new { Error = "AvertissmentNotFound" });
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }
    }
}
