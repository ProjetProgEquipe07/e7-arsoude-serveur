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
    [Route("admin/[controller]/[action]")]
    [ApiController]
    public class RandonneesController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private UtilisateursService _utilisateursService;
        private RandonneesService _randonneesService;

        public RandonneesController(ApplicationDbContext context, UtilisateursService utilisateursService, RandonneesService randonneesService) : base(utilisateursService)
        {
            _context = context;
            _utilisateursService = utilisateursService;
            _randonneesService = randonneesService;
        }

        [HttpGet("{randonneeId}")]
        public async Task<ActionResult<IEnumerable<RandonneeListDTO>>> ApproveAsync(int randonneeId)
        {
            try
            {
                if (UtilisateurCourant.role.Equals("Administrator"))
                {
                    try
                    {
                        var rando = await _context.randonnees.FindAsync(randonneeId);
                        rando.etatRandonnee = Randonnee.Etat.Publique;
                        await _context.SaveChangesAsync();
                        return Ok(rando);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        return BadRequest();
                    }

                }
                else
                {
                    return Unauthorized();
                }

            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RandonneeListDTO>>> GetRandonnees()
        {
            try
            { 
            if (UtilisateurCourant.role.Equals("Administrator"))
            {
                try
                {
                    var rando = await _randonneesService.GetAllRandonneesAsync();
                    return Ok(rando);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
            {
                return Unauthorized();
            }
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        

        [HttpGet("{randonneeId}")]
        public async Task<ActionResult<IEnumerable<RandonneeListDTO>>> RefuserAsync(int randonneeId)
        {
            try
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
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpGet("{randonneeId}")]
        public async Task<ActionResult<IEnumerable<RandonneeListDTO>>> AapproveAsync(int randonneeId)
        {
            try { 
            if (UtilisateurCourant.role.Equals("Administrator"))
            {
                try
                {
                    var rando = await _context.randonnees.FindAsync(randonneeId);
                    rando.etatRandonnee = Randonnee.Etat.Privée;
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
            catch (Exception)
            {
                return Unauthorized();
            }
        }


    }
}
