using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace arsoudeServeur.Models
{
    public class Randonnee
    {
        public int id { get; set; }

        [Required(ErrorMessage = "La propriété est obligatoire.")]
        [MaxLength(25, ErrorMessage = "La longueur maximale est de 25 caractères.")]
        [MinLength(2, ErrorMessage = "La longueur minimale est de 2 caractères.")]
        public string? nom { get; set; }

        [MaxLength(255, ErrorMessage = "La longueur maximale est de 255 caractères.")]
        [MinLength(10, ErrorMessage = "La longueur minimale est de 10 caractères.")]
        public string? description { get; set; }

        [Required(ErrorMessage = "La propriété est obligatoire.")]
        public string? emplacement { get; set; }
        public Type typeRandonnee { get; set; }

        [Required(ErrorMessage = "La propriété est obligatoire.")]
        public virtual List<GPS> GPS { get; set; } = new List<GPS>();

        [JsonIgnore]
        public virtual List<Commentaire> commentaires { get; set; } = new List<Commentaire>();

        //public virtual int? imageId { get; set; }
        [Required(ErrorMessage = "La propriété est obligatoire.")]
        public virtual Image image { get; set; }

        public Etat etatRandonnee { get; set; } = Etat.Privée;
        
        public enum Etat
        {
            Privée,
            Publique,
            Refusée
        }

        public enum Type
        {
            Marche,
            Vélo
        }


        // Clé étrangère 
        public virtual int utilisateurId { get; set; }
        [JsonIgnore]
        public virtual Utilisateur utilisateur { get; set; }

    }
}
