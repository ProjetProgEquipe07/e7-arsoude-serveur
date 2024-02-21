using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using arsoudServeur.Data;
using arsoudeServeur.Models;
using Microsoft.AspNetCore.Authorization;
using arsoudeServeur.Controllers;
using arsoudeServeur.Services;
using arsoudeServeur.Models.DTOs;

namespace arsoudeServeur.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ApiController]
    [Route("Admin/[controller]/[action]")]
    public class UtilisateursController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public UtilisateursController(ApplicationDbContext context, UtilisateursService utilisateursService) : base(utilisateursService)
        {
            _context = context;
        }

        // GET: Admin/Utilisateurs
        [HttpGet]
        public async Task<ActionResult<Boolean>> EstAdmin()
        {
            if (UtilisateurCourant == null)
            {
                return false;
            }

            if (UtilisateurCourant.role.Equals("Administrator"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateurViaMail(ProfilPubliqueDTO email)
        {

            ProfilDTO user = await _context.utilisateurs.Where(u => u.courriel == email.courriel).Select(u => new ProfilDTO
            {
                id = u.id,
                nom = u.nom,
                prenom = u.prenom,
                courriel = u.courriel,
            }).FirstOrDefaultAsync();

            return Ok(user);
        }
       
    }
}
