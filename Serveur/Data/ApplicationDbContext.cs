using arsoudeServeur.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Emit;
using static System.Net.WebRequestMethods;

namespace arsoudServeur.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Seed roles

            base.OnModelCreating(builder);
            var adminRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            };

            var userRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                NormalizedName = "USER"
            };

            builder.Entity<IdentityRole>().HasData(adminRole, userRole);

            //Seed IdentityUsers

            var hasher = new PasswordHasher<IdentityUser>();
            IdentityUser adminUser = new IdentityUser
            {
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",

                NormalizedUserName = "ADMIN@GMAIL.COM",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true
            };
            IdentityUser utilisateur1 = new IdentityUser
            {
                Id = "11111111-1111-1111-1111-111111111112",
                UserName = "user1@hotmail.com",
                Email = "user1@hotmail.com",

                NormalizedUserName = "USER1@HOTMAIL.COM",
                NormalizedEmail = "USER1@HOTMAIL.COM",
                EmailConfirmed = true
            };
            IdentityUser utilisateur2 = new IdentityUser
            {
                Id = "11111111-1111-1111-1111-111111111113",
                UserName = "user2@hotmail.com",
                Email = "user2@hotmail.com",

                NormalizedUserName = "USER2@HOTMAIL.COM",
                NormalizedEmail = "USER2@HOTMAIL.COM",
                EmailConfirmed = true
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Passw0rd!");
            utilisateur1.PasswordHash = hasher.HashPassword(utilisateur1, "Passw0rd!");
            utilisateur2.PasswordHash = hasher.HashPassword(utilisateur2, "Passw0rd!");

            builder.Entity<IdentityUser>().HasData(adminUser, utilisateur1, utilisateur2);

            // Seed utilisateurs

            List<Utilisateur> utilisateurs = new List<Utilisateur>() {
                new Utilisateur
                {
                    id = 1,
                    nom = "tangerine",
                    prenom = "robert",
                    codePostal = "E3A 4R4",
                    role = "Administrator",
                    courriel = adminUser.UserName,
                    adresse = "",
                    identityUserId = adminUser.Id,
                },
                new Utilisateur
                {
                    id = 2,
                    nom = "Hogan",
                    prenom = "Hulk",
                    codePostal = "E3A 4R4",
                    role = "User",
                    courriel = utilisateur1.UserName,
                    adresse = "",
                    identityUserId = utilisateur1.Id,
                },
                new Utilisateur
                {
                    id = 3,
                    nom = "Charles",
                    prenom = "Grégory",
                    codePostal = "E3A 4R4",
                    role = "User",
                    courriel = utilisateur2.UserName,
                    adresse = "1260, rue Mill, suite 100",
                    identityUserId = utilisateur2.Id,
                }
            };

            builder.Entity<Utilisateur>().HasData(utilisateurs);
            SeedRandonnees(builder);
            SeedGPSData(builder);
        }



        private void SeedRandonnees(ModelBuilder builder)
        {
            var randonnees = new List<Randonnee>
            {
                new Randonnee
                {
                    id = 1,
                    nom = "St-Brun",
                    description = "promenade cool a st-brun",
                    emplacement = "st-bruno",
                    utilisateurId = 1,
                    typeRandonnee = Randonnee.Type.Vélo,
                },
                new Randonnee
                {
                    id = 2,
                    nom = "ptite marche au subway",
                    description = "promenade moyennement cool la bas",
                    emplacement = "dehors",
                    utilisateurId = 2,
                    typeRandonnee = Randonnee.Type.Marche,
                },
                new Randonnee
                {
                    id = 3,
                    nom = "Brossard",
                    description = "promenade fresh a bro s s a r d",
                    emplacement = "st-hilaire?",
                    utilisateurId = 3,
                    typeRandonnee = Randonnee.Type.Vélo,
                },
                new Randonnee
                {
                    id = 4,
                    nom = "ma randonnée pédestre",
                    description = "promenade au subway",
                    emplacement = "st-grégoire",
                    utilisateurId = 2,
                    typeRandonnee = Randonnee.Type.Marche,
                },
                new Randonnee
                {
                    id = 5,
                    nom = "rivière rouge",
                    description = "ça doit être cool la bas",
                    emplacement = "quelque part",
                    utilisateurId = 2,
                    typeRandonnee = Randonnee.Type.Marche,
                },
                new Randonnee
                {
                    id = 6,
                    nom = "Ma randonnée",
                    description = "je pense qu'on a beaucoup de fun",
                    emplacement = "mont tremblant",
                    utilisateurId = 1,
                    typeRandonnee = Randonnee.Type.Marche,
                }
            };

            builder.Entity<Randonnee>().HasData(randonnees);
        }

        private void SeedGPSData(ModelBuilder builder)
        {
            var gpsData = new List<GPS>
            {
                new GPS
                {
                    id = 1,
                    x = 45.53665313486474,
                    y = -73.49497434095912,
                    depart = true,
                    randonneeId = 1,
                },
                new GPS
                {
                    id = 2,
                    x = 45.63665313486474,
                    y = -73.59497434095912,
                    arrivee = true,
                    randonneeId = 1,
                },
                new GPS
                {
                    id = 3,
                    x = 45.354999,
                    y = -73.150238,
                    depart = true,
                    randonneeId = 2,

                },
                new GPS
                {
                    id = 4,
                    x = 45.356925,
                    y = -73.150234,
                    arrivee = true,
                    randonneeId = 2,
                },
                new GPS
                {
                    id = 5,
                    x = 45.538015,
                    y = -73.156983,
                    depart = true,
                    randonneeId = 3,
                },
                new GPS
                {
                    id = 6,
                    x = 45.63665313486474,
                    y = -73.59497434095912,
                    arrivee = true,
                    randonneeId = 3,
                },
                new GPS
                {
                    id = 7,
                    x = 45.354999,
                    y = -73.150238,
                    depart = true,
                    randonneeId = 4,
                },
                new GPS
                {
                    id = 8,
                    x = 45.356925,
                    y = -73.150234,
                    arrivee = true,
                    randonneeId = 4,
                },
                new GPS
                {
                    id = 9,
                    x = 45.354999,
                    y = -73.150238,
                    depart = true,
                    randonneeId = 5,
                },
                new GPS
                {
                    id = 10,
                    x = 45.356925,
                    y = -73.150234,
                    arrivee = true,
                    randonneeId = 5,
                },
                new GPS
                {
                    id = 11,
                    x = 45.354999,
                    y = -73.160238,
                    depart = true,
                    randonneeId = 6,
                },
                new GPS
                {
                    id = 12,
                    x = 45.356925,
                    y = -73.150234,
                    arrivee = true,
                    randonneeId = 6,
                },
            };

            builder.Entity<GPS>().HasData(gpsData);
        }
        
        public DbSet<Utilisateur> utilisateurs { get; set; } = default!;
        public DbSet<Randonnee> randonnees { get; set; } = default!;
        public DbSet<Image> images { get; set; } = default!;
        public DbSet<GPS> gps { get; set; } = default!;
        public DbSet<Commentaire> commentaires { get; set; } = default!;
        public DbSet<RandonneeUtilisateurTrace> utilisateursTrace { get; set; } = default!;
    }
}
