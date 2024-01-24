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

        private Utilisateur? utilisateur = null;

        public Utilisateur UtilisateurCourant
        {
            get
            {
                if(utilisateur == null)
                {
                    //utilisateur = utilisateursService.GetUtilisateurFromUserId(UserId);
                }
                return utilisateur;
            }
        }

        public string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier)!; ;
            }
        }
    }
}
