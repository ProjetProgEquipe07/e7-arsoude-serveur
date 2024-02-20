using static arsoudeServeur.Models.Publication;

namespace arsoudeServeur.Models.DTOs
{
    public class PublicationDTOSend
    {

        public int id { get; set; }

        public EtatPublication etat { get; set; }

        public List<Utilisateur> listLike { get; set; }

        public virtual int randonneeId { get; set; }
        public virtual int utilisateurId { get; set; }

        public RandonneeDetailDTO randonnee { get; set; }
        public Utilisateur utilisateur { get; set; }
    }
}
