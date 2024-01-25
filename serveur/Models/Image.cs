using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace arsoudeServeur.Models
{
    public class Image
    {
        public int id { get; set; }
        public string lien { get; set; }

        // Clé étrangère 
        public int? randonnéeId { get; set; }
        [JsonIgnore]
        public virtual Randonnée? randonnée { get; set; }
    }
}
