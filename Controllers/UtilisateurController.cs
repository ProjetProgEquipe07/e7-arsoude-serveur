using arsoudeServeur.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace arsoudeServeur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UtilisateurController : BaseController
    {
        public UtilisateurController(UtilisateursService utilisateursService) : base(utilisateursService)
        {
        }

    }
}
