namespace arsoudeServeur.Models
{
    public class Avertissement
    {
        public int id { get; set; }

        public string description { get; set; }

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

        public virtual Randonnee randonnee { get; set; }
    }
}
