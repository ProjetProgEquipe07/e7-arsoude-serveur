﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace arsoudeServeur.Models
{
    public class Image
    {
        public int id { get; set; }
        public string lien { get; set; }

        // Clé étrangère 
        public int? randonneeId { get; set; }
        [JsonIgnore]
        public virtual Randonnee? randonnee { get; set; }
    }
}
