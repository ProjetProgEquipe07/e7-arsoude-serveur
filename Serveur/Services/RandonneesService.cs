using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudServeur.Data;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<List<RandonneeListeAdminDTO>> GetAllRandonneesAsync()
        {
            List<RandonneeListeAdminDTO> randonneesEnvoye = new List<RandonneeListeAdminDTO>();
            List<Randonnee> randonnees = await _context.randonnees.ToListAsync();

            foreach (Randonnee rando in randonnees)
            {
                RandonneeListeAdminDTO r = new RandonneeListeAdminDTO()
                {
                    id = rando.id,
                    nom = rando.nom,
                    description = rando.description,
                    emplacement = rando.emplacement,
                    typeRandonnee = (int)rando.typeRandonnee,
                    etatRandonnee = (int)rando.etatRandonnee,
                    gps = rando.GPS,
      
                };
                randonneesEnvoye.Add(r);
            }

            return randonneesEnvoye;
        }

        //Méthode pour les randonnées à faire (publique, et privée mais uniquement de l'utilisateur courant)
        public async Task<List<RandonneeListDTO>> GetRandonneesAFaireAsync(int listSize, Utilisateur utilisateurCourant)
        {
            List<RandonneeListDTO> randonneesEnvoye = new List<RandonneeListDTO>();
            List<Randonnee> randonnees = await _context.randonnees.Where(
                s => s.etatRandonnee == Randonnee.Etat.Publique && //Publique
                (s.etatRandonnee == Randonnee.Etat.Privée && s.utilisateurId == utilisateurCourant.id) //Privée et uniquement à l'utilisateur courant
                ).Take(listSize).ToListAsync();

            foreach (Randonnee rando in randonnees)
            {
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
        public async Task<List<RandonneeListDTO>> GetRandonneesAFaireAsync(int listSize)
        {
            List<RandonneeListDTO> randonneesEnvoye = new List<RandonneeListDTO>();
            List<Randonnee> randonnees = await _context.randonnees.Where(
                s => s.etatRandonnee == Randonnee.Etat.Publique).Take(listSize).ToListAsync();

            foreach (Randonnee rando in randonnees)
            {
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



                randonneesEnvoye.Add(r);
            }

            return randonneesEnvoye;
        }
        public async Task<List<RandonneeListDTO>> GetRandonneesFavorisAsync(int listSize, Utilisateur utilisateurCourant)
        {
            List<RandonneeListDTO> randonneesEnvoye = new List<RandonneeListDTO>();

            if (utilisateurCourant != null)
            {
                List<Randonnee> randonnees = utilisateurCourant.favoris.Select(s => s.randonnee).Take(listSize).ToList();

                foreach (Randonnee rando in randonnees)
                {

                    RandonneeListDTO r = new RandonneeListDTO()
                    {
                        id = rando.id,
                        nom = rando.nom,
                        description = rando.description,
                        emplacement = rando.emplacement,
                        typeRandonnee = (int)rando.typeRandonnee,
                        gps = rando.GPS,
                        favoris = true
                    };

                    randonneesEnvoye.Add(r);
                }
            }

            return randonneesEnvoye;
        }

        public virtual async Task<List<RandonneeListDTO>> PutRandonneesFavorisAsync(List<Randonnee> listRandonnee, Utilisateur utilisateurCourant)
        {
            List<RandonneeListDTO> randonneesEnvoye = new List<RandonneeListDTO>();
            List<int> randonnees = new List<int>();

            if (utilisateurCourant != null)
            {
                randonnees = utilisateurCourant.favoris.Select(s => s.randonneeId).ToList();
            }

                foreach (Randonnee rando in listRandonnee)
                {

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
                    if (randonnees.Contains(r.id))
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

        public async Task<Randonnee> CreateRandonneeTraceAsync(TraceRandoDTO traceRandoDTO)
        {
            Randonnee randonneeContext = await _context.randonnees.FirstOrDefaultAsync(x => x.id == traceRandoDTO.randoId);
            Utilisateur utilisateurContext = await _context.utilisateurs.FirstOrDefaultAsync(x => x.id == traceRandoDTO.utilisateurId);

            if(utilisateurContext == null)
            {
                //t'es un invité bro tu peux pas faire de tracé
                return null;
            }
            foreach (GPS gps in traceRandoDTO.gps)
            {
                if (!gps.Arrivee && !gps.Depart)
                {
                    gps.randonnee = randonneeContext;
                    gps.randonneeId = randonneeContext.id;
                    _context.gps.Add(gps);
                }
            }
            //Si la randonnée n'est pas publique et que c'est la rando du user
            if (randonneeContext.etatRandonnee != Randonnee.Etat.Publique && randonneeContext.utilisateurId == traceRandoDTO.utilisateurId)
            {
                await _context.SaveChangesAsync();
                return randonneeContext;
            }
            //Si la randonnée est publique
            else
            {
                RandonneeUtilisateurTrace randonneeUtilisateurTrace = new RandonneeUtilisateurTrace()
                {
                    id = 0,
                    randonnee = randonneeContext,
                    randonneeId = randonneeContext.id,
                    utilisateur = utilisateurContext,
                    utilisateurId = utilisateurContext.id,
                    gpsListe = traceRandoDTO.gps,
                };
                utilisateurContext.traces.Add(randonneeUtilisateurTrace);
                await _context.SaveChangesAsync();
                return randonneeContext;
            }
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

        public async Task<int> GetRandonneesUtilisateur(int id, Utilisateur user)
        {
            return _context.randonnees.Where(x => x.id == id && x.utilisateurId == user.id).Count();
        }
    }
}
