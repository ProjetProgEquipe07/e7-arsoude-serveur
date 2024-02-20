namespace arsoudeServeur.Models
{
    public class RandonneeUtilisateurTrace
    {
        //classe qui lie Randonnée, Utilisateur et GPS 
        //pour permettre à un utilisateur de faire une randonnée approuvée
        //et de créer son propre tracé
        public int id { get; set; }

        public virtual int utilisateurId { get; set; }
        public virtual Utilisateur utilisateur { get; set; }

        public virtual int? publicationId { get; set; }
        public virtual Publication? publication { get; set; }

        public virtual int randonneeId { get; set; }
        public virtual Randonnee randonnee { get; set; }

        public virtual List<GPS> gpsListe { get; set; }
    }
}
