using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
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
        private readonly UtilisateursService _utilisateurService;
        public ProfilController(UtilisateursService utilisateursService) : base(utilisateursService)
        {
            _utilisateurService = utilisateursService;
        }

        [HttpGet]
        public async Task<ActionResult<ProfilDTO>> GetUtilisateurCourant()
        {
            var utilisateur = UtilisateurCourant;
            if (utilisateur == null)
            {
                return NotFound(new { Error = "L'utilisateur est introuvable" }); 
            }
            var userDTO = new ProfilDTO()
            {
                id = utilisateur.id,
                nom = utilisateur.nom,
                prenom = utilisateur.prenom,
                courriel = utilisateur.courriel,
                codePostal = utilisateur.codePostal,
                favoris = utilisateur.favoris,
                adresse = utilisateur.adresse,
                moisDeNaissance = utilisateur.moisDeNaissance,
                anneeDeNaissance = utilisateur.anneeDeNaissance,
            };
            return Ok(userDTO); 
        }

        [HttpPost]
        public async Task<ActionResult<Utilisateur>> Edit(EditProfilDTO profil)
        {
            if(UtilisateurCourant == null)
            {
                return Unauthorized(new { Error = "Le token reçu n'est pas valide" });
            }

            var utilisateur = UtilisateurCourant;
            if (utilisateur == null || utilisateur.id == 0)
            {
                return NotFound(new { Error = "L'utilisateur est introuvable" });
            }


            var user = await _utilisateurService.EditProfil(utilisateur, profil);

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<string>> EditPassword(EditPasswordDTO editPassword)
        {
            if (UtilisateurCourant == null)
            {
                return Unauthorized(new { Error = "Le token reçu n'est pas valide" });
            }

            var utilisateur = UtilisateurCourant;
            if (utilisateur == null || utilisateur.id == 0)
            {
                return NotFound(new { Error = "L'utilisateur est introuvable" });
            }

            var message = await _utilisateurService.EditPassword(utilisateur, editPassword.currentPassword, editPassword.newPassword);

            if (message == "Password change success")
            {
                return Ok(message);
            }
            else
            {
                return BadRequest(message);
            }
        }

    }
}
