namespace arsoudeServeur.Models
{
    public class Commentaire
    {
        public int id { get; set; }
        public string? texte { get; set; } = "";
        public int review { get; set; } = 0;

        // Clé étrangère 
        public int randonneeId { get; set; }
        public virtual Randonnee randonnee { get; set; }

        // Clé étrangère 
        public int utilisateurId { get; set; }
        public virtual Utilisateur utilisateur { get; set; }
    }
}
