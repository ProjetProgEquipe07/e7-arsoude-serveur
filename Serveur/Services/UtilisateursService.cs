using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Services.Interfaces;
using arsoudServeur.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace arsoudeServeur.Services
{
    public class UtilisateursService : IUtilisateursService
    {
        private ApplicationDbContext _context;

        UserManager<IdentityUser> userManager;

        public class UserNotFoundException : Exception{}

        public UtilisateursService(ApplicationDbContext context)
        {
            _context = context;

        }

        public UtilisateursService(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        public virtual Utilisateur? GetUtilisateurFromUserId(string userId)
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

            if (register.moisDeNaissance == null)
            {
                register.moisDeNaissance = 0;
            }
            if (register.anneeDeNaissance == null)
            {
                register.anneeDeNaissance = 0;
            }
            if (register.adresse == null)
            {
                register.adresse = "";
            }

            // Creer l'utilisateur
            await _context.utilisateurs.AddAsync(new Utilisateur()
            {
                identityUserId = identityUserId,
                courriel = register.courriel,
                prenom = register.prenom,
                nom = register.nom,
                codePostal = register.codePostal,
                role = "User",
                anneeDeNaissance = (int)register.anneeDeNaissance,
                moisDeNaissance = (int)register.moisDeNaissance,
                adresse = register.adresse
            });
            await _context.SaveChangesAsync();
        }

        public Task PostUtilisateurFromIdentityUserId(string identityUserId)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Utilisateur> EditProfil(Utilisateur utilisateur, EditProfilDTO profil)
        {
            var user = await _context.utilisateurs.FirstOrDefaultAsync(u => u.id == utilisateur.id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            if (profil.moisDeNaissance == null)
            {
                profil.moisDeNaissance = 0;
            }
            if (profil.anneeDeNaissance == null)
            {
                profil.anneeDeNaissance = 0;
            }
            if (profil.adresse == null)
            {
                profil.adresse = "";
            }

            user.prenom = profil.prenom;
            user.nom = profil.nom;
            user.adresse = profil.adresse;
            user.codePostal = profil.codePostal;
            user.anneeDeNaissance = (int)profil.anneeDeNaissance;
            user.moisDeNaissance = (int)profil.moisDeNaissance;

            await _context.SaveChangesAsync();

            return user;
        }

        public virtual async Task<string> EditPassword(Utilisateur utilisateur, string currentPassword, string newPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == utilisateur.identityUserId);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            IdentityResult changePasswordResult = await userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (changePasswordResult.Succeeded)
            {
                await _context.SaveChangesAsync();

                return "Password change success";
            }
            else
            {
                string errorList = "";

                foreach (var error in changePasswordResult.Errors)
                {
                    errorList += "\n" + error.Description;
                }

                return errorList;
            }
        }
    }
}
