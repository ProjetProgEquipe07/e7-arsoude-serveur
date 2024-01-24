namespace arsoudeServeur.Models.DTOs
{
    public class RegisterDTO
    {
        public string pseudo { get; }
        public string courriel { get; set; }
        public string motDePasse { get; set; }
        public string confirmationMotDePasse { get; set; }
    }
}
