using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Models.ModelAnglais;
using arsoudServeur.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using System;

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

    ///// <summary>
    ///// 
    ///// </summary>
    //public class  : Exception { }

    ///// <summary>
    ///// 
    ///// </summary>
    //public class  : Exception { }

    ///// <summary>
    ///// 
    ///// </summary>
    //public class  : Exception { }

    ///// <summary>
    ///// 
    ///// </summary>
    //public class  : Exception { }

    public class CommentaireService
    {
        private ApplicationDbContext _context;
        private ServiceTranslate _serviceTranslate;
        public CommentaireService(ApplicationDbContext context, ServiceTranslate serviceTranslate)
        {
            _context = context;
            _serviceTranslate = serviceTranslate;
        }

        public async Task<List<Commentaire>> GetCommentaires(int randonneId, string language)
        {
            var randonnee = await _context.randonnees.Where(r => r.id == randonneId).FirstOrDefaultAsync() ?? throw new NullRandonneeException();

            var list = randonnee.commentaires; //order by published date ?

            if(language == "en")
            {
                var commentaireAng = await _context.commentaireAnglais.Where(c => c.randonneeId == randonneId).ToListAsync();

                list = list.Select(c => new Commentaire()
                {
                    id = c.id,
                    message = commentaireAng.Where(p => p.commentaireId == c.id).Select(p => p.message).FirstOrDefault(),
                    note = c.note,
                    isDeleted = c.isDeleted,
                    randonneeId = c.randonneeId,
                    randonnee = c.randonnee,
                    utilisateurId = c.utilisateurId,
                    utilisateur = c.utilisateur,
                    utilisateursLikes = c.utilisateursLikes
                }).ToList();
            }

            return list;
        }

        public async Task<Commentaire> CreateCommentaire(CommentaireDTO commentaire, Utilisateur utilisateurCourant)
        {
            var rando = await _context.randonnees.Where(r => r.id == commentaire.randonneeId).FirstOrDefaultAsync() ?? throw new NullRandonneeException();
            var peutCommenter = await PeutCommenter(rando.id, utilisateurCourant);
            if (peutCommenter)
            {
                Commentaire commentFR = new Commentaire
                {
                    message = null,
                    note = commentaire.note,
                    randonnee = rando,
                    randonneeId = rando.id,
                    utilisateur = utilisateurCourant,
                    utilisateurId = utilisateurCourant.id,
                    utilisateursLikes = new List<CommentaireUtilisateur>(),
                };

                CommentaireAnglais commentEn = new CommentaireAnglais
                {
                    message = null,
                    randonnee = rando,
                    randonneeId = rando.id,
                    commentaireId = 0
                };

                IEnumerable<TraductionIndicator> traductionIndicators = new List<TraductionIndicator>();

                traductionIndicators = await _serviceTranslate.DetectLanguage(commentaire);

                if (traductionIndicators.First().targetLanguage == "en")
                {
                    commentEn.message = traductionIndicators.First().text;
                }
                else
                {
                    commentFR.message = traductionIndicators.First().text;
                }

                if (commentEn.message == null)
                {
                    commentEn.message = await _serviceTranslate.TranslateText(traductionIndicators.First().text, "en");
                }
                else
                {
                    commentFR.message = await _serviceTranslate.TranslateText(traductionIndicators.First().text, "fr");
                }

                _context.commentaires.Add(commentFR);
                await _context.SaveChangesAsync();

                commentEn.commentaireId = commentFR.id;

                _context.commentaireAnglais.Add(commentEn);
                await _context.SaveChangesAsync();

                return commentFR;
            }
            else
            {
                throw new Exception("Vous devez faire la randonnée ou avez déjà commenté cette randonnée");
            }

        }

        public async Task<Commentaire> PutCommentaire(int id, CommentaireDTO commentaireDTO, Utilisateur utilisateurCourant)
        {
            var rando = await _context.randonnees.Where(r => r.id == commentaireDTO.randonneeId).FirstOrDefaultAsync() ?? throw new NullRandonneeException();
            var commentaire = await _context.commentaires.Where(c => c.id == id).FirstOrDefaultAsync() ?? throw new NullCommentaireException();
            var commentaireAng = await _context.commentaireAnglais.Where(c => c.commentaireId == id).FirstOrDefaultAsync();
            //Seulement l'utilisateur peut modifier le commentaire
            if (utilisateurCourant.id == commentaire.utilisateurId)
            {
                commentaire.message = commentaireDTO.message;
                commentaireAng.message = commentaireDTO.message;
                commentaire.note = commentaireDTO.note;

                _context.commentaires.Update(commentaire);
                _context.commentaireAnglais.Update(commentaireAng);

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
            var commentaire = await _context.commentaires.Where(c => c.id == commentaireId).FirstOrDefaultAsync() ?? throw new NullCommentaireException();
            var commentaireAng =  await _context.commentaireAnglais.Where(c => c.commentaireId == commentaireId).FirstOrDefaultAsync(); 

            if (commentaire.isDeleted == true)
            {
                throw new AlreadyDeletedException();
            }

            //Change le message du commentaire selon si c'est admin ou utilisateur qui a effacé et empêche les autres utilisateurs d'effacer le commentaire
            if (utilisateurCourant.role == "Administrator")
            {
                commentaire.message = "$CommentDeletedByAdministrator";
                commentaireAng.message = "$CommentDeletedByAdministrator";
            }
            else if (utilisateurCourant.id == commentaire.utilisateurId)
            {
                commentaire.message = "$CommentDeletedByUserFirstNameLastName";
                commentaireAng.message = "$CommentDeletedByUserFirstNameLastName";
            }
            else
            {
                throw new UnauthorizedDeleteCommentaireException();
            }

            //Enlève la note pour ne pas affecter les scores et dit que le commentaire est effacé pour la gestion
            commentaire.note = null;
            commentaire.isDeleted = true;

            _context.commentaires.Update(commentaire);
            _context.commentaireAnglais.Update(commentaireAng);
            await _context.SaveChangesAsync();

            return commentaire;
        }

        public async Task<bool> PeutCommenter(int randoId, Utilisateur utilisateurCourant)
        {
            var rando = await _context.randonnees.Where(r => r.id == randoId).FirstOrDefaultAsync();
            if (rando == null)
            {
                throw new NullRandonneeException();
            }

            //Si randonnée est publique on peut commenter
            if (rando.etatRandonnee == Randonnee.Etat.Publique)
            {
                //Si fait randonnée et que le commentaire est effacé ou non existant, alors autorisé à commenter

                var utilisateurTrace = await _context.utilisateursTrace.Where(r => r.utilisateurId == utilisateurCourant.id).FirstOrDefaultAsync();
                if (utilisateurTrace == null)
                {
                    //Debug Console
                    //userRandoComms.ToList().ForEach(c => Console.WriteLine(c.id + "\n" + c.utilisateur!.courriel + "\n" + c.message + "\n" + c.note + "\n" + c.isDeleted));
                    throw new NoTraceFoundException();
                }

                var userRandoComms = rando.commentaires.Where(c => c.utilisateurId == utilisateurCourant.id);
                if (userRandoComms.Any(c => c.isDeleted == false))
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
        public async Task AjoutLikeCommentaire(int id, Utilisateur utilisateurCourant)
        {
            var commentaire = await _context.commentaires.Where(c => c.id == id).FirstOrDefaultAsync() ?? throw new NullCommentaireException();
            var listeUser = commentaire.utilisateursLikes;
            if (listeUser.Where(CU => CU.utilisateurId == utilisateurCourant.id).FirstOrDefault() != null)
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
            }
            await _context.SaveChangesAsync();
        }
        public async Task EnleveLikeCommentaire(int id, Utilisateur utilisateurCourant)
        {
            var commentaire = await _context.commentaires.Where(c => c.id == id).FirstOrDefaultAsync() ?? throw new NullCommentaireException();
            var listeUser = commentaire.utilisateursLikes ?? throw new Exception("Utilisateurs non trouvés");
            CommentaireUtilisateur likeCheck = listeUser.Where(CU => CU.utilisateurId == utilisateurCourant.id).FirstOrDefault() ?? throw new Exception("");
            if (likeCheck != null)
            {
                commentaire.utilisateursLikes.Remove(likeCheck);
            }
            else
            {
                throw new AlreadyUnlikedCommentaireException();
            }
            await _context.SaveChangesAsync();
        }
    }
}
