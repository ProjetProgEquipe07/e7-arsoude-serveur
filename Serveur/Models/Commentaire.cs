using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace arsoudeServeur.Models
{
    public class Commentaire
    {
        public int id { get; set; }

        //le titre est pas demandé me semble (j'ai demandé à PO et si on l'a pas noté on le met pas)

        //TODO: mettre une propriété pour la date de création
        //TODO: mettre une propriété pour la date de modification
        //TODO: mettre une propriété pour la date de suppression
        //TODO: mettre une propriété pour le nom complet de la personne prénom + " " + nom 

        public string message { get; set; } = "";

        public int? note { get; set; }

        public bool isDeleted { get; set; } = false;

        // Clé étrangère 
        //Montrer juste des coeurs
        //0 ou 1 et +
        public virtual List<Utilisateur>? utilisateursLikes { get; set; }

        // Clé étrangère 
        public int? randonneeId { get; set; }
        [JsonIgnore]
        public virtual Randonnee? randonnee { get; set; }

        //Afficher prénom + nom
        // Clé étrangère 
        [JsonIgnore]
        public int? utilisateurId { get; set; }
        public virtual Utilisateur? utilisateur { get; set; }
    }
}
