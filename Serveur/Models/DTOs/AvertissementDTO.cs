namespace arsoudeServeur.Models.DTOs
{
    public class AvertissementDTO
    {
        public int id { get; set; }

        public string description { get; set; }

        public int typeAvertissement { get; set; }

        public int randonneeId { get; set; }
        
        public GPS gps { get; set; }
    }
}
