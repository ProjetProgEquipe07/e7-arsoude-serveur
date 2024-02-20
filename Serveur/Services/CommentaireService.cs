using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudServeur.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
                    utilisateursLikes = new List<Utilisateur>(),
                });
                _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Vous devez faire la randonnée ou avez déjà commenté cette randonnée");
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
                    utilisateursLikes = commentaire.utilisateursLikes,
                });

                _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Vous n'êtes pas autorisé à modifier ce commentaire");
            }

        }

        public void DeleteCommentaire(int commentaireId, Utilisateur utilisateurCourant)
        {
            var commentaire = _context.commentaires.Where(c => c.id == commentaireId).FirstOrDefault() ?? throw new Exception("Le commentaire n'existe pas");
            if (commentaire.isDeleted == true)
            {
                throw new Exception("Ce commentaire a déjà été effacé");
            }

            //Change le message du commentaire selon si c'est admin ou utilisateur qui a effacé et empêche les autres utilisateurs d'effacer le commentaire
            if (utilisateurCourant.role == "Administrator")
            {
                commentaire.message = "Ce commentaire a été effacé par un Administrateur";
            }
            else if (utilisateurCourant.id == commentaire.utilisateurId)
            {
                commentaire.message = $"Ce commentaire a été effacé par {utilisateurCourant.prenom} {utilisateurCourant.nom}";
            }
            else
            {
                throw new UnauthorizedAccessException("Vous n'êtes pas autorisé à supprimer ce commentaire");
            }

            //Enlève la note pour ne pas affecter les scores et dit que le commentaire est effacé pour la gestion
            commentaire.note = null;
            commentaire.isDeleted = true;

            _context.commentaires.Update(commentaire);
            _context.SaveChangesAsync();
        }

        public bool PeutCommenter(int randoId, Utilisateur utilisateurCourant)
        {
            var utilisateurTrace = _context.utilisateursTrace.Where(r => r.utilisateurId == utilisateurCourant.id).FirstOrDefault();
            var rando = _context.randonnees.Where(r => r.id == randoId).FirstOrDefault() ?? throw new Exception("La randonnée n'existe pas");
            var userRandoComms = rando.commentaires.Where(c => c.utilisateurId == utilisateurCourant.id);
            //Si pas fait randonnée ou déjà commenté la randonnée et que le commentaire est pas effacé, alors pas autorisé à commenter
            if (utilisateurTrace == null ||
                (userRandoComms.Count() > 0 && userRandoComms.Where(c => c.isDeleted == false).Count() > 0))
            {
                //Debug Console
                //userRandoComms.ToList().ForEach(c => Console.WriteLine(c.id + "\n" + c.utilisateur!.courriel + "\n" + c.message + "\n" + c.note + "\n" + c.isDeleted));
                return false;
            }
            return true;
        }

        public async Task AjouteLikeCommentaire(int id, Utilisateur utilisateurCourant)
        {
            var commentaire = _context.commentaires.Where(c => c.id == id).FirstOrDefault() ?? throw new Exception("Le commentaire n'existe pas");
            var listeUser = commentaire.utilisateursLikes ?? throw new Exception("Utilisateurs non trouvés");
            if (listeUser.Contains(utilisateurCourant))
            {
                throw new Exception("Vous avez déjà like ce commentaire");
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
            var listeUser = commentaire.utilisateursLikes ?? throw new Exception("Utilisateurs non trouvés");
            if (!listeUser.Contains(utilisateurCourant))
            {
                throw new Exception("Vous avez déjà enlevé votre like de ce commentaire");
            }
            else
            {
                commentaire.utilisateursLikes.Remove(utilisateurCourant);
            }
            await _context.SaveChangesAsync();
        }
    }
}
