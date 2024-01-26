using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Security.Claims;
using System.Text;

namespace arsoudeServeur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthentificationController : BaseController
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ILogger<AuthentificationController> logger;

        public AuthentificationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AuthentificationController> logger,UtilisateursService utilisateursService) : base(utilisateursService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult<Utilisateur> GetUtilisateur()
        {
            return UtilisateurCourant;
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] RegisterDTO register)
        {
            if (register.motDePasse != register.confirmationMotDePasse)
            {
                return BadRequest(new { Error = "Le mot de passe et la confirmation ne sont pas identique" });
            }

            IdentityUser user = new IdentityUser()
            {
                UserName = register.courriel,
                Email = register.courriel
            };
            IdentityResult identityResult = await userManager.CreateAsync(user, register.motDePasse);

            if(identityResult.Succeeded)
            {
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                var confirmationLink = Url.Action("ConfirmEmail", "Account",
                    new { userId = user.Id, token = token }, Request.Scheme);
                logger.Log(LogLevel.Warning, confirmationLink);
                if(signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                {
                    return Ok();
                }
                
            }
            await utilisateursService.PostUtilisateurFromIdentityUserId(user.Id, register);
            if (!identityResult.Succeeded)
            {
                return BadRequest(identityResult);
            }


            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO login)
        {
            IdentityUser user = await userManager.FindByNameAsync(login.courriel);
            if (user != null && await userManager.CheckPasswordAsync(user, login.motDePasse))
            {
                IList<string> roles = await userManager.GetRolesAsync(user);

                List<Claim> authClaims = new List<Claim>();

                foreach (string role in roles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                authClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

                SymmetricSecurityKey authkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));

                JwtSecurityToken token = new JwtSecurityToken(
                    claims: authClaims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: new SigningCredentials(authkey, SecurityAlgorithms.HmacSha256)
                );


                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    validTo = token.ValidTo
                });
            }

            return BadRequest(new { Error = "L'utilisateur est introuvable ou le mot de passe de concorde pas" });
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if(userId == null || token == null)
            { return Ok(); }

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return BadRequest(new { Error = $"L'identifiant de l'utilisateur {userId} est invalide" });
            }
            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return Ok("Courriel confirmé");
            }
            return BadRequest(new { Error = "Le courriel ne peut pas être confirmé" });
        }


        /* [HttpPost]
         public async Task<ActionResult> Login(LoginDTO login)
         {
             var result = await signInManager.PasswordSignInAsync(login.pseudo, login.motDePasse, true, lockoutOnFailure: false);
             if (result.Succeeded)
             {
                 return Ok();
             }

             return NotFound(new { Error = "L'utilisateur est introuvable ou le mot de passe de concorde pas" });
         }*/

        /*[HttpGet]
        public async Task<ActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }*/
    }
}
