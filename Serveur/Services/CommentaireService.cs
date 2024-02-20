using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudServeur.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace arsoudeServeur.Services
{
    public class CommentaireService
    {
        private ApplicationDbContext _context;
        public CommentaireService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Commentaire> GetCommentaires(int id)
        {
            var list = _context.randonnees.Where(r => r.id == id).FirstOrDefault().commentaires;

            return list;
        }

        public void CreateCommentaire(CommentaireDTO commentaire, Utilisateur utilisateurCourant)
        {
            var rando = _context.randonnees.Where(r => r.id == commentaire.randonneeId).FirstOrDefault() ?? throw new Exception("Randonnée non trouvée");
            if (PeutCommenter(rando.id, utilisateurCourant))
            {
                _context.commentaires.Add(new Commentaire()
                {
                    message = commentaire.message,
                    note = commentaire.note,
                    randonnee = rando,
                    randonneeId = rando.id,
                    utilisateur = utilisateurCourant,
                    utilisateurId = utilisateurCourant.id,
                });
                _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Vous n'êtes pas autorisé à commenter cette randonnée (Vous devez faire la randonnée ou avez déjà commenté cette randonnée)");
            }

        }

        public void PutCommentaire(int id, CommentaireDTO commentaireDTO, Utilisateur utilisateurCourant)
        {
            var rando = _context.randonnees.Where(r => r.id == commentaireDTO.randonneeId).FirstOrDefault() ?? throw new Exception("La randonnée n'existe pas");
            var commentaire = _context.commentaires.Where(c => c.id == id).FirstOrDefault() ?? throw new Exception("Le commentaire n'existe pas");
            //Seulement l'utilisateur peut modifier le commentaire
            if (utilisateurCourant.id == commentaire.utilisateurId)
            {
                _context.commentaires.Update(new Commentaire()
                {
                    id = id,
                    message = commentaire.message,
                    utilisateur = utilisateurCourant,
                    note = commentaire.note,
                    randonnee = rando,
                    randonneeId = rando.id,
                    utilisateurId = utilisateurCourant.id,
                });

                _context.SaveChangesAsync();
            }
            else
            {
                //Unauthorized ?
            }

        }

        public void DeleteCommentaire(int id, Utilisateur utilisateurCourant)
        {
            var commentaire = _context.commentaires.Where(c => c.id == id).FirstOrDefault() ?? throw new Exception("Le commentaire n'existe pas");

            if (utilisateurCourant.id != commentaire.utilisateurId || utilisateurCourant.role != "Administrator")
            {
                throw new UnauthorizedAccessException("Vous n'êtes pas autorisé à supprimer ce commentaire");
            }
            commentaire.message =
                utilisateurCourant.role == "Administrator" ?
                "Ce commentaire a été effacé par un Administrateur" : $"Ce commentaire a été effacé par {utilisateurCourant.prenom} {utilisateurCourant.nom}";
            commentaire.note = null;
            commentaire.isDeleted = true;

            _context.commentaires.Update(commentaire);
            _context.SaveChangesAsync();
        }

        public bool PeutCommenter(int randoId, Utilisateur utilisateurCourant)
        {
            var utilisateurTrace = _context.utilisateursTrace.Where(r => r.utilisateurId == utilisateurCourant.id).FirstOrDefault();
            var rando = _context.randonnees.Where(r => r.id == randoId).FirstOrDefault() ?? throw new Exception("La randonnée n'existe pas");
            var comm = rando.commentaires.Where(c => c.utilisateurId == utilisateurCourant.id);
            //Si pas fait randonnée ou déjà commenté la randonnée, alors pas autorisé à commenter
            if (utilisateurTrace == null || comm != null) 
            {
                return false;
            }
            return true;
        }
        public async Task AjouteLikeCommentaire(int id, Utilisateur utilisateurCourant)
        {
            var commentaire = _context.commentaires.Where(c => c.id == id).FirstOrDefault() ?? throw new Exception("Le commentaire n'existe pas");
            var listeUser = commentaire.utilisateursLikes;
            if(listeUser != null && listeUser.Contains(utilisateurCourant))
            {
                throw new Exception("Vous avez déjà aimé ce commentaire");
            }
            else
            {
                commentaire.utilisateursLikes.Add(utilisateurCourant);
            }
            await _context.SaveChangesAsync();
        }
        public async void EnleveLikeCommentaire(int id, Utilisateur utilisateurCourant)
        {
            var commentaire = _context.commentaires.Where(c => c.id == id).FirstOrDefault() ?? throw new Exception("Le commentaire n'existe pas");
            var listeUser = commentaire.utilisateursLikes;
            if (listeUser != null && !listeUser.Contains(utilisateurCourant))
            {
                throw new Exception("Vous n'aimez définitivement pas ce commentaire");
            }
            else
            {
                commentaire.utilisateursLikes.Remove(utilisateurCourant);
            }
            await _context.SaveChangesAsync();
        }
    }
}
