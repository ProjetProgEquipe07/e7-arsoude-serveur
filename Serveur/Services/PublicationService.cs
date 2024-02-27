using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudServeur.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static arsoudeServeur.Models.Publication;
using static arsoudeServeur.Models.Randonnee;

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
            EtatPublication etat2;

            if (dto.etatPublic)
            {
                etat2 = EtatPublication.Publique;
            }
            else
            {
                etat2 = EtatPublication.Privee;
            }

            Publication publication = new Publication()
            {
                randonnee = rando,
                randonneeId = rando.id,
                utilisateur = user,
                utilisateurId = user.id,
                etat = etat2
                 };

            _context.publication.Add(publication);
            _context.SaveChangesAsync();

            publication = await _context.publication.OrderBy(p=>p.id).LastAsync();

            return publication;
            
        }

        public async Task<IEnumerable<PublicationDTOSend>> GetPublicationsUser(int utilisateurId, Utilisateur userCourant, string language)
        {
            Utilisateur user = await _context.utilisateurs.FindAsync(utilisateurId);

            var likesData = await _context.Like
                    .Include(pu => pu.utilisateur)
                    .ToListAsync();

            var gpsData = await _context.utilisateursTrace.Where(p => p.publicationId != null).ToListAsync();


            var publications = await _context.publication
                            .Where(p => (p.etat == EtatPublication.Publique && p.utilisateurId == user.id) || (p.utilisateur.id == userCourant.id && p.etat == EtatPublication.Privee))
                            .Select(p => new PublicationResult
                            {
                                Publication = p,
                                Likes = (List<Utilisateur>?)null

                            }).ToListAsync();
            foreach (var pub in publications)
            {
                pub.Likes = likesData != null && likesData.Any() ? likesData.Where(l => l.publicationId == pub.Publication.id).Select(l => l.utilisateur).ToList() : new List<Utilisateur>();
            }

            var list = await _context.publication
                                     .Include(p => p.publicationLikes)
                                     .ThenInclude(pl => pl.utilisateur)
                                     .Where(p => (p.etat == EtatPublication.Publique && p.utilisateurId == user.id) || (p.utilisateur.id == userCourant.id && p.etat == EtatPublication.Privee))
                                     .Select(p => new
                                     {
                                         Publication = p,
                                         Likes = p.publicationLikes.Select(pl => pl.utilisateur).ToList(),
                                         Randonnee = p.randonnee
                                     }).ToListAsync();

            if (language == "en")
            {
#pragma warning disable CS8619 // La nullabilité des types référence dans la valeur ne correspond pas au type cible.
                list = await _context.publication
                                     .Include(p => p.publicationLikes)
                                     .ThenInclude(pl => pl.utilisateur)
                                     .Where(p => (p.etat == EtatPublication.Publique && p.utilisateurId == user.id) || (p.utilisateur.id == userCourant.id && p.etat == EtatPublication.Privee))
                                     .Select(p => new
                                     {
                                         Publication = p,
                                         Likes = p.publicationLikes.Select(pl => pl.utilisateur).ToList(),
                                         Randonnee = _context.randonneeAnglais.Where(r => r.id == p.randonneeId).Select(r => new Randonnee
                                         {
                                             id = r.id,
                                             nom = r.nom,
                                             description = r.description,
                                             emplacement = r.emplacement,
                                             typeRandonnee = r.typeRandonnee,
                                             etatRandonnee = r.etatRandonnee,
                                             GPS = r.GPS,
                                             commentaires = r.commentaires
                                         }).FirstOrDefault()
                                     }).ToListAsync();
#pragma warning restore CS8619 // La nullabilité des types référence dans la valeur ne correspond pas au type cible.
            }


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
                    gps = gpsData.Where(g => g.publicationId == item.Publication.id).Select(g => g.gpsListe).FirstOrDefault(),
                    favoris = false
                },
                randonneeId = item.Publication.randonneeId,
                utilisateurId = item.Publication.utilisateurId,
                listLike = item.Likes,
                utilisateur = item.Publication.utilisateur,
                utilisateurActuel = userCourant
            }).ToList();
            resultList = resultList.OrderByDescending(p => p.id).ToList();
            return resultList;
        }

        public async Task<ActionResult<IEnumerable<PublicationDTOSend>>> GetPublications(Utilisateur user, string language)
        {
            var likesData = await _context.Like
                     .Include(pu => pu.utilisateur)
                     .ToListAsync();

            var gpsData = await _context.utilisateursTrace.Where(p => p.publicationId != null).ToListAsync();

            var publications = await _context.publication
                            .Where(p => p.etat == EtatPublication.Publique || (p.utilisateur.id == user.id && p.etat == EtatPublication.Privee))
                            .Select(p => new PublicationResult
                            {
                                Publication = p,
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
                                        Likes = p.publicationLikes.Select(pl => pl.utilisateur).ToList(),
                                        Randonnee = p.randonnee
                                    }).ToListAsync();

            if (language == "en")
            {
#pragma warning disable CS8619 // La nullabilité des types référence dans la valeur ne correspond pas au type cible.
                list = await _context.publication
                                     .Include(p => p.publicationLikes)
                                     .ThenInclude(pl => pl.utilisateur)
                                     .Where(p => p.etat == EtatPublication.Publique || (p.utilisateur.id == user.id && p.etat == EtatPublication.Privee))
                                     .Select(p => new
                                     {
                                         Publication = p,
                                         Likes = p.publicationLikes.Select(pl => pl.utilisateur).ToList(),
                                         Randonnee = _context.randonneeAnglais.Where(r => r.id == p.randonneeId).Select(r => new Randonnee
                                         {
                                             id = r.id,
                                             nom = r.nom,
                                             description = r.description,
                                             emplacement = r.emplacement,
                                             typeRandonnee = r.typeRandonnee,
                                             etatRandonnee = r.etatRandonnee,
                                             GPS = r.GPS,
                                             commentaires = r.commentaires
                                         }).FirstOrDefault()
                                     }).ToListAsync();
            }
#pragma warning restore CS8619 // La nullabilité des types référence dans la valeur ne correspond pas au type cible.

                var resultList = list.Select(item => new PublicationDTOSend
                {
                id = item.Publication.id,
                etat = item.Publication.etat,
                randonnee = new RandonneeDetailDTO
                {
                    id = item.Randonnee.id,
                    nom = item.Randonnee.nom,
                    description = item.Randonnee.description,
                    emplacement = item.Randonnee.emplacement,
                    typeRandonnee = (int)item.Publication.randonnee.typeRandonnee,
                    gps = gpsData.Where(g => g.publicationId == item.Publication.id).Select(g => g.gpsListe).FirstOrDefault(),
                    favoris = false
                },
                randonneeId = item.Randonnee.id,
                utilisateurId = item.Publication.utilisateurId,
                listLike = item.Likes,
                utilisateur = item.Publication.utilisateur,
                utilisateurActuel = user
            }).ToList();
            resultList = resultList.OrderByDescending(p => p.id).ToList();
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
