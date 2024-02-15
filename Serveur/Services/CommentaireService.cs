using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudServeur.Data;
using Microsoft.AspNetCore.Mvc;

namespace arsoudeServeur.Services
{
    public class CommentaireService
    {
        private ApplicationDbContext _context;
        public CommentaireService(ApplicationDbContext context)
        {
            _context = context;
        }


        public void DeleteCommentaire(int id, Utilisateur utilisateurCourant)
        {
            var commentaire = _context.commentaires.Where(c => c.id == id).FirstOrDefault();
            if (utilisateurCourant.id == commentaire.utilisateurId || utilisateurCourant.role == "Administrator")
            {
                _context.commentaires.Remove(_context.commentaires.Find(id));
                _context.SaveChangesAsync();
            }
            else
            {
                //Vous n'êtes pas l'auteur du commentaire ou vous n'êtes pas un admin
            }
        }

        public IEnumerable<Commentaire> GetCommentaires(int id)
        {
            var list = _context.randonnees.Where(r => r.id == id).FirstOrDefault().commentaires;

            return list;
        }

        public void CreateCommentaire(CommentaireDTO commentaire, Utilisateur utilisateurCourant)
        {
            var rando = _context.randonnees.Where(r => r.id == commentaire.randoId).FirstOrDefault();

            _context.commentaires.Add(new Commentaire()
            {
                texte = commentaire.texte,
                review = commentaire.review,
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
            if (utilisateurCourant.id == commentaire.utilisateurId || utilisateurCourant.role == "Administrator")
            {
                _context.commentaires.Update(new Commentaire()
                {
                    id = id,
                    texte = commentaire.texte,
                    utilisateur = utilisateurCourant,
                    review = commentaire.review,
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
    }
}
