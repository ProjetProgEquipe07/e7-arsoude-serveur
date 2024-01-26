using arsoudeServeur.Models;
using arsoudServeur.Data;
using Microsoft.EntityFrameworkCore;

namespace arsoudeServeur.Services
{
    public class RandonneesService
    {
        private readonly ApplicationDbContext _context;

        public RandonneesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Randonnee>> GetAllRandonneesAsync(int idMin, int idMax)
        {
            return await _context.randonnées.Where(r => r.id >= idMin && r.id <= idMax).ToListAsync();
        }

        public async Task<Randonnee> GetRandonneeByIdAsync(int id)
        {
            return await _context.randonnées.FindAsync(id);
        }

        public async Task<Randonnee> CreateRandonneeAsync(Randonnee randonnee)
        {
            _context.randonnées.Add(randonnee);
            await _context.SaveChangesAsync();
            return randonnee;
        }

        public async Task<bool> UpdateRandonneeAsync(int id, Randonnee randonnee)
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
