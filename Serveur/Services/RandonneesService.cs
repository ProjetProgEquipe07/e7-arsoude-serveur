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
        private readonly ServiceTranslate _serviceTranslate;    

        public RandonneesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public RandonneesService(ApplicationDbContext context, AvertissementService avertissementService, ServiceTranslate serviceTranslate)
        {
            _context = context;
            _avertissementService = avertissementService;
            _serviceTranslate = serviceTranslate;
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
                s => s.etatRandonnee == Randonnee.Etat.Publique || //Publique
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
                s => s.etatRandonnee == Randonnee.Etat.Privée).Take(listSize).ToListAsync();

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

        public async Task<List<RandonneeListDTO>> GetRandonneesAFaireAnglaisAsync(int listSize, Utilisateur utilisateurCourant)
        {
            List<RandonneeListDTO> randonneesEnvoye = new List<RandonneeListDTO>();
            List<RandonneeAnglais> randonnees = await _context.randonneeAnglais.Where(
                 s => s.etatRandonnee == Randonnee.Etat.Privée).Take(listSize).ToListAsync();// && s.etatRandonnee == Randonnee.Etat.Publique//Publique
                //(s.etatRandonnee == Randonnee.Etat.Privée && s.utilisateurId == utilisateurCourant.id) //Privée et uniquement à l'utilisateur courant

            foreach (RandonneeAnglais rando in randonnees)
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

        public async Task<List<RandonneeListDTO>> GetRandonneesAFaireAnglaisAsync(int listSize)
        {
            List<RandonneeListDTO> randonneesEnvoye = new List<RandonneeListDTO>();
            List<RandonneeAnglais> randonnees = await _context.randonneeAnglais.Where(
                s => s.etatRandonnee == Randonnee.Etat.Privée).Take(listSize).ToListAsync();

            foreach (RandonneeAnglais rando in randonnees)
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

            List<Avertissement> avertissements = new List<Avertissement>();
            avertissements = await _context.avertissements.Where(x => x.randonneeId == rando.id).ToListAsync();

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

            if (rando.GPS.Count == 2)
            {
                gps.gpsListe = rando.GPS;
            }
            else
            {
                listgps.Add(rando.GPS[0]);
                listgps.Add(rando.GPS[1]);

                gps = await _context.utilisateursTrace.Where(x => x.utilisateurId == rando.utilisateurId && x.randonneeId == rando.id).FirstOrDefaultAsync();

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
            Randonnee randoFr = new Randonnee
            {

                id = 0,
                nom = null,
                description = null,
                emplacement = null,
                typeRandonnee = (Randonnee.Type)randonneeDTO.typeRandonnee,
                GPS = randonneeDTO.gps,
                utilisateur = user
            };
            RandonneeAnglais randonneeAnglais = new RandonneeAnglais
            {
                id = 0,
                nom = null,
                description = null,
                emplacement = null,
                typeRandonnee = (Randonnee.Type)randonneeDTO.typeRandonnee,
                GPS = randonneeDTO.gps,
                utilisateur = user
            };

            IEnumerable<TraductionIndicator> traductionIndicators = new List<TraductionIndicator>();


            traductionIndicators = await _serviceTranslate.DetectLanguage(randonneeDTO);

            int index = 0;
            foreach (var indicator in traductionIndicators)
            {
                switch (index)
                {
                    case 0:
                        if (indicator.targetLanguage == "en")
                        {
                            randonneeAnglais.nom = indicator.text;
                        }
                        else
                        {
                            randoFr.nom = indicator.text;
                        }

                        if (randonneeAnglais.nom == null)
                        {
                            randonneeAnglais.nom = await _serviceTranslate.TranslateText(indicator.text, "en");
                        }
                        else
                        {
                            randoFr.nom = await _serviceTranslate.TranslateText(indicator.text, "fr");
                        }


                        break;
                    case 1:
                        if (indicator.targetLanguage == "en")
                        {
                            randonneeAnglais.description = indicator.text;
                        }
                        else
                        {
                            randoFr.description = indicator.text;
                        }

                        if (randonneeAnglais.description == null)
                        {
                            randonneeAnglais.description = await _serviceTranslate.TranslateText(indicator.text, "en");
                        }
                        else
                        {
                            randoFr.description = await _serviceTranslate.TranslateText(indicator.text, "fr");
                        }
                        break;
                    case 2:
                        if (indicator.targetLanguage == "en")
                        {
                            randonneeAnglais.emplacement = indicator.text;
                        }
                        else
                        {
                            randoFr.emplacement = indicator.text;
                        }

                        if (randonneeAnglais.emplacement == null)
                        {
                            randonneeAnglais.emplacement = await _serviceTranslate.TranslateText(indicator.text, "en");
                        }
                        else
                        {
                            randoFr.emplacement = await _serviceTranslate.TranslateText(indicator.text, "fr");
                        }
                        break;

                }
                index++;
            }



            _context.randonnees.Add(randoFr);
            await _context.SaveChangesAsync();

            randonneeAnglais.randonneeId = randoFr.id;

            _context.randonneeAnglais.Add(randonneeAnglais);
            await _context.SaveChangesAsync();
            return randoFr;
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
