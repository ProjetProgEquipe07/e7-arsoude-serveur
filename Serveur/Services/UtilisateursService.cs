using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
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


        public async Task PostUtilisateurFromIdentityUserId(string identityUserId, RegisterDTO register)
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
                courriel = register.courriel,
                prenom = register.prénom,
                nom = register.nom,
                codePostal = register.codePostal,
                anneeDeNaissance = register.anneeDeNaissance,
                moisDeNaissance = register.moisDeNaissance,
                adresse = register.adresse
            });
            await _context.SaveChangesAsync();
        }

        public Task PostUtilisateurFromIdentityUserId(string identityUserId)
        {
            throw new NotImplementedException();
        }
    }
}
