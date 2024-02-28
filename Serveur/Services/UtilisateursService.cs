using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Services.Interfaces;
using arsoudServeur.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace arsoudeServeur.Services
{
    public class UtilisateursService : IUtilisateursService
    {
        private ApplicationDbContext _context;

        UserManager<IdentityUser> userManager;

        public class UserNotFoundException : Exception { }
        public class BadPasswordException : Exception
        {
            public BadPasswordException(string? message) : base(message)
            {
            }
        }

        public UtilisateursService() { }

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

        public virtual async Task<Utilisateur> EditProfil(Utilisateur utilisateurCourant, EditProfilDTO profil)
        {
            var utilisateurModifie = await _context.utilisateurs.FirstOrDefaultAsync(u => u.id == utilisateurCourant.id);

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

            utilisateurModifie.prenom = profil.prenom;
            utilisateurModifie.nom = profil.nom;
            utilisateurModifie.adresse = profil.adresse;
            utilisateurModifie.codePostal = profil.codePostal;
            utilisateurModifie.anneeDeNaissance = (int)profil.anneeDeNaissance;
            utilisateurModifie.moisDeNaissance = (int)profil.moisDeNaissance;

            await _context.SaveChangesAsync();

            return utilisateurModifie;
        }

        public virtual async Task<bool> EditPassword(Utilisateur utilisateurCourant, string currentPassword, string newPassword)
        {
            var utilisateurModifie = await _context.Users.FirstOrDefaultAsync(u => u.Id == utilisateurCourant.identityUserId);

            IdentityResult changePasswordResult = await userManager.ChangePasswordAsync(utilisateurModifie, currentPassword, newPassword);

            if (changePasswordResult.Succeeded)
            {
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                string errorList = "";

                foreach (var error in changePasswordResult.Errors)
                {
                    errorList += error.Description;
                }

                throw new BadPasswordException(errorList);
            }
        }
    }
}
