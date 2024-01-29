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

            var randoRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Randonneur",
                NormalizedName = "RANDONNEUR"
            };

            builder.Entity<IdentityRole>().HasData(adminRole, randoRole);

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
                    RoleId = randoRole.Id,
                    UserId = utilisateur1.Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = randoRole.Id,
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
            Randonnee rando0 = new Randonnee
            {
                id = 1,
                nom = "st-bruno",
                description = "promenade cool a st-brun",
                emplacement = "st-bruno",
                utilisateurId = 1,
                typeRandonnee = (Randonnee.Type)Enum.Parse(typeof(Randonnee.Type), "Marche"),
            };

            Randonnee rando1 = new Randonnee
            {
                id = 2,
                nom = "st-grégoire",
                description = "promenade moyennement cool la bas",
                emplacement = "st-grégoire",
                utilisateurId = 2,
                typeRandonnee = (Randonnee.Type)Enum.Parse(typeof(Randonnee.Type), "Marche"),
            };
            Randonnee rando2 = new Randonnee
            {
                id = 3,
                nom = "st-hilaire",
                description = "promenade fresh a st-hilaire",
                emplacement = "st-hilaire",
                utilisateurId = 3,
                typeRandonnee = (Randonnee.Type)Enum.Parse(typeof(Randonnee.Type), "Vélo"),
            };
            builder.Entity<Randonnee>().HasData(rando0, rando1, rando2);

            GPS donnee01 = new GPS
            {
                id = 1,
                X = 45.53665313486474,
                Y = -73.49497434095912,
                Depart = true,
                randonneeId = 1,
            };
            GPS donnee02 = new GPS
            {
                id = 2,
                X = 45.63665313486474,
                Y = -73.59497434095912,
                Arrivee = true,
                randonneeId = 1,
            };

            GPS donnee11 = new GPS
            {
                id = 3,
                X = 45.354999,
                Y = -73.150238,
                Depart = true,
                randonneeId = 2,
            };
            GPS donnee12 = new GPS
            {
                id = 4,
                X = 45.356925,
                Y = -73.150234,
                Arrivee = true,
                randonneeId = 2,
            };

            GPS donnee21 = new GPS
            {
                id = 5,
                X = 45.538015,
                Y = -73.156983,
                Depart = true,
                randonneeId = 3,
            };
            GPS donnee22 = new GPS
            {
                id = 6,
                X = 45.63665313486474,
                Y = -73.59497434095912,
                Arrivee = true,
                randonneeId = 3,
            };
            builder.Entity<GPS>().HasData(donnee01, donnee02, donnee11, donnee12,donnee21, donnee22);

            ConfigureRelationships(builder);
        }
        private static void ConfigureRelationships(ModelBuilder builder)
        {
            //Rando-GPS relationship
            /*builder.Entity<Randonnée>()
                    .HasOne(r => r.pointDépart)               // Une randonnée a un point de départ
                    .WithMany()                               // Un point de départ peut être partagé par plusieurs randonnées
                    .HasForeignKey(r => r.pointDépartId)      // Clé étrangère pour la relation
                    .OnDelete(DeleteBehavior.Restrict);       
            builder.Entity<Randonnée>()
                    .HasOne(r => r.pointArrivée)              // Une randonnée a un point d'arrivée
                    .WithMany()                               // Un point d'arrivée peut être partagé par plusieurs randonnées
                    .HasForeignKey(r => r.pointArrivéeId)     // Clé étrangère pour la relation
                    .OnDelete(DeleteBehavior.Restrict);*/

            /*builder.Entity<Randonnée>()
                    .HasOne(r => r.image)
                    .WithOne(i => i.randonnée)
                    .HasForeignKey<Randonnée>(r => r.imageId)
                    .OnDelete(DeleteBehavior.Cascade);*/
        }
        public DbSet<Utilisateur> utilisateurs { get; set; } = default!;
        public DbSet<Randonnee> randonnees { get; set; } = default!;
        public DbSet<Image> images { get; set; } = default!;
        public DbSet<GPS> gps { get; set; } = default!;
        public DbSet<Commentaire> commentaires { get; set; } = default!;
    }
}