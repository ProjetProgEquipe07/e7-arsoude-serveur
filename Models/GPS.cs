namespace arsoudeServeur.Models
{
    public class GPS
    {
        public int id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        // Clé étrangère 
        public int randonnéeId { get; set; }
        public virtual Randonnée randonnée { get; set; } 
    }
}
