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

        public async Task<List<RandonneeListDTO>> GetAllRandonneesAsync(int idMin, int idMax, Utilisateur utilisateurCourant)
        {
            List<RandonneeListDTO> randonneesEnvoye = new List<RandonneeListDTO>();
            List<Randonnee> randonnees = await _context.randonnees.Where(r => r.id >= idMin && r.id <= idMax).ToListAsync();

            foreach (Randonnee rando in randonnees) {
                RandonneeListDTO r = new RandonneeListDTO()
                {
                    id = rando.id,
                    nom = rando.nom,
                    description = rando.description,
                    emplacement = rando.emplacement,
                    typeRandonnee = (int)rando.typeRandonnee,
                    gps = rando.GPS,
                    favoris = false
                };

                if (utilisateurCourant != null)
                {
                    RandonneeUtilisateur favorisUtilisateurCheck = utilisateurCourant.favoris.FirstOrDefault(randonnee => randonnee.randonneeId == rando.id);

                    if (utilisateurCourant.favoris.Contains(favorisUtilisateurCheck))
                    {
                        r.favoris = true;
                    }
                }

                randonneesEnvoye.Add(r);
            }

            return randonneesEnvoye;
        }

        public async Task<RandonneeDetailDTO> GetRandonneeByIdAsync(int id, Utilisateur utilisateurCourant)
        {
            Randonnee rando = await _context.randonnees.FindAsync(id);

            if (rando == null)
            {
                return null;
            }
            RandonneeDetailDTO r = new RandonneeDetailDTO()
            {
                id = rando.id,
                nom = rando.nom,
                description = rando.description,
                emplacement = rando.emplacement,
                typeRandonnee = (int)rando.typeRandonnee,
                gps = rando.GPS,
                utilisateur = rando.utilisateur,
                utilisateurId = rando.utilisateurId,
                favoris = false
            };

            if (utilisateurCourant != null)
            {
                RandonneeUtilisateur favorisUtilisateurCheck = utilisateurCourant.favoris.FirstOrDefault(randonnee => randonnee.randonneeId == rando.id);

                if (utilisateurCourant.favoris.Contains(favorisUtilisateurCheck))
                {
                    r.favoris = true;
                }
            }

            return r;
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

        public async Task<bool?> UpdateFavoritesAsync(int randonneeId, Utilisateur utilisateurCourant)
        {
            bool favoris = false;

            if (utilisateurCourant == null)
            {
                return false;
            }
            Randonnee rando = await _context.randonnees.FindAsync(randonneeId);

            if (rando == null)
            {
                return null;
            }

            RandonneeUtilisateur favorisUtilisateurCheck = utilisateurCourant.favoris.FirstOrDefault(rando => rando.randonneeId == randonneeId);

            if (favorisUtilisateurCheck != null)
            {
                utilisateurCourant.favoris.Remove(favorisUtilisateurCheck);
                favoris = false;
            }
            else
            {
                RandonneeUtilisateur favorisUtilisateurToAdd = new RandonneeUtilisateur()
                {
                    id = 0,
                    randonnee = rando,
                    randonneeId = rando.id,
                    utilisateur = utilisateurCourant,
                    utilisateurId = utilisateurCourant.id
                };

                utilisateurCourant.favoris.Add(favorisUtilisateurToAdd);
                favoris = true;
            }
            await _context.SaveChangesAsync();
            return favoris;
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
