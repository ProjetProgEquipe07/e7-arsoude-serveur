using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace arsoudeServeur.Models
{
    public class Publication
    {
        public int id { get; set; }

        public EtatPublication etat { get; set; }

        public List<Utilisateur> listLike { get; set; }

        public virtual int randonneeId { get; set; } 
        public virtual int utilisateurId { get; set; }


        // Clé étrangère
        public virtual Randonnee randonnee { get; set; }
        public virtual Utilisateur utilisateur { get; set; }


        public enum EtatPublication
        {
            Privée,
            Publique,
        }
    }
}
