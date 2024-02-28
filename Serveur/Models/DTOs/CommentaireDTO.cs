using System.ComponentModel.DataAnnotations;

namespace arsoudeServeur.Models.DTOs
{
    public class CommentaireDTO
    {
        public int? randonneeId { get; set; }
        public string? message { get; set; }
        [Range(0, 5)]
        public int? note { get; set; }
    }
}
