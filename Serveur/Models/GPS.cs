using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace arsoudeServeur.Models
{
    public class GPS
    {
        public int id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public bool Depart { get; set; } = false;
        public bool Arrivee { get; set; } = false;

        // Clé étrangère
        public virtual int? randonneeId { get; set; }
        public virtual int? randonneAnglaisId { get; set; }
        [JsonIgnore]
        public virtual Randonnee? randonnee { get; set; } 
    }
}
