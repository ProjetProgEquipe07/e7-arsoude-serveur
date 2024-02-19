using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace arsoudeServeur.Models
{
    public class Commentaire
    {
        public int id { get; set; }

        //TODO: le titre est pas demandé me semble
        //[Required(ErrorMessage = "Le titre est obligatoire.")]
        //public string? titre { get; set; }

        public string? message { get; set; }

        public int? note { get; set; }

        // Clé étrangère 
        //Montrer juste des coeurs
        //0 ou 1 et +
        public virtual List<int>? utilisateurIdsLikes { get; set; }

        // Clé étrangère 
        public int? randonneeId { get; set; }
        [JsonIgnore]
        public virtual Randonnee? randonnee { get; set; }

        //Afficher prénom + nom
        // Clé étrangère 
        public int? utilisateurId { get; set; }
        [JsonIgnore]
        public virtual Utilisateur? utilisateur { get; set; }
    }
}
