using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
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
            return await _context.randonnees.Where(r => r.id >= idMin && r.id <= idMax).ToListAsync();
        }

        public async Task<Randonnee> GetRandonneeByIdAsync(int id)
        {
            return await _context.randonnees.FindAsync(id);
        }

        public async Task<Randonnee> CreateRandonneeAsync(RandonneeDTO randonneeDTO, Utilisateur user)
        {
            // Trouver le currentUser et l'associer à la randonnée 
            // 


            Randonnee randonnee = new Randonnee
            {
                id = 0,
                nom = randonneeDTO.nom,
                description = randonneeDTO.description,
                emplacement = randonneeDTO.emplacement,
                typeRandonnee = (Randonnee.Type)randonneeDTO.typeRandonnee,
                GPS = randonneeDTO.gps,
                utilisateur = user

            };
            _context.randonnees.Add(randonnee);
            await _context.SaveChangesAsync();
            return randonnee;
        }

        public async Task<Randonnee> CreateRandonneeTraceAsync(Randonnee randonnee)
        {
            Randonnee r = await _context.randonnees.FirstOrDefaultAsync(x => x.id == randonnee.id);
            foreach(GPS gps in randonnee.GPS)
            {
                if (!gps.Arrivee && !gps.Depart) 
                {
                    gps.randonnee = r;
                    gps.randonneeId = r.id;
                    _context.gps.Add(gps);
                }
            }


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
            var randonnee = await _context.randonnees.FindAsync(id);
            if (randonnee == null)
            {
                return false;
            }

            _context.randonnees.Remove(randonnee);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool RandonneeExists(int id)
        {
            return _context.randonnees.Any(e => e.id == id);
        }
    }
}
