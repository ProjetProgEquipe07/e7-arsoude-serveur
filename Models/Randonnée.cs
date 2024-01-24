namespace arsoudeServeur.Models
{
    public class Randonnée
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }

        public double pointDépart { get; set; }
        public double pointArrivée { get; set; }

        public string difficulté { get; set; }
        public string accessibilité { get; set; }

        public List<Image> listeImage { get; set; }
        public List<GPS> listeGPS { get; set; }

        public bool terminé { get; set; }

        // Clé étrangère 
        public int utilisateurId { get; set; }
        public virtual Utilisateur utilisateur { get; set; }

    }
}
