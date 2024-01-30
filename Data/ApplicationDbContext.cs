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

            // Lien user <-> role

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRole.Id,
                    UserId = adminUser.Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRole.Id,
                    UserId = utilisateur1.Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRole.Id,
                    UserId = utilisateur2.Id
                }
            );

            // Seed utilisateurs

            List<Utilisateur> utilisateurs = new List<Utilisateur>() {
                new Utilisateur
                {
                    id = 1,
                    nom = "tangerine",
                    prenom = "robert",
                    codePostal = "E3A4R4",
                    courriel = adminUser.UserName,
                    identityUserId = adminUser.Id,
                },
                new Utilisateur
                {
                    id = 2,
                    nom = "prévost",
                    prenom = "bertrand",
                    codePostal = "E3A4R4",
                    courriel = utilisateur1.UserName,
                    identityUserId = utilisateur1.Id,
                },
                new Utilisateur
                {
                    id = 3,
                    nom = "audet",
                    prenom = "michelle",
                    codePostal = "E3A4R4",
                    courriel = utilisateur2.UserName,
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
                    nom = "st-bruno",
                    description = "promenade cool a st-brun",
                    emplacement = "st-bruno",
                    utilisateurId = 1,
                    typeRandonnee = Randonnee.Type.Marche,
                },
                new Randonnee
                {
                    id = 2,
                    nom = "st-grégoire",
                    description = "promenade moyennement cool la bas",
                    emplacement = "st-grégoire",
                    utilisateurId = 2,
                    typeRandonnee = Randonnee.Type.Marche,
                },
                new Randonnee
                {
                    id = 3,
                    nom = "st-hilaire",
                    description = "promenade fresh a st-hilaire",
                    emplacement = "st-hilaire",
                    utilisateurId = 3,
                    typeRandonnee = Randonnee.Type.Vélo,
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
                    X = 45.53665313486474,
                    Y = -73.49497434095912,
                    Depart = true,
                    randonneeId = 1,
                },
                new GPS
                {
                    id = 2,
                    X = 45.63665313486474,
                    Y = -73.59497434095912,
                    Arrivee = true,
                    randonneeId = 1,
                },
                new GPS
                {
                    id = 3,
                    X = 45.354999,
                    Y = -73.150238,
                    Depart = true,
                    randonneeId = 2,
                },
                new GPS
                {
                    id = 4,
                    X = 45.356925,
                    Y = -73.150234,
                    Arrivee = true,
                    randonneeId = 2,
                },
                new GPS
                {
                    id = 5,
                    X = 45.538015,
                    Y = -73.156983,
                    Depart = true,
                    randonneeId = 3,
                },
                new GPS
                {
                    id = 6,
                    X = 45.63665313486474,
                    Y = -73.59497434095912,
                    Arrivee = true,
                    randonneeId = 3,
                }
            };

            builder.Entity<GPS>().HasData(gpsData);
        }
        
        public DbSet<Utilisateur> utilisateurs { get; set; } = default!;
        public DbSet<Randonnee> randonnees { get; set; } = default!;
        public DbSet<Image> images { get; set; } = default!;
        public DbSet<GPS> gps { get; set; } = default!;
        public DbSet<Commentaire> commentaires { get; set; } = default!;
    }
}