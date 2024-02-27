using System.ComponentModel.DataAnnotations;

namespace arsoudeServeur.Models.DTOs
{
    public class CommentaireDTO
    {
        public int randonneeId { get; set; }
        [MaxLength(255, ErrorMessage = "La longueur maximale est de 255 caractères.")]
        public string? message { get; set; }
        [Range(0, 5)]
        public int note { get; set; }
    }
}
