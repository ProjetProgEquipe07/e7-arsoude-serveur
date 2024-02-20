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

                    utilisateur = p.utilisateur
                }).ToListAsync();

            return list;
           
        }

        public async Task<ActionResult<IEnumerable<PublicationDTOSend>>> GetPublications(Utilisateur user)
        {

            

            var likesData = await _context.Like
                    .Include(pu => pu.utilisateur) 
                    .ToListAsync();

            var gpsData = await _context.utilisateursTrace
                    .Where(ut => ut.utilisateurId == user.id && _context.publication.Any(p => p.randonneeId == ut.randonneeId))
                    .GroupBy(ut => ut.randonneeId) 
                    .ToDictionaryAsync(
                                      g => g.Key, 
                                      g => g.SelectMany(ut => ut.gpsListe ?? new List<GPS>()).ToList());
            var publications = await _context.publication
                            .Where(p => p.etat == EtatPublication.Publique || (p.utilisateur.id == user.id && p.etat == EtatPublication.Privee))
                            .Select(p => new PublicationResult
                            {
                                Publication = p,
                                GpsList = gpsData.ContainsKey(p.randonnee.id) ? gpsData[p.randonnee.id] : null,
                                Likes = (List<Utilisateur>?)null
                            }).ToListAsync();
            foreach (var pub in publications)
            {
                pub.Likes = likesData != null && likesData.Any() ? likesData.Where(l => l.publicationId == pub.Publication.id).Select(l => l.utilisateur).ToList() : new List<Utilisateur>();
            }

            var list = await _context.publication
                                     .Include(p => p.publicationLikes)
                                     .ThenInclude(pl => pl.utilisateur)
                                     .Where(p => p.etat == EtatPublication.Publique || (p.utilisateur.id == user.id && p.etat == EtatPublication.Privee))
                                     .Select(p => new
                                     {
                                       Publication = p,
                                       GpsList = gpsData.ContainsKey(p.randonnee.id) ? gpsData[p.randonnee.id] : null,
                                       Likes = p.publicationLikes.Select(pl => pl.utilisateur).ToList()
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
                listLike = item.Likes,
                utilisateur = item.Publication.utilisateur
            }).ToList();
            return resultList;
        }

        public class PublicationResult
        {
            public Publication Publication { get; set; }
            public List<GPS> GpsList { get; set; }
            public List<Utilisateur> Likes { get; set; }
        }

        public async Task<ActionResult<Publication>> LikePublication(Utilisateur user, int publiId)
        {
            var publication = await _context.publication.Include(p => p.publicationLikes).FirstOrDefaultAsync(p => p.id == publiId);
            if (publication == null)
            {
                return null;
            }

            // Vérifier si l'utilisateur a déjà liké la publication
            var like = publication.publicationLikes.FirstOrDefault(pl => pl.utilisateurId == user.id);

            if (like != null)
            {
                
                _context.Like.Remove(like);
            }
            else
            {
                
                var newLike = new PublicationUtilisateur
                {
                    utilisateurId = user.id,
                    publicationId = publiId
                };
                _context.Like.Add(newLike);
            }

            await _context.SaveChangesAsync();

            
            return publication;


        }
    }
}
