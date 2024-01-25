using arsoudeServeur.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

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
        }
        public DbSet<Utilisateur> utilisateurs { get; set; } = default!;
        public DbSet<Randonnée> randonnées { get; set; } = default!;
        public DbSet<Image> images { get; set; } = default!;
        public DbSet<GPS> gps { get; set; } = default!;
        public DbSet<Commentaire> commentaires { get; set; } = default!;
    }
}