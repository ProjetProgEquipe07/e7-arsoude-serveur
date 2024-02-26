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
    /// <summary>
    /// Ce commentaire n'existe pas
    /// </summary>
    public class NullCommentaireException : Exception { }

    /// <summary>
    /// Cette randonnée n'existe pas
    /// </summary>
    public class NullRandonneeException : Exception { }

    /// <summary>
    /// Utilisateurs non trouvés
    /// </summary>
    public class NullUtilisateursException : Exception { }

    /// <summary>
    /// Vous n'êtes pas autorisé à créer ce commentaire
    /// </summary>
    public class UnauthorizedCreateCommentaireException : Exception { }

    /// <summary>
    /// Vous n'êtes pas autorisé à supprimer ce commentaire
    /// </summary>
    public class UnauthorizedDeleteCommentaireException : Exception { }

    /// <summary>
    /// Vous n'êtes pas autorisé à modifier ce commentaire
    /// </summary>
    public class UnauthorizedModifyCommentaireException : Exception { }

    /// <summary>
    /// Ce commentaire a déjà été effacé
    /// </summary>
    public class AlreadyDeletedException : Exception { }

    /// <summary>
    /// Un commentaire à déjà été fait par l'utilisateur dans la randonnée
    /// </summary>
    public class AlreadyExistsCommentaireExeption : Exception { }

    /// <summary>
    /// Vous avez déjà like ce commentaire
    /// </summary>
    public class AlreadyLikedCommentaireException : Exception { }

    /// <summary>
    /// Vous avez déjà enlevé votre like de ce commentaire
    /// </summary>
    public class AlreadyUnlikedCommentaireException : Exception { }

    /// <summary>
    /// Pas fait le tracé de la randonnée
    /// </summary>
    public class NoTraceFoundException : Exception { }

    /// <summary>
    /// La randonnée n'est pas publique donc on ne peut pas commenter
    /// </summary>
    public class RandonneeNotPublicException : Exception { }


    public class CommentaireService
    {
        private ApplicationDbContext _context;
        public CommentaireService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Commentaire>> GetCommentaires(int randonneId)
        {
            Randonnee? randonnee = await _context.randonnees.SingleOrDefaultAsync(r => r.id == randonneId);
            if (randonnee == null)
            {
                throw new NullRandonneeException();
            }

            List<Commentaire> list = randonnee.commentaires;

            return list;
        }

        public async Task<Commentaire> CreateCommentaire(CommentaireDTO commentaire, Utilisateur utilisateurCourant)
        {
            Randonnee? rando = await _context.randonnees.SingleOrDefaultAsync(r => r.id == commentaire.randonneeId);
            if (rando == null)
            {
                throw new NullRandonneeException();
            }

            try
            {
                var peutCommenter = await PeutCommenter(rando.id, utilisateurCourant);
                if (peutCommenter)
                {
                    var newCommentaire = new Commentaire()
                    {
                        message = commentaire.message,
                        note = commentaire.note,
                        randonnee = rando,
                        randonneeId = rando.id,
                        utilisateur = utilisateurCourant,
                        utilisateurId = utilisateurCourant.id,
                        utilisateursLikes = new List<CommentaireUtilisateur>(),
                    };

                    await _context.commentaires.AddAsync(newCommentaire);
                    await _context.SaveChangesAsync();

                    return newCommentaire;
                }
                else
                {
                    throw new UnauthorizedCreateCommentaireException();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Commentaire> PutCommentaire(int id, CommentaireDTO commentaireDTO, Utilisateur utilisateurCourant)
        {
            Randonnee? rando = await _context.randonnees.SingleOrDefaultAsync(r => r.id == commentaireDTO.randonneeId);
            if (rando == null)
            {
                throw new NullRandonneeException();
            }
            Commentaire? commentaire = await _context.commentaires.SingleOrDefaultAsync(c => c.id == id);
            if (commentaire == null)
            {
                throw new NullCommentaireException();
            }

            //Seulement l'utilisateur peut modifier le commentaire
            if (utilisateurCourant.id == commentaire.utilisateurId)
            {
                commentaire.message = commentaireDTO.message;
                commentaire.note = commentaireDTO.note;

                await _context.SaveChangesAsync();

                return commentaire;
            }
            else
            {
                throw new UnauthorizedModifyCommentaireException();
            }

        }

        public async Task<Commentaire> DeleteCommentaire(int commentaireId, Utilisateur utilisateurCourant)
        {
            Commentaire? commentaire = await _context.commentaires.SingleOrDefaultAsync(c => c.id == commentaireId);
            if (commentaire == null)
            {
                throw new NullCommentaireException();
            }
            if (commentaire.isDeleted == true)
            {
                throw new AlreadyDeletedException();
            }

            //Change le message du commentaire selon si c'est admin ou utilisateur qui a effacé et empêche les autres utilisateurs d'effacer le commentaire
            if (utilisateurCourant.role == "Administrator")
            {
                commentaire.message = "CommentDeletedByAdministrator";
            }
            else if (utilisateurCourant.id == commentaire.utilisateurId)
            {
                commentaire.message = "CommentDeletedByUserFirstNameLastName";
            }
            else
            {
                throw new UnauthorizedDeleteCommentaireException();
            }

            //Enlève la note pour ne pas affecter les scores et dit que le commentaire est effacé pour la gestion
            commentaire.note = null;
            commentaire.isDeleted = true;

            _context.commentaires.Update(commentaire);
            await _context.SaveChangesAsync();

            return commentaire;
        }

        public async Task<bool> PeutCommenter(int randoId, Utilisateur utilisateurCourant)
        {
            Randonnee? rando = await _context.randonnees.SingleOrDefaultAsync(r => r.id == randoId);
            if (rando == null)
            {
                throw new NullRandonneeException();
            }

            //Si randonnée est publique on peut commenter
            if (rando.etatRandonnee == Randonnee.Etat.Publique)
            {
                //Si fait randonnée et que le commentaire est effacé ou non existant, alors autorisé à commenter
                RandonneeUtilisateurTrace? utilisateurTrace = await _context.utilisateursTrace.Where(r => r.utilisateurId == utilisateurCourant.id).SingleOrDefaultAsync();
                if (utilisateurTrace == null)
                {
                    //Debug Console
                    //userRandoComms.ToList().ForEach(c => Console.WriteLine(c.id + "\n" + c.utilisateur!.courriel + "\n" + c.message + "\n" + c.note + "\n" + c.isDeleted));
                    throw new NoTraceFoundException();
                }

                IEnumerable<Commentaire>? userRandoComms = rando.commentaires.Where(c => c.utilisateurId == utilisateurCourant.id);
                if (userRandoComms.SingleOrDefault(c => c.isDeleted == false) != null)
                {
                    throw new AlreadyExistsCommentaireExeption();
                }

                return true;
            }
            else
            {
                throw new RandonneeNotPublicException();
            }
        }
        public async Task<List<CommentaireUtilisateur>> AjoutLikeCommentaire(int id, Utilisateur utilisateurCourant)
        {
            Commentaire? commentaire = await _context.commentaires.SingleOrDefaultAsync(c => c.id == id);
            if (commentaire == null)
            {
                throw new NullCommentaireException();
            }

            List<CommentaireUtilisateur> listeUser = commentaire.utilisateursLikes;
            //Si l'utilisateur a déjà liké le commentaire renvoie une exception
            if (listeUser.SingleOrDefault(CU => CU.utilisateurId == utilisateurCourant.id) != null)
            {
                throw new AlreadyLikedCommentaireException();
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
                await _context.SaveChangesAsync();

                return listeUser;
            }

        }
        public async Task<List<CommentaireUtilisateur>> EnleveLikeCommentaire(int id, Utilisateur utilisateurCourant)
        {
            var commentaire = await _context.commentaires.SingleOrDefaultAsync(c => c.id == id);
            if (commentaire == null)
            {
                throw new NullCommentaireException();
            }
            var listeUser = commentaire.utilisateursLikes;
            CommentaireUtilisateur? likeCheck = listeUser.SingleOrDefault(CU => CU.utilisateurId == utilisateurCourant.id);
            if (likeCheck == null)
            {
                throw new AlreadyUnlikedCommentaireException();
            }
            else
            {
                commentaire.utilisateursLikes.Remove(likeCheck);
                await _context.SaveChangesAsync();

                return listeUser;
            }
        }
    }
}
