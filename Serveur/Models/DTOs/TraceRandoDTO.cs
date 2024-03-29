﻿using System.ComponentModel.DataAnnotations;

namespace arsoudeServeur.Models.DTOs
{

    public class TraceRandoDTO
    {
        public int id { get; set; }
        public int randoId { get; set; }
        public string timer { get; set; }
        public List<GPS> gps { get; set; }
        public int utilisateurId { get; set; }
        public int publicationid { get; set; }
    }
}
