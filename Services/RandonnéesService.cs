using arsoudeServeur.Models;
using arsoudServeur.Data;
using Microsoft.EntityFrameworkCore;

namespace arsoudeServeur.Services
{
    public class RandonnéesService
    {
        private readonly ApplicationDbContext _context;

        public RandonnéesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Randonnée>> GetAllRandonneesAsync()
        {
            return await _context.randonnées.ToListAsync();
        }

        public async Task<Randonnée> GetRandonneeByIdAsync(int id)
        {
            return await _context.randonnées.FindAsync(id);
        }

        public async Task<Randonnée> CreateRandonneeAsync(Randonnée randonnee)
        {
            _context.randonnées.Add(randonnee);
            await _context.SaveChangesAsync();
            return randonnee;
        }

        public async Task<bool> UpdateRandonneeAsync(int id, Randonnée randonnee)
        {
            if (id != randonnee.id)
            {
                return false;
            }

            _context.Entry(randonnee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RandonneeExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> DeleteRandonneeAsync(int id)
        {
            var randonnee = await _context.randonnées.FindAsync(id);
            if (randonnee == null)
            {
                return false;
            }

            _context.randonnées.Remove(randonnee);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool RandonneeExists(int id)
        {
            return _context.randonnées.Any(e => e.id == id);
        }
    }
}
