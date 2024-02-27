using System.Text.Json.Serialization;

namespace arsoudeServeur.Models.ModelAnglais
{
    public class AvertissementAnglais
    {
        public int id { get; set; }

        public string? description { get; set; }

        public int avertissementId { get; set; }

        public virtual Avertissement avertissement { get; set; }

        public int randonneeId { get; set; }

        [JsonIgnore]
        public virtual Randonnee randonnee { get; set; }
    }
}
