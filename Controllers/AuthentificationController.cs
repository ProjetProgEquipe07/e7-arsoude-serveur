using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Services;
using arsoudeServeur.Services.Interfaces;
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
        private readonly IEmailService emailService;
        public AuthentificationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AuthentificationController> logger,UtilisateursService utilisateursService, IEmailService emailService) : base(utilisateursService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.emailService = emailService;
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
                var callbackUrl = Url.Action("ConfirmEmail", "Authentification", new { userId = user.Id, token }, protocol: HttpContext.Request.Scheme);
                await emailService.EnvoiEmailAsync(user.Email, "Confirmez votre adresse e-mail", $"Veuillez confirmer votre compte en <a href='{callbackUrl}'>cliquant sur ce petit lien</a>.");
                await userManager.AddToRoleAsync(user, "Randonneur");

                // Redirigez l'utilisateur vers une page informant que l'e-mail de confirmation a été envoyé
                await utilisateursService.PostUtilisateurFromIdentityUserId(user.Id, register);
                return Ok(new Message("Courriel de confirmation envoyé"));
            }
            else
            {
                return BadRequest(identityResult);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO login)
        {
            IdentityUser user = await userManager.FindByNameAsync(login.courriel);
            if (user != null)
            {
                if(!await userManager.IsEmailConfirmedAsync(user))
                {
                    return BadRequest(new { Error = "Vous devez confirmer votre adresse e-mail avant de pouvoir vous connecter." });
                }

                var result = await signInManager.PasswordSignInAsync(user, login.motDePasse, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    IList<string> roles = await userManager.GetRolesAsync(user);

                    List<Claim> authClaims = new List<Claim>();

                    foreach (string role in roles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    authClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

                    SymmetricSecurityKey authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));

                    JwtSecurityToken token = new JwtSecurityToken(
                        claims: authClaims,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256)
                    );


                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        validTo = token.ValidTo
                    });
                }

                if (result.RequiresTwoFactor)
                {
                    // L'utilisateur nécessite une authentification à deux facteurs
                    // Redirigez vers la page de code à deux facteurs si nécessaire
                    // return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                }

                if (result.IsLockedOut)
                {
                    // L'utilisateur est verrouillé
                    // Redirigez vers la page de verrouillage si nécessaire
                    // return RedirectToAction("Lockout");
                }
            }

            return BadRequest(new { Error = "L'utilisateur est introuvable ou le mot de passe ne correspond pas." });
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if(userId == null || token == null)
            { return BadRequest(new { Error = $"L'identifiant de l'utilisateur {userId} est invalide" }); }

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
    }

    public class Message
    {
        public Message(String text)
        {
            Text = text;
        }

        public String Text { get; set; } = "";
    }
}
