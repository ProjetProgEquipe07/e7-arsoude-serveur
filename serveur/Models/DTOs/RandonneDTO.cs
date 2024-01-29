﻿using System.ComponentModel.DataAnnotations;

namespace arsoudeServeur.Models.DTOs
{

        public class RandonneeDTO
        {
            public int id { get; set; }
            public string nom { get; set; }
            public string description { get; set; }
            public string emplacement { get; set; }
            // regarder pour bien recevoir le type ( 0 ou 1 )
            public int typeRandonnee { get; set; }
            public List<GPS> gps { get; set; }
        }

    
}
