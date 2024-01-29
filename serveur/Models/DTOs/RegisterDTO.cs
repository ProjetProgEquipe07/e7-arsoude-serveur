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
        [Required(ErrorMessage = "La propriété est obligatoire.")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$", ErrorMessage = "Le code postal doit être sous la forme X1X 1X1.")]
        public string codePostal { get; set; }

        //Optionnel
        public string adresse { get; set; } = null;
        [YearRange(ErrorMessage = "L'année que vous avez entré n'est pas valide")]
        public int? anneeDeNaissance { get; set; }
        [Range(1, 12, ErrorMessage = "La valeur doit être comprise entre 1 et 12.")]
        public int? moisDeNaissance { get; set; }


    }
}