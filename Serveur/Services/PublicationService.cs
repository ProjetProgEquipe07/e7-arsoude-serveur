using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudServeur.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static arsoudeServeur.Models.Publication;

namespace arsoudeServeur.Services
{
    public class PublicationService
    {

        private ApplicationDbContext _context;

        public PublicationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Publication> CreatePublication(PublicationDTO dto, Utilisateur user)
        {
            var rando = _context.randonnees.Where(r => r.id == dto.randoiId).FirstOrDefault();

            Publication publication = new Publication()
            {
                randonnee = rando,
                randonneeId = rando.id,
                utilisateur = user,
                utilisateurId = user.id,
                etat = (EtatPublication)dto.etatPublic
            };

            _context.publication.Add(publication);
            _context.SaveChangesAsync();

            return publication;
            
        }

        public async Task<IEnumerable<PublicationDTOSend>> GetPublicationsUser(int utilisateurId)
        {
            Utilisateur user = await _context.utilisateurs.Where(u => u.id == utilisateurId).FirstOrDefaultAsync();

           var list = await _context.publication.Where(p => (p.etat == EtatPublication.Publique && p.utilisateurId == user.id) ||(p.utilisateur.id == user.id && p.etat == EtatPublication.Privee))
                .Select(p => new PublicationDTOSend
                {
                    id = p.id,
                    etat = p.etat,
                    randonnee = new RandonneeDetailDTO
                    {
                        id = p.randonnee.id,
                        nom = p.randonnee.nom,
                        description = p.randonnee.description,
                        emplacement = p.randonnee.emplacement,
                        typeRandonnee = (int)p.randonnee.typeRandonnee,
                        gps = p.randonnee.GPS,
                        favoris = false
                    },
                    randonneeId = p.randonneeId,
                    utilisateurId = p.utilisateurId,
                    listLike = p.listLike,
                    utilisateur = p.utilisateur
                }).ToListAsync();

            return list;
           
        }

        public async Task<ActionResult<IEnumerable<PublicationDTOSend>>> GetPublications(Utilisateur user)
        {

            var test = await _context.utilisateursTrace.ToListAsync();

            var gpsData = await _context.utilisateursTrace
                    .Where(ut => ut.utilisateurId == user.id && _context.publication.Any(p => p.randonneeId == ut.randonneeId))
                    .GroupBy(ut => ut.randonneeId) 
                    .ToDictionaryAsync(
                                      g => g.Key, 
                                      g => g.SelectMany(ut => ut.gpsListe ?? new List<GPS>()).ToList() 
    );
            var list = await _context.publication
            .Where(p => p.etat == EtatPublication.Publique || (p.utilisateur.id == user.id && p.etat == EtatPublication.Privee))
            .Select(p => new
                {
                    Publication = p,
                        GpsList = gpsData.ContainsKey(p.randonnee.id) ? gpsData[p.randonnee.id] : null
                }).ToListAsync();

            var resultList = list.Select(item => new PublicationDTOSend
            {
                id = item.Publication.id,
                etat = item.Publication.etat,
                randonnee = new RandonneeDetailDTO
                {
                    id = item.Publication.randonnee.id,
                    nom = item.Publication.randonnee.nom,
                    description = item.Publication.randonnee.description,
                    emplacement = item.Publication.randonnee.emplacement,
                    typeRandonnee = (int)item.Publication.randonnee.typeRandonnee,
                    gps = item.GpsList, 
                    favoris = false
                },
                randonneeId = item.Publication.randonneeId,
                utilisateurId = item.Publication.utilisateurId,
                listLike = item.Publication.listLike,
                utilisateur = item.Publication.utilisateur
            }).ToList();
            return resultList;
        }

        public async Task<ActionResult<Publication>> LikePublication(Utilisateur user, int publiId)
        {
            var publication = await _context.publication.Where(p => p.id == publiId).FirstOrDefaultAsync();

            if(publication.listLike.Contains(user))
            {
                publication.listLike.Remove(user);
            }
            else
            {
                publication.listLike.Add(user);
            }

            _context.SaveChangesAsync();
            return publication;

            
        }
    }
}
