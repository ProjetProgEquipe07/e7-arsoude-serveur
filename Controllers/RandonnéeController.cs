using arsoudeServeur.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace arsoudeServeur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RandonnéeController : BaseController
    {
        public RandonnéeController(UtilisateursService utilisateursService) : base(utilisateursService)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
