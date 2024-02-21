using System.Text.Json.Serialization;

namespace arsoudeServeur.Models.DTOs
{
    public class PublicationUtilisateur
    {
        public int id { get; set; }
       
        public virtual int utilisateurId { get; set; }
        public virtual Utilisateur utilisateur { get; set; }

        public virtual int publicationId { get; set; }
        [JsonIgnore]
        public virtual Publication publication { get; set; }
    }
}
