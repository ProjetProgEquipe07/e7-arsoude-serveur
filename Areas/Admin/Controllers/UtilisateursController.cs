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

namespace arsoudeServeur.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [Area("Admin")]
    public class UtilisateursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UtilisateursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Utilisateurs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.utilisateurs.Include(u => u.identityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Utilisateurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.utilisateurs == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.utilisateurs
                .Include(u => u.identityUser)
                .FirstOrDefaultAsync(m => m.id == id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }

        // GET: Admin/Utilisateurs/Create
        public IActionResult Create()
        {
            ViewData["identityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // GET: Admin/Utilisateurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.utilisateurs == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.utilisateurs.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            ViewData["identityUserId"] = new SelectList(_context.Users, "Id", "Id", utilisateur.identityUserId);
            return View(utilisateur);
        }

        // POST: Admin/Utilisateurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,courriel,prenom,nom,codePostal,anneeDeNaissance,moisDeNaissance,adresse,identityUserId")] Utilisateur utilisateur)
        {
            if (id != utilisateur.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilisateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilisateurExists(utilisateur.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["identityUserId"] = new SelectList(_context.Users, "Id", "Id", utilisateur.identityUserId);
            return View(utilisateur);
        }

        // GET: Admin/Utilisateurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.utilisateurs == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.utilisateurs
                .Include(u => u.identityUser)
                .FirstOrDefaultAsync(m => m.id == id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }

        // POST: Admin/Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.utilisateurs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.utilisateurs'  is null.");
            }
            var utilisateur = await _context.utilisateurs.FindAsync(id);
            if (utilisateur != null)
            {
                _context.utilisateurs.Remove(utilisateur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilisateurExists(int id)
        {
          return (_context.utilisateurs?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
