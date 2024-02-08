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
using arsoudeServeur.Models.DTOs;

namespace arsoudeServeur.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ApiController]
    [Route("Admin/[controller]")]
    public class RandonneesController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private UtilisateursService _utilisateursService;

        public RandonneesController(ApplicationDbContext context, UtilisateursService utilisateursService) : base(utilisateursService)
        {
            _context = context;
            _utilisateursService = utilisateursService;
        }

        [HttpPost]
        [Route("ApprouverRandonnee")]
        public async Task<IActionResult> ApprouverRandonneeAsync(int randonneeId)
        {
            
            if(UtilisateurCourant.role.Equals("Administrator"))
            {
                try
                {
                    var rando = await _context.randonnees.FindAsync(randonneeId);
                    rando.etatRandonnee = Randonnee.Etat.Publique;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //changer l'erreur lol
                    return BadRequest();
                }
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("RefuserRandonnee")]
        public async Task<IActionResult> RefuserRandonneeAsync(int randonneeId)
        {
            if (UtilisateurCourant.role.Equals("Administrator"))
            {
                try
                {
                    var rando = await _context.randonnees.FindAsync(randonneeId);
                    rando.etatRandonnee = Randonnee.Etat.Refusée;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //changer l'erreur lol
                    return BadRequest();
                }
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }


    }
}
