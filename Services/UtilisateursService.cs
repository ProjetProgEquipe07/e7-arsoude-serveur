using arsoudeServeur.Models;
using arsoudeServeur.Services.Interfaces;
using arsoudServeur.Data;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace arsoudeServeur.Services
{
    public class UtilisateursService : IUtilisateursService
    {
        private ApplicationDbContext _context;

        public UtilisateursService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Utilisateur? GetUtilisateurFromUserId(string userId)
        {
            return _context.utilisateurs.FirstOrDefault(p => p.identityUserId == userId);
        }


        public async Task PostUtilisateurFromIdentityUserId(string identityUserId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == identityUserId);
            if (user == null)
            {
                return;
            }

            // Creer l'utilisateur
            await _context.utilisateurs.AddAsync(new Utilisateur()
            {
                identityUserId = identityUserId,
            });
            await _context.SaveChangesAsync();
        }

    }
}
