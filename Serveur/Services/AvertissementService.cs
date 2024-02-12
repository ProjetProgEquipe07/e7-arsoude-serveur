using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Models;
using arsoudServeur.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace arsoudeServeur.Services
{
    public class AvertissementService
    {
        private readonly ApplicationDbContext _context;

        public AvertissementService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Avertissement> CreateAvertissementAsync(int id, int avertissementId, GPS gps)
        {
            Randonnee rando = await _context.randonnees.FirstOrDefaultAsync(x => x.id == id);

            if (rando == null) 
            {
                //rando inexistante
                return null;
            }

            if (avertissementId < 0 || avertissementId > 3)
            {
                //avertissement pas existant
                return null;
            }

            if (gps == null)
            {
                return null;
            }

            Avertissement avertissement = new Avertissement()
            {
                DateSuppresion = DateTime.Now + TimeSpan.FromDays(7),
                randonneeId = rando.id,
                typeAvertissement = (Avertissement.TypeAvertissement)avertissementId,
                x = gps.x,
                y = gps.y,
            };

            _context.avertissements.Add(avertissement);
            await _context.SaveChangesAsync();
            return avertissement;
        }

        public async Task<bool> DeleteAvertissementAsync(int avertissementId)
        {
            var avertissement = await _context.avertissements.FindAsync(avertissementId);

            if (avertissement == null)
            {
                return false;
            }

            _context.avertissements.Remove(avertissement);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddTimeAvertissementAsync(int avertissementId)
        {
            var avertissement = await _context.avertissements.FindAsync(avertissementId);

            if (avertissement == null)
            {
                return false;
            }

            avertissement.DateSuppresion = DateTime.Now + TimeSpan.FromDays(7);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
