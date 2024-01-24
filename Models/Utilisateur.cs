using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace arsoudeServeur.Models
{
    public class Utilisateur
    {
        public int id { get; set; }

        public required string identityUserId { get; set; }
        [JsonIgnore]
        public virtual IdentityUser? identityUser { get; set; }
        [JsonIgnore]
        public virtual List<Randonnée> listeRandonnée { get; set; }
    }
}
