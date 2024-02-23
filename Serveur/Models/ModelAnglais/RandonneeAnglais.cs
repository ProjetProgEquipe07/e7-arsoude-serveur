using System.ComponentModel.DataAnnotations;
using static arsoudeServeur.Models.Randonnee;

namespace arsoudeServeur.Models
{
    public class RandonneeAnglais
    {
        public int id { get; set; }

        public string? nom { get; set; }

        public string? description { get; set; }

        public string? emplacement { get; set; }

        public Randonnee.Type typeRandonnee { get; set; }

        public Etat etatRandonnee { get; set; } = Etat.Privée;

        [Required(ErrorMessage = "La propriété est obligatoire.")]
        public virtual List<GPS> GPS { get; set; } = new List<GPS>();

        public virtual List<Commentaire> commentaires { get; set; } = new List<Commentaire>();
 
        // Clé étrangère 
        public virtual int randonneeId { get; set; }
        public virtual Randonnee randonnee { get; set; }
        public virtual int utilisateurId { get; set; }
        public virtual Utilisateur utilisateur { get; set; }
  

    }
}
