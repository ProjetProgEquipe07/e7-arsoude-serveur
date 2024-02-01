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

            Image image1 = new Image
            {
                id = 1,
                lien = "https://stbruno.ca/culture/wp-content/uploads/2016/08/23_lacsmontagne_actuelle_01-600x400.jpg",
                randonneeId = 1,
            };
            Image image2 = new Image
            {
                id = 2,
                lien = "https://stbruno.ca/culture/wp-content/uploads/2016/08/23_lacsmontagne_actuelle_01-600x400.jpg",
                randonneeId = 2,
            };
            Image image3 = new Image
            {
                id = 3,
                lien = "https://stbruno.ca/culture/wp-content/uploads/2016/08/23_lacsmontagne_actuelle_01-600x400.jpg",
                randonneeId = 3,
            };
            Image image4 = new Image
            {
                id = 4,
                lien = "https://stbruno.ca/culture/wp-content/uploads/2016/08/23_lacsmontagne_actuelle_01-600x400.jpg",
                randonneeId = 4,
            };

            builder.Entity<Image>().HasData(image1, image2, image3, image4);

            builder.Entity<Utilisateur>().HasData(utilisateurs);
            Randonnee rando1 = new Randonnee
            {
                id = 1,
                nom = "st-brun",
                description = "promenade cool a st-brun",
                emplacement = "st-bruno",
                /*pointDépart = donnee1,
                pointArrivée = donnee2,
                pointDépartId = donnee1.id,
                pointArrivéeId = donnee2.id,*/
                //image = image1,
                //GPS = new List<GPS> { donnee1, donnee2 },
                //imageId = 1
                utilisateurId = 1,
                typeRandonnee = (Randonnee.Type)Enum.Parse(typeof(Randonnee.Type), "Marche"),
            };

            Randonnee rando0 = new Randonnee
            {
                id = 2,
                nom = "st-brun",
                description = "promenade cool a st-brun",
                emplacement = "st-bruno",
                /*pointDépart = donnee1,
                pointArrivée = donnee2,
                pointDépartId = donnee1.id,
                pointArrivéeId = donnee2.id,*/
                //image = image2,
                //GPS = new List<GPS> { donnee1, donnee2 },
                //imageId = 1
                utilisateurId = 1,
                typeRandonnee = (Randonnee.Type)Enum.Parse(typeof(Randonnee.Type), "Marche"),
            };
            Randonnee rando2 = new Randonnee
            {
                id = 3,
                nom = "st-brun",
                description = "promenade cool a st-brun",
                emplacement = "st-bruno",
                /*pointDépart = donnee1,
                pointArrivée = donnee2,
                pointDépartId = donnee1.id,
                pointArrivéeId = donnee2.id,*/
                //image = image3,
                //GPS = new List<GPS> { donnee1, donnee2 },
                //imageId = 1
                utilisateurId = 1,
                typeRandonnee = (Randonnee.Type)Enum.Parse(typeof(Randonnee.Type), "Marche"),
            };
            Randonnee rando3 = new Randonnee
            {
                id = 4,
                nom = "st-brun",
                description = "promenade cool a st-brun",
                emplacement = "st-bruno",
                /*pointDépart = donnee1,
                pointArrivée = donnee2,
                pointDépartId = donnee1.id,
                pointArrivéeId = donnee2.id,*/
                //image = image4,
                //GPS = new List<GPS> { donnee1, donnee2 },
                utilisateurId = 1,
                typeRandonnee = (Randonnee.Type)Enum.Parse(typeof(Randonnee.Type), "Marche"),
            };
            builder.Entity<Randonnee>().HasData(rando1, rando0, rando2 , rando3);

            GPS donnee1 = new GPS
            {
                id = 1,
                X = 45.53665313486474,
                Y = -73.49497434095912,
                Depart = true,
                randonneeId = 1,
            };
            builder.Entity<GPS>().HasData(donnee1);
            GPS donnee2 = new GPS
            {
                id = 2,
                X = 45.63665313486474,
                Y = -73.59497434095912,
                Arrivee = true,
                randonneeId = 1,
            };
            builder.Entity<GPS>().HasData(donnee2);

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