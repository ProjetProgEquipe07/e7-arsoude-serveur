using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static arsoudeServeur.Services.UtilisateursService;

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
            var utilisateurCourant = UtilisateurCourant;
            if (utilisateurCourant == null || utilisateurCourant.id == 0)
            {
                return NotFound(new { Error = "NotFound" });
            }

            var utilisateurModifie = await _utilisateurService.EditProfil(utilisateurCourant, profil);

            return Ok(utilisateurModifie);
        }

        [HttpPost]
        public async Task<ActionResult> EditPassword(EditPasswordDTO editPassword)
        {
            var utilisateurCourant = UtilisateurCourant;
            if (utilisateurCourant == null || utilisateurCourant.id == 0)
            {
                return NotFound(new { Error = "NotFound" });
            }

            try
            {
                var result = await _utilisateurService.EditPassword(utilisateurCourant, editPassword.currentPassword, editPassword.newPassword);
                return Ok();
            }
            catch(BadPasswordException error)
            {
                return BadRequest(new { Error = error.Message });
            }
        }

    }
}
