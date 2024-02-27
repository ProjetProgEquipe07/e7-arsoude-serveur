using System.Text.Json.Serialization;

namespace arsoudeServeur.Models
{
    public class Avertissement
    {
        public int id { get; set; }

        public string? description { get; set; }

        public TypeAvertissement typeAvertissement { get; set; }

        public enum TypeAvertissement
        {
            GlissementTerrain,
            CheminBlockéParArbre,
            CheminInnondé,
            Autre
        }

        public DateTime DateSuppresion { get; set; }

        public int randonneeId { get; set; }

        [JsonIgnore]
        public virtual Randonnee randonnee { get; set; }
        
        public double x { get; set; }

        public double y { get; set; }
    }
}
