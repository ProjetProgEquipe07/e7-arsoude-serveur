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
            //var utilisateurTrace = _context.utilisateursTrace.Where(r => r.utilisateurId == utilisateurCourant.id).FirstOrDefault();

            //if (utilisateurTrace != null)
            //{

            //}

            var rando = _context.randonnees.Where(r => r.id == commentaire.randoId).FirstOrDefault() ?? throw new Exception("Randonnée non trouvée");
            _context.commentaires.Add(new Commentaire()
            {
                message = commentaire.message,
                note = commentaire.note,
                randonnee = rando,
                randonneeId = rando.id,
                utilisateur = utilisateurCourant,
                utilisateurId = utilisateurCourant.id
            });

            _context.SaveChangesAsync();
        }

        public void PutCommentaire(int id, CommentaireDTO commentaireDTO, Utilisateur utilisateurCourant)
        {
            var rando = _context.randonnees.Where(r => r.id == commentaireDTO.randoId).FirstOrDefault();
            var commentaire = _context.commentaires.Where(c => c.id == id).FirstOrDefault();
            if (utilisateurCourant.id == commentaire.utilisateurId /*|| utilisateurCourant.role == "Administrator"*/)
            {
                _context.commentaires.Update(new Commentaire()
                {
                    id = id,
                    message = commentaire.message,
                    utilisateur = utilisateurCourant,
                    note = commentaire.note,
                    randonnee = rando,
                    randonneeId = rando.id,
                    utilisateurId = utilisateurCourant.id
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
            var commentaire = _context.commentaires.Where(c => c.id == id).FirstOrDefault() ?? throw new Exception("Commentaire non trouvé");

            //Empêche l'utilisateur d'effacer les commentaires des autres, à part si il est Administrateur
            //TODO: Tester si la condition est correct si || marche ou si il faut &&
            if (utilisateurCourant.id != commentaire.utilisateurId || utilisateurCourant.role != "Administrator")
            {
                throw new UnauthorizedAccessException("Vous n'êtes pas autorisé à supprimer ce commentaire");
            }

            Commentaire deletedCommentaire = new Commentaire() { note = 0 };
            if (utilisateurCourant.role != "Administrator")
            {
                deletedCommentaire.message = $"Ce commentaire a été effacé par {utilisateurCourant.prenom} {utilisateurCourant.nom}";
            }

            if (utilisateurCourant.role == "Administrator")
            {
                deletedCommentaire.message = "Ce commentaire a été effacé par un Administrateur";
            }

            _context.commentaires.Update(commentaire).State = EntityState.Modified;

            _context.SaveChangesAsync();
        }
        public bool PeutCommenter(int randoId, Utilisateur utilisateurCourant)
        {
            var utilisateurTrace = _context.utilisateursTrace.Where(r => r.utilisateurId == utilisateurCourant.id).FirstOrDefault();
            var rando = _context.randonnees.Where(r => r.id == randoId).FirstOrDefault() ?? throw new Exception("Randonnée n'existe pas");
            var comm = rando.commentaires.Where(c => c.utilisateurId == utilisateurCourant.id);
            if (utilisateurTrace == null || comm != null)
            {
                return false;
            }
            return true;
        }
    }
}
