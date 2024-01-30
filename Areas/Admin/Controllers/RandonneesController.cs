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

namespace arsoudeServeur.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [Area("Admin")]
    public class RandonneesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RandonneesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Randonnees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.randonnees.Include(r => r.utilisateur);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Randonnees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.randonnees == null)
            {
                return NotFound();
            }

            var randonnee = await _context.randonnees
                .Include(r => r.utilisateur)
                .FirstOrDefaultAsync(m => m.id == id);
            if (randonnee == null)
            {
                return NotFound();
            }

            return View(randonnee);
        }

        // GET: Admin/Randonnees/Create
        public IActionResult Create()
        {
            ViewData["utilisateurId"] = new SelectList(_context.utilisateurs, "id", "id");
            return View();
        }

        // POST: Admin/Randonnees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nom,description,emplacement,typeRandonnee,utilisateurId")] Randonnee randonnee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(randonnee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["utilisateurId"] = new SelectList(_context.utilisateurs, "id", "id", randonnee.utilisateurId);
            return View(randonnee);
        }

        // GET: Admin/Randonnees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.randonnees == null)
            {
                return NotFound();
            }

            var randonnee = await _context.randonnees.FindAsync(id);
            if (randonnee == null)
            {
                return NotFound();
            }
            ViewData["utilisateurId"] = new SelectList(_context.utilisateurs, "id", "id", randonnee.utilisateurId);
            return View(randonnee);
        }

        // POST: Admin/Randonnees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nom,description,emplacement,typeRandonnee,utilisateurId")] Randonnee randonnee)
        {
            if (id != randonnee.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randonnee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RandonneeExists(randonnee.id))
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
            ViewData["utilisateurId"] = new SelectList(_context.utilisateurs, "id", "id", randonnee.utilisateurId);
            return View(randonnee);
        }

        // GET: Admin/Randonnees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.randonnees == null)
            {
                return NotFound();
            }

            var randonnee = await _context.randonnees
                .Include(r => r.utilisateur)
                .FirstOrDefaultAsync(m => m.id == id);
            if (randonnee == null)
            {
                return NotFound();
            }

            return View(randonnee);
        }

        // POST: Admin/Randonnees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.randonnees == null)
            {
                return Problem("Entity set 'ApplicationDbContext.randonnees'  is null.");
            }
            var randonnee = await _context.randonnees.FindAsync(id);
            if (randonnee != null)
            {
                _context.randonnees.Remove(randonnee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandonneeExists(int id)
        {
          return (_context.randonnees?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
