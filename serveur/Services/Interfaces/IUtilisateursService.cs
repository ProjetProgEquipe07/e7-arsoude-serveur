using arsoudeServeur.Models;

namespace arsoudeServeur.Services.Interfaces
{
    public interface IUtilisateursService
    {
        public Utilisateur? GetUtilisateurFromUserId(string userId);
        public Task PostUtilisateurFromIdentityUserId(string identityUserId);
    }
}
