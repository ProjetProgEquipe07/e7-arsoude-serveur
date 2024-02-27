using System.ComponentModel.DataAnnotations;

namespace arsoudeServeur.Models.DTOs
{

        public class RandonneeDTO
        {
            public int id { get; set; }

        [Required(ErrorMessage = "La propriété est obligatoire.")]
        [MaxLength(25, ErrorMessage = "La longueur maximale est de 25 caractères.")]
        [MinLength(2, ErrorMessage = "La longueur minimale est de 2 caractères.")]
        public string nom { get; set; }


        [MaxLength(255, ErrorMessage = "La longueur maximale est de 255 caractères.")]
        [MinLength(10, ErrorMessage = "La longueur minimale est de 10 caractères.")]
        public string description { get; set; }

        [Required(ErrorMessage = "La propriété est obligatoire.")]
        public string emplacement { get; set; }
            // regarder pour bien recevoir le type ( 0 ou 1 )

            public int typeRandonnee { get; set; }

            public List<GPS> gps { get; set; }
        }

    
}
