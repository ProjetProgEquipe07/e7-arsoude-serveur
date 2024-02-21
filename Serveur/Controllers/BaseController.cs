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

        public virtual Utilisateur UtilisateurCourant
        {
            get
            {
                if(UserId != "")
                { 
                    if(utilisateur == null)
                    {
                        utilisateur = utilisateursService.GetUtilisateurFromUserId(UserId);
                    }
                    return utilisateur;
                }
                else
                {
                    return null;
                }
            }
        }

        protected string UserId
        {
            get
            {
                try { 
                return User.FindFirstValue(ClaimTypes.NameIdentifier)!; ;
                }
                catch
                {
                    return "";
                }
            }
        }
    }
}
