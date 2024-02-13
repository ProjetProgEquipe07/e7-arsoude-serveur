using arsoudeServeur.Models;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace arsoudeServeur.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        public UtilisateursService utilisateursService;
        public BaseController(UtilisateursService utilisateursService)
        {
            this.utilisateursService = utilisateursService;
        }

        protected Utilisateur? utilisateur = null;

        protected virtual Utilisateur UtilisateurCourant
        {
            get
            {
                if(utilisateur == null)
                {
                    utilisateur = utilisateursService.GetUtilisateurFromUserId(UserId);
                }
                return utilisateur;
            }
        }

        protected string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier)!; ;
            }
        }
    }
}
