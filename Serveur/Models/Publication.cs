using arsoudeServeur.Models.DTOs;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.ComponentModel.DataAnnotations.Schema;

namespace arsoudeServeur.Models
{
    public class Publication
    {
        public int id { get; set; }

        public EtatPublication etat { get; set; }

        public virtual List<PublicationUtilisateur> publicationLikes { get; set; } = new List<PublicationUtilisateur>();

        public virtual int randonneeId { get; set; } 
        public virtual int utilisateurId { get; set; }


        // Clé étrangère
        public virtual Randonnee randonnee { get; set; }
        public virtual Utilisateur utilisateur { get; set; }


        public enum EtatPublication
        {
            Privee,
            Publique,
        }
    }
}
