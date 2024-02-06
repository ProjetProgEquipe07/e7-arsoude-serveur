using arsoudeServeur.Models;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace arsoudeServeur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProfilController : BaseController
    {
        public ProfilController(UtilisateursService utilisateursService) : base(utilisateursService)
        {

        }

        [HttpGet]
        public async Task<ActionResult<Utilisateur>> GetUtilisateurCourant()
        {
            var utilisateur = UtilisateurCourant;
            if (utilisateur == null)
            {
                return NotFound(new { Error = "L'utilisateur est introuvable" }); 
            }

            return Ok(utilisateur); 
        }

    }
}
