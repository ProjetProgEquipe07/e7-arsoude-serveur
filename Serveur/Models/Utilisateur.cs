using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace arsoudeServeur.Models
{
    public class Utilisateur
    {
        // Nécessaire pour faire le seed
        public Utilisateur() { }

        public int id { get; set; }
        public string courriel { get; set; }
        public string prenom { get; set; }
        public string nom { get; set; }
        public string codePostal { get; set; }
        public string role { get; set; }

        // TODO : doit être valide (currentYear - 100)
        public int anneeDeNaissance { get; set; } 
        // TODO : doit être valide (1-12)
        public int moisDeNaissance { get; set; }

        public string? adresse { get; set; }

        public required string identityUserId { get; set; }
        [JsonIgnore]
        public virtual IdentityUser? identityUser { get; set; }

        [JsonIgnore]
        public virtual List<RandonneeUtilisateur> favoris { get; set; } = new List<RandonneeUtilisateur>();

        [JsonIgnore]
        public virtual List<RandonneeUtilisateurTrace> traces { get; set; } = new List<RandonneeUtilisateurTrace>();

    }
}
