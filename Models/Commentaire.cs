namespace arsoudeServeur.Models
{
    public class Commentaire
    {
        public int id { get; set; }
        public string texte { get; set; }

        // Clé étrangère 
        public int randonnéeId { get; set; }
        public virtual Randonnée randonnée { get; set; }

        // Clé étrangère 
        public int utilisateurId { get; set; }
        public virtual Utilisateur utilisateur { get; set; }
    }
}
