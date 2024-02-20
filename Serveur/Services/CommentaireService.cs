using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudServeur.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace arsoudeServeur.Services
{ 
    public class NullRandonneeException : Exception { } //"Cette randonnée n'existe pas"

    public class NullCommentaireException : Exception { } //"Ce commentaire n'existe pas"

    public class UnauthorizedCommentaireException : Exception { } //"Vous n'êtes pas autorisé à supprimer ce commentaire"


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
            var rando = _context.randonnees.Where(r => r.id == commentaire.randonneeId).FirstOrDefault() ?? throw new NullRandonneeException();
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
                    utilisateursLikes = new List<CommentaireUtilisateur>(),
                });
                _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Vous devez faire la randonnée ou avez déjà commenté cette randonnée");
            }

        }

        public Commentaire PutCommentaire(int id, CommentaireDTO commentaireDTO, Utilisateur utilisateurCourant)
        {
            var rando = _context.randonnees.Where(r => r.id == commentaireDTO.randonneeId).FirstOrDefault() ?? throw new NullRandonneeException();
            var commentaire = _context.commentaires.Where(c => c.id == id).FirstOrDefault() ?? throw new NullCommentaireException();
            //Seulement l'utilisateur peut modifier le commentaire
            if (utilisateurCourant.id == commentaire.utilisateurId)
            {
                Commentaire newCommentaire = new Commentaire()
                {
                    message = commentaire.message,
                    utilisateur = utilisateurCourant,
                };
                _context.commentaires.Update(newCommentaire);

                _context.SaveChangesAsync();
                
                return newCommentaire;
            }
            else
            {
                throw new Exception("Vous n'êtes pas autorisé à modifier ce commentaire");
            }

        }

        public Commentaire DeleteCommentaire(int commentaireId, Utilisateur utilisateurCourant)
        {
            var commentaire = _context.commentaires.Where(c => c.id == commentaireId).FirstOrDefault() ?? throw new NullCommentaireException();
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
                throw new UnauthorizedCommentaireException();
            }

            //Enlève la note pour ne pas affecter les scores et dit que le commentaire est effacé pour la gestion
            commentaire.note = null;
            commentaire.isDeleted = true;

            _context.commentaires.Update(commentaire);
            _context.SaveChangesAsync();

            return commentaire;
        }

        public bool PeutCommenter(int randoId, Utilisateur utilisateurCourant)
        {
            var rando = _context.randonnees.Where(r => r.id == randoId).FirstOrDefault() ?? throw new NullRandonneeException();
            //On peut commenter seulement si la randonnée est publique
            if (rando.etatRandonnee == Randonnee.Etat.Publique)
            {
                var utilisateurTrace = _context.utilisateursTrace.Where(r => r.utilisateurId == utilisateurCourant.id).FirstOrDefault();
                var userRandoComms = rando.commentaires.Where(c => c.utilisateurId == utilisateurCourant.id);
                //Si pas fait randonnée ou déjà commenté la randonnée et que le commentaire est pas effacé, alors pas autorisé à commenter
                if (utilisateurTrace == null || userRandoComms.Any(c => c.isDeleted == false))
                {
                    //Debug Console
                    //userRandoComms.ToList().ForEach(c => Console.WriteLine(c.id + "\n" + c.utilisateur!.courriel + "\n" + c.message + "\n" + c.note + "\n" + c.isDeleted));
                    return false;
                }
                return true;
            }
            return false;
        }

        public async Task AjouteLikeCommentaire(int id, Utilisateur utilisateurCourant)
        {
            var commentaire = _context.commentaires.Where(c => c.id == id).FirstOrDefault() ?? throw new NullCommentaireException();
            var listeUser = commentaire.utilisateursLikes ?? throw new Exception("Utilisateurs non trouvés");
            if (listeUser.Where(CU => CU.utilisateurId == utilisateurCourant.id).FirstOrDefault() != null)
            {
                throw new Exception("Vous avez déjà like ce commentaire");
            }
            else
            {
                CommentaireUtilisateur temp = new CommentaireUtilisateur()
                {
                    utilisateurId = utilisateurCourant.id,
                    utilisateur = utilisateurCourant,
                    commentaireId = commentaire.id,
                    commentaire = commentaire
                };
                commentaire.utilisateursLikes.Add(temp);
            }
            await _context.SaveChangesAsync();
        }

        public async void EnleveLikeCommentaire(int id, Utilisateur utilisateurCourant)
        {
            var commentaire = _context.commentaires.Where(c => c.id == id).FirstOrDefault() ?? throw new NullCommentaireException();
            var listeUser = commentaire.utilisateursLikes ?? throw new Exception("Utilisateurs non trouvés");
            CommentaireUtilisateur likeCheck = listeUser.Where(CU => CU.utilisateurId == utilisateurCourant.id).FirstOrDefault() ?? throw new Exception("");
            if (likeCheck != null)
            {
                commentaire.utilisateursLikes.Remove(likeCheck);
            }
            else
            {
                throw new Exception("Vous avez déjà enlevé votre like de ce commentaire");
            }
            await _context.SaveChangesAsync();
        }
    }
}
