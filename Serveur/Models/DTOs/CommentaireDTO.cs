using System.ComponentModel.DataAnnotations;

namespace arsoudeServeur.Models.DTOs
{
    public class CommentaireDTO
    {
        public int randonneeId { get; set; }
        [Required]
        public string message { get; set; }
        [Required]
        [Range(0, 5)]
        public int note { get; set; }
    }
}
