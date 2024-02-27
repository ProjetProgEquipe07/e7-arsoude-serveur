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
        private readonly AvertissementService _avertissementService;

        public class RandonneeNotFoundException : Exception
        {

        }
        public class UtilisateurNotFoundException : Exception
        {

        }
        public class GPSRequiredException : Exception
        {

        }
        public class NomOutOfBoundsException : Exception
        {

        }
        public class DescriptionOutOfBoundsException : Exception
        {

        }
        public class TypeRandonneeOutOfBoundsException : Exception
        {

        }
        public class AvertissementNotFoundException : Exception
        {

        }


        public RandonneesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public RandonneesService(ApplicationDbContext context, AvertissementService avertissementService)
        {
            _context = context;
            _avertissementService = avertissementService;
        }

        public virtual async Task<List<RandonneeListeAdminDTO>> GetAllRandonneesAsync()
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
        public virtual async Task<List<RandonneeListDTO>> GetRandonneesAFaireAsync(int listSize, Utilisateur utilisateurCourant)
        {
            List<RandonneeListDTO> randonneesEnvoye = new List<RandonneeListDTO>();
            List<Randonnee> randonnees = await _context.randonnees.Where(
                s => s.etatRandonnee == Randonnee.Etat.Publique || //Publique
                (s.etatRandonnee == Randonnee.Etat.Privée && s.utilisateurId == utilisateurCourant.id) //Privée et uniquement à l'utilisateur courant
                ).Take(listSize).ToListAsync();
            if (randonnees == null)
            {
                //rando inexistante
                throw new RandonneeNotFoundException();
            }
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
                    RandonneeUtilisateur favorisUtilisateurCheck = utilisateurCourant.favoris.SingleOrDefault(randonnee => randonnee.randonneeId == rando.id);

                    if (utilisateurCourant.favoris.Contains(favorisUtilisateurCheck))
                    {
                        r.favoris = true;
                    }
                }

                randonneesEnvoye.Add(r);
            }

            return randonneesEnvoye;
        }
        public virtual async Task<List<RandonneeListDTO>> GetRandonneesAFaireNoAuthAsync(int listSize)
        {
            List<RandonneeListDTO> randonneesEnvoye = new List<RandonneeListDTO>();
            List<Randonnee> randonnees = await _context.randonnees.Where(
                s => s.etatRandonnee == Randonnee.Etat.Publique).Take(listSize).ToListAsync();

            if (randonnees == null)
            {
                //rando inexistante
                throw new RandonneeNotFoundException();
            }
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

        public virtual async Task<RandonneeDetailDTO> GetRandonneeByIdAsync(int id, Utilisateur utilisateurCourant)
        {
            Randonnee rando = await _context.randonnees.FindAsync(id);
            if (rando == null)
            {
                //rando inexistante
                throw new RandonneeNotFoundException();
            }

            List<Avertissement> avertissements = new List<Avertissement>();
            avertissements = await _context.avertissements.Where(x => x.randonneeId == rando.id).ToListAsync();

            if (avertissements == null)
            {
                throw new AvertissementNotFoundException();
            }

            if (avertissements.Count > 0)
            {
                for (int i = avertissements.Count() - 1; i >= 0; i--)
                {
                    if (DateTime.Compare(avertissements[i].DateSuppresion, DateTime.Now) < 0)
                    {
                        await _avertissementService.DeleteAvertissementAsync(avertissements[i].id);
                    }
                }
                
            }

            RandonneeUtilisateurTrace gps = new RandonneeUtilisateurTrace();
            List<GPS> listgps = new List<GPS>();

            if (rando.GPS.Count < 2)
            {
                throw new GPSRequiredException();
            }
            else if (rando.GPS.Count == 2)
            {
                gps.gpsListe = rando.GPS;
            }
            else
            {

                gps = await _context.utilisateursTrace.Where(x => x.utilisateurId == rando.utilisateurId && x.randonneeId == rando.id).SingleOrDefaultAsync();

                foreach (GPS gps2 in gps.gpsListe) {
                    listgps.Add(gps2);
                }

                gps.gpsListe = listgps;

            }

            RandonneeDetailDTO r = new RandonneeDetailDTO()
            {
                id = rando.id,
                nom = rando.nom,
                description = rando.description,
                emplacement = rando.emplacement,
                typeRandonnee = (int)rando.typeRandonnee,
                gps = gps.gpsListe,
                utilisateur = rando.utilisateur,
                utilisateurId = rando.utilisateurId,
                favoris = false,
                avertissements = avertissements
            };

            if (utilisateurCourant != null)
            {
                RandonneeUtilisateur favorisUtilisateurCheck = utilisateurCourant.favoris.SingleOrDefault(randonnee => randonnee.randonneeId == rando.id);

                if (utilisateurCourant.favoris.Contains(favorisUtilisateurCheck))
                {
                    r.favoris = true;
                }
            }

            return r;
        }

        public virtual async Task<Randonnee> CreateRandonneeAsync(RandonneeDTO randonneeDTO, Utilisateur user)
        {
            // Trouver le currentUser et l'associer à la randonnée 
            Randonnee randonnee = new Randonnee
            {
                nom = randonneeDTO.nom,
                description = randonneeDTO.description,
                emplacement = randonneeDTO.emplacement,
                typeRandonnee = (Randonnee.Type)randonneeDTO.typeRandonnee,
                GPS = randonneeDTO.gps,
                utilisateur = user
            };
            if(user == null)
            {
                throw new UtilisateurNotFoundException();
            }
            if (randonneeDTO.nom.Length > 25 || randonneeDTO.nom.Length < 2)
            {
                throw new NomOutOfBoundsException();
            }
            if (randonneeDTO.description.Length > 255 || randonneeDTO.description.Length < 10)
            {
                throw new DescriptionOutOfBoundsException();
            }
            if (randonneeDTO.typeRandonnee < 0 || randonneeDTO.typeRandonnee > 2)
            {
                throw new TypeRandonneeOutOfBoundsException();
            }
            if (randonneeDTO.gps == null)
            {
                throw new GPSRequiredException();
            }

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

            RandonneeUtilisateur favorisUtilisateurCheck = utilisateurCourant.favoris.SingleOrDefault(rando => rando.randonneeId == randonneeId);

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

            List<GPS> newgps = new List<GPS>();
            foreach (GPS gps in traceRandoDTO.gps)
            {
                    if (!gps.arrivee && !gps.depart)
                    {
                        gps.randonnee = randonneeContext;
                        gps.randonneeId = randonneeContext.id;
                        newgps.Add(gps);
                        _context.gps.Add(gps);
                    }
                    else if (randonneeContext.utilisateurId == traceRandoDTO.utilisateurId && (gps.arrivee || gps.depart))
                    {
                    GPS gpsSup = await _context.gps.Where(p => p.randonneeId == gps.randonneeId && (gps.arrivee || gps.depart)).FirstOrDefaultAsync();
                    _context.gps.Remove(gpsSup);
                    }
            }   

            RandonneeUtilisateurTrace gpstemp; 
            if (traceRandoDTO.publicationid == 0 )
            {
               gpstemp = new RandonneeUtilisateurTrace()
                {
                    randonnee = randonneeContext,
                    randonneeId = randonneeContext.id,
                    utilisateur = utilisateurContext,
                    utilisateurId = utilisateurContext.id,
                    gpsListe = newgps,
                    timer = traceRandoDTO.timer
                };


            }
            else
            { 

             gpstemp = new RandonneeUtilisateurTrace()
            {
                randonnee = randonneeContext,
                randonneeId = randonneeContext.id,
                utilisateur = utilisateurContext,
                utilisateurId = utilisateurContext.id,
                gpsListe = newgps,
                publicationId = traceRandoDTO.publicationid,
                timer = traceRandoDTO.timer
            };
            }

            utilisateurContext.traces.Add(gpstemp);

            await _context.utilisateursTrace.AddAsync(gpstemp);
            await _context.SaveChangesAsync();
            return randonneeContext;

            /*
            //Si la randonnée n'est pas publique et que c'est la rando du user
            if (randonneeContext.etatRandonnee != Randonnee.Etat.Publique && randonneeContext.utilisateurId == traceRandoDTO.utilisateurId)
            {
                RandonneeUtilisateurTrace gps = new RandonneeUtilisateurTrace()
                {
                    id = 0,
                    randonnee = randonneeContext,
                    randonneeId = randonneeContext.id,
                    utilisateur = utilisateurContext,
                    utilisateurId = utilisateurContext.id,
                    gpsListe = traceRandoDTO.gps,
                };
                utilisateurContext.traces.Add(gps);

                await _context.utilisateursTrace.AddAsync(gps);
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
            }*/
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
