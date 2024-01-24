using System.ComponentModel.DataAnnotations;

namespace arsoudeServeur.Models.DTOs
{
    public class RegisterDTO
    {
        //Obligatoire 
        [Required(ErrorMessage = "La propriété est obligatoire.")]
        [MaxLength(40, ErrorMessage = "La longueur maximale est de 40 caractères.")]
        [MinLength(2, ErrorMessage = "La longueur minimale est de 2 caractères.")]
        public string nom { get; set; }

        [Required(ErrorMessage = "La propriété est obligatoire.")]
        [MaxLength(40, ErrorMessage = "La longueur maximale est de 40 caractères.")]
        [MinLength(2, ErrorMessage = "La longueur minimale est de 2 caractères.")]
        public string prénom { get; set; }

        [Required(ErrorMessage = "La propriété est obligatoire.")]
        public string courriel { get; set; }
        [Required(ErrorMessage = "La propriété est obligatoire.")]
        public string motDePasse { get; set; }
        [Required(ErrorMessage = "La propriété est obligatoire.")]
        public string confirmationMotDePasse { get; set; }

        // TODO : vérifier si c'est 6 carac
        [Required(ErrorMessage = "La propriété est obligatoire.")]
        public string codePostal { get; set; }

        //Optionnel
        public string adresse { get; set; }

        // TODO : doit être valide (currentYear - 100)
        public int anneeDeNaissance { get; set; }
        // TODO : doit être valide (1-12)
        public int moisDeNaissance { get; set; }
    }
}
