namespace arsoudeServeur.Models
{
    public class RandonneeUtilisateur
    {
        public int id { get; set; }

        public virtual int utilisateurId { get; set; }
        public virtual Utilisateur utilisateur { get; set; }

        public virtual int randonneeId { get; set; }
        public virtual Randonnee randonnee { get; set; }
    }
}
