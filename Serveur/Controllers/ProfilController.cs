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
        public async Task<ActionResult> Edit(EditProfilDTO profil)
        {
            var utilisateur = UtilisateurCourant;
            if (utilisateur == null)
            {
                return NotFound(new { Error = "L'utilisateur est introuvable" });
            }
            await _utilisateurService.EditProfil(utilisateur, profil);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> EditPassword(EditPasswordDTO editPassword)
        {
            var utilisateur = UtilisateurCourant;
            if (utilisateur == null)
            {
                return NotFound(new { Error = "L'utilisateur est introuvable" });
            }
            await _utilisateurService.EditPassword(utilisateur, editPassword.currentPassword, editPassword.newPassword);

            return Ok();
        }

    }
}
