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

        public async Task<IEnumerable<Publication>> GetPublicationsUser(int utilisateurId)
        {
            Utilisateur user = await _context.utilisateurs.Where(u => u.id == utilisateurId).FirstOrDefaultAsync();

            var list = await _context.publication.Where(p => (p.etat == EtatPublication.Publique && p.utilisateurId == user.id) ||(p.utilisateur.id == user.id && p.etat == EtatPublication.Privée)).ToListAsync();

            return list;
           
        }

        public async Task<ActionResult<IEnumerable<Publication>>> GetPublications(Utilisateur user)
        {
            var list = await _context.publication.Where(p => p.etat == EtatPublication.Publique || (p.utilisateur.id == user.id && p.etat == EtatPublication.Privée)).ToListAsync();
            return list;
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
