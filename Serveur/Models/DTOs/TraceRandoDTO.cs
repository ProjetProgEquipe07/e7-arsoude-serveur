using System.ComponentModel.DataAnnotations;

namespace arsoudeServeur.Models.DTOs
{

    public class TraceRandoDTO
    {
        public int randoId { get; set; }
        public List<GPS> gps { get; set; }
        public int utilisateurId { get; set; }
    }
}
