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
using System.Data;
using arsoudeServeur.Controllers;
using arsoudeServeur.Services;

namespace arsoudeServeur.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [Area("Admin")]
    public class RandonneesController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private UtilisateursService _utilisateursService;

        public RandonneesController(ApplicationDbContext context, UtilisateursService utilisateursService) : base(utilisateursService)
        {
            _context = context;
            _utilisateursService = utilisateursService;
        }


 
        [HttpGet("{id}")]
        public async Task<ActionResult<Randonnee>> ApproveRando(int id) 
        {
            Utilisateur user = UtilisateurCourant;
            if (user.role.Contains("Administrator"))
            {
                Randonnee randonnee = await _context.randonnees.FindAsync(id);
                randonnee.approuve = true;

                _context.SaveChangesAsync();

                return Ok(randonnee);
            }
            else
            {
                return Unauthorized("Vous n'avez pas les droits pour cette action");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Randonnee>> RefuseRando(int id)
        {
            Utilisateur user = UtilisateurCourant;
            if (user.role.Contains("Administrator"))
            {
                try
                {
                    Randonnee randonnee = await _context.randonnees.FindAsync(id);
                    _context.randonnees.Remove(randonnee);

                    _context.SaveChangesAsync();

                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            else
            {
                return Unauthorized("Vous n'avez pas les droits pour cette action");
            }
        }
      

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Randonnee>>> GetListApproveRando()
        {
            Utilisateur user = UtilisateurCourant;
            if(user.role.Contains("Administrator"))
            { 
                List<Randonnee> randonnee = await _context.randonnees.Where(x => x.approuve == false).ToListAsync();

            return Ok(randonnee);
            }
            else
            {
                return Unauthorized("Vous n'avez pas les droits pour cette action");
            }
        }
    }
}
