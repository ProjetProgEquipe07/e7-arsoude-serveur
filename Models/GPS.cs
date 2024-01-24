using System.ComponentModel.DataAnnotations.Schema;

namespace arsoudeServeur.Models
{
    public class GPS
    {
        public int id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        // Clé étrangère 
        [NotMapped]
        public int randonnéeId { get; set; }
        [NotMapped]
        public virtual Randonnée randonnée { get; set; } 
    }
}
