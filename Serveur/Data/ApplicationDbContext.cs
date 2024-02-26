using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
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

            base.OnModelCreating(builder);

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
            List<Utilisateur> utilisateurs = new List<Utilisateur>()
            {
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
                },
            };

            builder.Entity<Utilisateur>().HasData(utilisateurs);
            SeedRandonnees(builder);
            SeedGPSData(builder);
            SeedCommentaires(builder);
            SeedPublication(builder);
        }



        private void SeedPublication(ModelBuilder builder)
        {
            var publications = new List<Publication>
            {
                new Publication
                {
                    id = 1,
                    etat = Publication.EtatPublication.Publique,
                    randonneeId = 1,
                    utilisateurId = 1,
                  
                },
                new Publication
                {
                    id = 2,
                    etat = Publication.EtatPublication.Publique,
                    randonneeId = 2,
                    utilisateurId = 2,
                },
                new Publication
                {
                    id = 3,
                    etat = Publication.EtatPublication.Publique,
                    randonneeId = 3,
                    utilisateurId = 3,
                },
                new Publication
                {
                    id = 4,
                    etat = Publication.EtatPublication.Publique,
                    randonneeId = 4,
                    utilisateurId = 2,
                },
                new Publication
                {
                    id = 5,
                    etat = Publication.EtatPublication.Publique,
                    randonneeId = 5,
                    utilisateurId = 2,
                },
                new Publication
                {
                    id = 6,
                    etat = Publication.EtatPublication.Publique,
                    randonneeId = 6,
                    utilisateurId = 1,
                }
            };

            builder.Entity<Publication>().HasData(publications);
        }

        private void SeedRandonnees(ModelBuilder builder)
        {
            var randonnees = new List<Randonnee>
            {
                new Randonnee
                {
                    id = 1,
                    nom = "la hike a LTG",
                    description = "promenade cool a st-brun",
                    emplacement = "st-bruno",
                    utilisateurId = 1,
                    typeRandonnee = Randonnee.Type.Vélo,
                    etatRandonnee = Randonnee.Etat.Privée
                },
                new Randonnee
                {
                    id = 2,
                    nom = "ptite marche au subway",
                    description = "promenade moyennement cool la bas",
                    emplacement = "dehors",
                    utilisateurId = 2,
                    typeRandonnee = Randonnee.Type.Marche,
                    etatRandonnee = Randonnee.Etat.Privée
                },
                new Randonnee
                {
                    id = 3,
                    nom = "La promenade du matin",
                    description = "promenade fresh a bro s s a r d",
                    emplacement = "st-hilaire?",
                    utilisateurId = 3,
                    typeRandonnee = Randonnee.Type.Vélo,
                    etatRandonnee = Randonnee.Etat.Privée
                },
                new Randonnee
                {
                    id = 4,
                    nom = "ma randonnée pédestre",
                    description = "promenade au subway",
                    emplacement = "st-grégoire",
                    utilisateurId = 2,
                    typeRandonnee = Randonnee.Type.Marche,
                    etatRandonnee = Randonnee.Etat.Privée
                },
                new Randonnee
                {
                    id = 5,
                    nom = "La place nice a rivière rouge",
                    description = "ça doit être cool la bas",
                    emplacement = "quelque part",
                    utilisateurId = 2,
                    typeRandonnee = Randonnee.Type.Marche,
                    etatRandonnee = Randonnee.Etat.Privée
                },
                new Randonnee
                {
                    id = 6,
                    nom = "Word-up au mont-tremblant",
                    description = "je pense qu'on a beaucoup de fun",
                    emplacement = "mont tremblant",
                    utilisateurId = 1,
                    typeRandonnee = Randonnee.Type.Marche,
                    etatRandonnee = Randonnee.Etat.Privée
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
        private void SeedCommentaires(ModelBuilder builder)
        {
            var commentaireData = new List<Commentaire>
            {
                //Descriptions générées avec https://randomgenerate.io/ai-review-generator
                new Commentaire
                {
                    id = 1,
                    message = "Are you looking for a new outdoor adventure that won't break the bank? Look no further than Arsoude! This app offers a wide variety of hiking trails at affordable prices, making it easy for anyone to experience the beauty of nature without spending a fortune. With Arsoude, you can easily find new trails to explore based on your location and skill level. The app provides detailed information about each trail, including distance, difficulty level, and user reviews, so you can choose the perfect hike for your next outing.",
                    randonneeId = 1,
                    utilisateurId = 2,
                    note = 3,
                    isDeleted = false,
                },
                new Commentaire
                {
                    id = 2,
                    message = "I recently downloaded the hiking app Arsoude and I have to say I am extremely impressed. The app is user-friendly and provides detailed maps, trail information, and tips for hikers of all levels. I love that it includes features such as GPS tracking and offline maps, making it easy to navigate even in remote areas with no signal. The trail recommendations and difficulty ratings have been spot on and have helped me find new hikes that I never would have discovered otherwise. Overall, Arsoude has become my go-to app for all of my hiking adventures. Highly recommend!",
                    randonneeId = 2,
                    utilisateurId = 1,
                    note = 3,
                    isDeleted = false,

                },
                new Commentaire
                {
                    id = 3,
                    message = "As an avid hiker, I cannot recommend the Arsoude app enough. This user-friendly platform has completely revolutionized my hiking experience. From detailed trail maps to real-time weather updates, Arsoude has everything I need to plan and execute the perfect outdoor adventure. The interface is sleek and intuitive, making it easy to navigate even on the go. Plus, the community feature allows me to connect with other outdoor enthusiasts and share tips and recommendations. Whether you're a seasoned hiker or just starting out, Arsoude is a must-have for your next outdoor excursion.",
                    randonneeId = 2,
                    utilisateurId = 2,
                    note = 3,
                    isDeleted = false,
                },
                new Commentaire
                {
                    id = 4,
                    message = "Arsoude is a fantastic hiking app that has completely changed the way I explore the great outdoors. With detailed trail maps, GPS tracking, and real-time weather updates, I can confidently go on new adventures without worrying about getting lost. The app also features a community forum where users can share tips, photos, and recommendations, making it easy to connect with other outdoor enthusiasts. Overall, Arsoude has become an essential tool for my hiking excursions and I highly recommend it to anyone looking to discover new trails.",
                    randonneeId = 2,
                    utilisateurId = 3,
                    note = 1,
                    isDeleted = false,
                },
                new Commentaire
                {
                    id = 5,
                    message = "J'ai récemment découvert l'application de randonnée Arsoude et je dois dire que je suis impressionné. Non seulement elle est facile à utiliser, mais elle offre également une multitude d'itinéraires de randonnée à travers de superbes paysages. Grâce à Arsoude, j'ai pu explorer de nouveaux sentiers et découvrir des trésors cachés que je n'aurais jamais trouvés autrement. Je recommande vivement cette application à tous les amoureux de la randonnée!",
                    randonneeId = 6,
                    utilisateurId = 3,
                    note = 5,
                    isDeleted = false,
                },
            };
            builder.Entity<Commentaire>().HasData(commentaireData);
        }

        public DbSet<Utilisateur> utilisateurs { get; set; } = default!;
        public DbSet<Randonnee> randonnees { get; set; } = default!;
        public DbSet<Image> images { get; set; } = default!;
        public DbSet<GPS> gps { get; set; } = default!;
        public DbSet<Commentaire> commentaires { get; set; } = default!;
        public DbSet<RandonneeUtilisateurTrace> utilisateursTrace { get; set; } = default!;
        public DbSet<Avertissement> avertissements { get; set; } = default!;
        public DbSet<Publication> publication { get; set; } = default!;
        public DbSet<PublicationUtilisateur> Like { get; set; } = default!;
    }
}
