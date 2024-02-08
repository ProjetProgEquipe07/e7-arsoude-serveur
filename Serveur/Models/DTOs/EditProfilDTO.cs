namespace arsoudeServeur.Models.DTOs
{
    public class EditProfilDTO
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string codePostal { get; set; }
        public string? adresse { get; set; }
        public int? moisDeNaissance { get; set; }
        public int? anneeDeNaissance { get; set; }
    }
}
