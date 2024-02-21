using System.Text.Json.Serialization;

namespace arsoudeServeur.Models
{
    public class CommentaireUtilisateur
    {
        public int id { get; set; }

        public virtual int utilisateurId { get; set; }
        public virtual Utilisateur utilisateur { get; set; }

        public virtual int commentaireId { get; set; }
        [JsonIgnore]
        public virtual Commentaire commentaire { get; set; }
    }
}
