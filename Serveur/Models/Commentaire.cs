using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace arsoudeServeur.Models
{
    public class Commentaire
    {
        public int id { get; set; }

        //TODO?: mettre une propriété pour la date de création
        //TODO?: mettre une propriété pour la date de modification
        //TODO?: mettre une propriété pour la date de suppression
        //TODO?: mettre une propriété pour le nom complet de la personne prénom + " " + nom 

        public string? message { get; set; } = "";

        public int? note { get; set; }

        public bool isDeleted { get; set; } = false;

        // Clé étrangère 
        //Montrer juste des coeurs et les noms des personnes qui ont liké
        //0 ou 1 et +
        public virtual List<CommentaireUtilisateur> utilisateursLikes { get; set; } = new List<CommentaireUtilisateur>();

        // Clé étrangère 
        public int? randonneeId { get; set; }
        [JsonIgnore]
        public virtual Randonnee? randonnee { get; set; }

        //Afficher prénom + nom
        // Clé étrangère 
        public int? utilisateurId { get; set; }
        public virtual Utilisateur? utilisateur { get; set; }
    }
}
