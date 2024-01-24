using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace arsoudeServeur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthentificationController : BaseController
    {
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;

        public AuthentificationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, UtilisateursService utilisateursService) : base(utilisateursService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public ActionResult<Utilisateur> GetUtilisateur()
        {
            return UtilisateurCourant;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            if (register.motDePasse != register.confirmationMotDePasse)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Le mot de passe et la confirmation ne sont pas identique" });
            }

            IdentityUser user = new IdentityUser()
            {
                UserName = register.courriel,
                Email = register.courriel
            };
            IdentityResult identityResult = await this.userManager.CreateAsync(user, register.motDePasse);

            if (!identityResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = identityResult.Errors });
            }

            await utilisateursService.PostUtilisateurFromIdentityUserId(user.Id);
            var result = await signInManager.PasswordSignInAsync(register.courriel, register.motDePasse, true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return Ok();
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO login)
        {
            var result = await signInManager.PasswordSignInAsync(login.courriel, login.motDePasse, true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return Ok();
            }

            return NotFound(new { Error = "L'utilisateur est introuvable ou le mot de passe de concorde pas" });
        }

        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }
    }
}
