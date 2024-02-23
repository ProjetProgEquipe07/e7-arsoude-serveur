using System.ComponentModel.DataAnnotations;

namespace arsoudeServeur.Models.DTOs
{
    public class EditProfilDTO
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string nom { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string prenom { get; set; }

        [Required]
        public string codePostal { get; set; }

        public string? adresse { get; set; }

        [Range(0,12)]
        public int? moisDeNaissance { get; set; }

        [YearRange]
        public int? anneeDeNaissance { get; set; }
    }
}
