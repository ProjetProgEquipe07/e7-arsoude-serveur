using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace arsoudeServeur.Models
{
    public class GPS
    {
        public int id { get; set; }
        public double x { get; set; }
        public double y { get; set; }

        public bool depart { get; set; } = false;
        public bool arrivee { get; set; } = false;

        // Clés étrangères
        public virtual int? randonneeId { get; set; }
        public virtual int? randonneAnglaisId { get; set; }
        [JsonIgnore]
        public virtual Randonnee? randonnee { get; set; } 

    }
}
