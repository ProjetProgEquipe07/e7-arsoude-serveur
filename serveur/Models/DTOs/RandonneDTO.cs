﻿using System.ComponentModel.DataAnnotations;

namespace arsoudeServeur.Models.DTOs
{
    public class RandonneDTO
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
            public Type TypeRandonnée { get; set; }

            //public virtual int? imageId { get; set; }
            [Required(ErrorMessage = "La propriété est obligatoire.")]
            public virtual Image image { get; set; }


            public enum Type
            {
                Marche,
                Vélo
            }

    }
}