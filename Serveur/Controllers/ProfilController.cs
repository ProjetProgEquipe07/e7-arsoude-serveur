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
        public ProfilController(UtilisateursService utilisateursService) : base(utilisateursService)
        {

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

    }
}
