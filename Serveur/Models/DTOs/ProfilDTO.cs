namespace arsoudeServeur.Models.DTOs
{
    public class ProfilDTO
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string courriel { get; set; }
        public string codePostal { get; set; }
        public List<RandonneeUtilisateur> favoris { get; set; }
        public string? adresse { get; set; }
        public int? moisDeNaissance { get; set; }
        public int? anneeDeNaissance { get; set; }
    }
}
