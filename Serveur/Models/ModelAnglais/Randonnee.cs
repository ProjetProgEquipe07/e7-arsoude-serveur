using System.ComponentModel.DataAnnotations;

namespace arsoudeServeur.Models
{
    public class RandonneeAnglais
    {
        public int id { get; set; }

        public string nom { get; set; }

        public string description { get; set; }

        public string emplacement { get; set; }

        public Type typeRandonnee { get; set; }

        public bool approuve { get; set; } = false;

        [Required(ErrorMessage = "La propriété est obligatoire.")]
        public virtual List<GPS> GPS { get; set; } = new List<GPS>();

        //public virtual int? imageId { get; set; }
        [Required(ErrorMessage = "La propriété est obligatoire.")]
        public virtual Image image { get; set; }




        public enum Type
        {
            Marche,
            Vélo
        }


        // Clé étrangère 
        public virtual Randonnee randonneeId { get; set; }
        public virtual int utilisateurId { get; set; }
        public virtual Utilisateur utilisateur { get; set; }

    }
}
