using System.Text.Json.Serialization;

namespace arsoudeServeur.Models.ModelAnglais
{
    public class CommentaireAnglais
    {
        public int id { get; set; }

        public string? message { get; set; } = "";

        public int commentaireId { get; set; }

        public virtual Commentaire commentaire { get; set;}

        public int? randonneeId { get; set; }
        [JsonIgnore]
        public virtual Randonnee? randonnee { get; set; }

    }
}
