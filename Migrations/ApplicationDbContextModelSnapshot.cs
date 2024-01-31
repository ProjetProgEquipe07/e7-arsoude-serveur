﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using arsoudServeur.Data;

#nullable disable

namespace arsoudeServeur.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "22bde0f1-b568-4a7a-ab56-282896edff1b",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "04798ff0-94f7-4b12-9e7e-4d65e05feee6",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "11111111-1111-1111-1111-111111111111",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "44d5fb7f-301f-42a7-bf10-0798d51ae7c2",
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEAMn1sRHqkJ8PjfT4Ju40R74d9mQmd0PVODVDmp7a+2wOUTdnclBjjcaCoDlAqQOqg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "66ff312e-3e56-4664-97a9-2fbe2f0c105c",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = "11111111-1111-1111-1111-111111111112",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8fff73f8-031a-4b87-a0cc-dfdf8ab15e7f",
                            Email = "user1@hotmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER1@HOTMAIL.COM",
                            NormalizedUserName = "USER1@HOTMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEIMtS+dsFIQd7uiLe+jXMqSUKQdqWolz2YCqX9jdi2KEmG9ctyXDBzUqT+n4G8foOg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "58f506a5-1599-414d-a92c-4672dd4d5bc5",
                            TwoFactorEnabled = false,
                            UserName = "user1@hotmail.com"
                        },
                        new
                        {
                            Id = "11111111-1111-1111-1111-111111111113",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1a55bde1-e0b1-4797-b96a-cdfca5019b41",
                            Email = "user2@hotmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@HOTMAIL.COM",
                            NormalizedUserName = "USER2@HOTMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEDJyUoLpKHdT4KlxzEn2NLbAzequWIAxvSaqKsVtvUNiZqN0/TJuwfREVYjCIwfYHQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b94f04f9-266d-4da9-87a1-0dd1cec2a96a",
                            TwoFactorEnabled = false,
                            UserName = "user2@hotmail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "11111111-1111-1111-1111-111111111111",
                            RoleId = "22bde0f1-b568-4a7a-ab56-282896edff1b"
                        },
                        new
                        {
                            UserId = "11111111-1111-1111-1111-111111111112",
                            RoleId = "04798ff0-94f7-4b12-9e7e-4d65e05feee6"
                        },
                        new
                        {
                            UserId = "11111111-1111-1111-1111-111111111113",
                            RoleId = "04798ff0-94f7-4b12-9e7e-4d65e05feee6"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("arsoudeServeur.Models.Commentaire", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("randonneeid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("randonnéeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("texte")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("utilisateurId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("randonneeid");

                    b.HasIndex("utilisateurId");

                    b.ToTable("commentaires");
                });

            modelBuilder.Entity("arsoudeServeur.Models.GPS", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Arrivee")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Depart")
                        .HasColumnType("INTEGER");

                    b.Property<double>("X")
                        .HasColumnType("REAL");

                    b.Property<double>("Y")
                        .HasColumnType("REAL");

                    b.Property<int?>("randonneeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("randonneeId");

                    b.ToTable("gps");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Arrivee = false,
                            Depart = true,
                            X = 45.536653134864743,
                            Y = -73.494974340959118,
                            randonneeId = 1
                        },
                        new
                        {
                            id = 2,
                            Arrivee = true,
                            Depart = false,
                            X = 45.636653134864737,
                            Y = -73.594974340959126,
                            randonneeId = 1
                        },
                        new
                        {
                            id = 3,
                            Arrivee = false,
                            Depart = true,
                            X = 45.354998999999999,
                            Y = -73.150238000000002,
                            randonneeId = 2
                        },
                        new
                        {
                            id = 4,
                            Arrivee = true,
                            Depart = false,
                            X = 45.356924999999997,
                            Y = -73.150233999999998,
                            randonneeId = 2
                        },
                        new
                        {
                            id = 5,
                            Arrivee = false,
                            Depart = true,
                            X = 45.538015000000001,
                            Y = -73.156982999999997,
                            randonneeId = 3
                        },
                        new
                        {
                            id = 6,
                            Arrivee = true,
                            Depart = false,
                            X = 45.636653134864737,
                            Y = -73.594974340959126,
                            randonneeId = 3
                        },
                        new
                        {
                            id = 7,
                            Arrivee = false,
                            Depart = true,
                            X = 45.354998999999999,
                            Y = -73.150238000000002,
                            randonneeId = 4
                        },
                        new
                        {
                            id = 8,
                            Arrivee = true,
                            Depart = false,
                            X = 45.356924999999997,
                            Y = -73.150233999999998,
                            randonneeId = 4
                        },
                        new
                        {
                            id = 9,
                            Arrivee = false,
                            Depart = true,
                            X = 45.354998999999999,
                            Y = -73.150238000000002,
                            randonneeId = 5
                        },
                        new
                        {
                            id = 10,
                            Arrivee = true,
                            Depart = false,
                            X = 45.356924999999997,
                            Y = -73.150233999999998,
                            randonneeId = 5
                        },
                        new
                        {
                            id = 11,
                            Arrivee = false,
                            Depart = true,
                            X = 45.354998999999999,
                            Y = -73.160238000000007,
                            randonneeId = 6
                        },
                        new
                        {
                            id = 12,
                            Arrivee = true,
                            Depart = false,
                            X = 45.356924999999997,
                            Y = -73.150233999999998,
                            randonneeId = 6
                        },
                        new
                        {
                            id = 13,
                            Arrivee = false,
                            Depart = true,
                            X = 45.364998999999997,
                            Y = -73.110237999999995,
                            randonneeId = 7
                        },
                        new
                        {
                            id = 14,
                            Arrivee = true,
                            Depart = false,
                            X = 45.386924999999998,
                            Y = -73.152234000000007,
                            randonneeId = 7
                        },
                        new
                        {
                            id = 15,
                            Arrivee = false,
                            Depart = true,
                            X = 45.364998999999997,
                            Y = -73.166238000000007,
                            randonneeId = 8
                        },
                        new
                        {
                            id = 16,
                            Arrivee = true,
                            Depart = false,
                            X = 45.456924999999998,
                            Y = -73.128234000000006,
                            randonneeId = 8
                        });
                });

            modelBuilder.Entity("arsoudeServeur.Models.Image", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("lien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("randonneeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("randonneeId")
                        .IsUnique();

                    b.ToTable("images");
                });

            modelBuilder.Entity("arsoudeServeur.Models.Randonnee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("emplacement")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.Property<int>("typeRandonnee")
                        .HasColumnType("INTEGER");

                    b.Property<int>("utilisateurId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("utilisateurId");

                    b.ToTable("randonnees");

                    b.HasData(
                        new
                        {
                            id = 1,
                            description = "promenade cool a st-brun",
                            emplacement = "st-bruno",
                            nom = "St-Bruno",
                            typeRandonnee = 1,
                            utilisateurId = 1
                        },
                        new
                        {
                            id = 2,
                            description = "promenade moyennement cool la bas",
                            emplacement = "dehors",
                            nom = "ptite marche au subway",
                            typeRandonnee = 0,
                            utilisateurId = 2
                        },
                        new
                        {
                            id = 3,
                            description = "promenade fresh a st-hilaire",
                            emplacement = "st-hilaire",
                            nom = "st-hilaire",
                            typeRandonnee = 1,
                            utilisateurId = 3
                        },
                        new
                        {
                            id = 4,
                            description = "promenade au subway",
                            emplacement = "st-grégoire",
                            nom = "ma randonnée pédestre",
                            typeRandonnee = 0,
                            utilisateurId = 2
                        },
                        new
                        {
                            id = 5,
                            description = "ça doit être cool la bas",
                            emplacement = "quelque part",
                            nom = "rivière rouge",
                            typeRandonnee = 0,
                            utilisateurId = 2
                        },
                        new
                        {
                            id = 6,
                            description = "je pense qu'on a beaucoup de fun",
                            emplacement = "mont tremblant",
                            nom = "Ma randonnée",
                            typeRandonnee = 0,
                            utilisateurId = 1
                        },
                        new
                        {
                            id = 7,
                            description = "J'ai eu beaucoup de plaisir",
                            emplacement = "st-jérome",
                            nom = "ayyyyyy",
                            typeRandonnee = 0,
                            utilisateurId = 2
                        },
                        new
                        {
                            id = 8,
                            description = "moyennement le fun pour vrai",
                            emplacement = "ottoburn park",
                            nom = "st-grégoire",
                            typeRandonnee = 0,
                            utilisateurId = 3
                        });
                });

            modelBuilder.Entity("arsoudeServeur.Models.Utilisateur", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("adresse")
                        .HasColumnType("TEXT");

                    b.Property<int>("anneeDeNaissance")
                        .HasColumnType("INTEGER");

                    b.Property<string>("codePostal")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("courriel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("identityUserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("moisDeNaissance")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("identityUserId");

                    b.ToTable("utilisateurs");

                    b.HasData(
                        new
                        {
                            id = 1,
                            anneeDeNaissance = 0,
                            codePostal = "E3A4R4",
                            courriel = "admin@gmail.com",
                            identityUserId = "11111111-1111-1111-1111-111111111111",
                            moisDeNaissance = 0,
                            nom = "tangerine",
                            prenom = "robert"
                        },
                        new
                        {
                            id = 2,
                            anneeDeNaissance = 0,
                            codePostal = "E3A4R4",
                            courriel = "user1@hotmail.com",
                            identityUserId = "11111111-1111-1111-1111-111111111112",
                            moisDeNaissance = 0,
                            nom = "Hogan",
                            prenom = "Hulk"
                        },
                        new
                        {
                            id = 3,
                            anneeDeNaissance = 0,
                            codePostal = "E3A4R4",
                            courriel = "user2@hotmail.com",
                            identityUserId = "11111111-1111-1111-1111-111111111113",
                            moisDeNaissance = 0,
                            nom = "Charles",
                            prenom = "Grégory"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("arsoudeServeur.Models.Commentaire", b =>
                {
                    b.HasOne("arsoudeServeur.Models.Randonnee", "randonnee")
                        .WithMany()
                        .HasForeignKey("randonneeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("arsoudeServeur.Models.Utilisateur", "utilisateur")
                        .WithMany()
                        .HasForeignKey("utilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("randonnee");

                    b.Navigation("utilisateur");
                });

            modelBuilder.Entity("arsoudeServeur.Models.GPS", b =>
                {
                    b.HasOne("arsoudeServeur.Models.Randonnee", "randonnee")
                        .WithMany("GPS")
                        .HasForeignKey("randonneeId");

                    b.Navigation("randonnee");
                });

            modelBuilder.Entity("arsoudeServeur.Models.Image", b =>
                {
                    b.HasOne("arsoudeServeur.Models.Randonnee", "randonnee")
                        .WithOne("image")
                        .HasForeignKey("arsoudeServeur.Models.Image", "randonneeId");

                    b.Navigation("randonnee");
                });

            modelBuilder.Entity("arsoudeServeur.Models.Randonnee", b =>
                {
                    b.HasOne("arsoudeServeur.Models.Utilisateur", "utilisateur")
                        .WithMany()
                        .HasForeignKey("utilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("utilisateur");
                });

            modelBuilder.Entity("arsoudeServeur.Models.Utilisateur", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "identityUser")
                        .WithMany()
                        .HasForeignKey("identityUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("identityUser");
                });

            modelBuilder.Entity("arsoudeServeur.Models.Randonnee", b =>
                {
                    b.Navigation("GPS");

                    b.Navigation("image")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
