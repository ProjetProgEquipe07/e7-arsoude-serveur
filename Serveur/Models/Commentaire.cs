using System.Text.Json.Serialization;

namespace arsoudeServeur.Models
{
    public class Commentaire
    {
        public int id { get; set; }
        public string titre { get; set; } = "";
        public string? description { get; set; } = "";
        public int note { get; set; } = 0;
        public Utilisateur[] utilisateursReactions { get; set; }
        // Clé étrangère 
        public int randonneeId { get; set; }
        [JsonIgnore]
        public virtual Randonnee randonnee { get; set; }

        // Clé étrangère 
        public int utilisateurId { get; set; }
        [JsonIgnore]
        public virtual Utilisateur utilisateur { get; set; }
    }
}
