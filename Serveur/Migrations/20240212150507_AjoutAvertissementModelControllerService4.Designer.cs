﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using arsoudServeur.Data;

#nullable disable

namespace arsoudeServeur.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240212150507_AjoutAvertissementModelControllerService4")]
    partial class AjoutAvertissementModelControllerService4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = "fa89c9ec-2784-47a0-824a-1b5177bbe452",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "382c3207-20e9-4afe-8271-1f115245afb9",
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
                            ConcurrencyStamp = "36bd25c8-7b1e-48a2-a1db-680011aec814",
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEHpbPPe20D7W4zEmokJkCKzDQtG7as2g5SiUizCS3Mi2SdQtQKfWoHLVQSS9WCbttw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3c3570e1-8e13-4f8b-83bf-e823e25ffebc",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = "11111111-1111-1111-1111-111111111112",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "642477b0-f90e-4712-ac19-c12c778bf29c",
                            Email = "user1@hotmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER1@HOTMAIL.COM",
                            NormalizedUserName = "USER1@HOTMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAED8REGUYSKKTNehOHfoDhAYq0LXNUxq7SRmvQgmoA4VQexhsCYjhjsJXjjrEa/xdOg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "da1ead62-d600-40a7-8e5f-36ad2a568141",
                            TwoFactorEnabled = false,
                            UserName = "user1@hotmail.com"
                        },
                        new
                        {
                            Id = "11111111-1111-1111-1111-111111111113",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d19ba367-25a1-4b25-9dc3-328a68110598",
                            Email = "user2@hotmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@HOTMAIL.COM",
                            NormalizedUserName = "USER2@HOTMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEGwzyWTRhGFWZc6FiuanvDiPeQZFSnNawXKLn1V4vieKdJ5iowwZ6sB7XoBujZSLJQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "59558cb9-1f2f-44c0-aa17-120f4ca0b0cc",
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

            modelBuilder.Entity("arsoudeServeur.Models.Avertissement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateSuppresion")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("randonneeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("typeAvertissement")
                        .HasColumnType("INTEGER");

                    b.Property<double>("x")
                        .HasColumnType("REAL");

                    b.Property<double>("y")
                        .HasColumnType("REAL");

                    b.HasKey("id");

                    b.HasIndex("randonneeId");

                    b.ToTable("avertissements");
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

                    b.Property<int?>("RandonneeUtilisateurTraceid")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("arrivee")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("depart")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("randonneeId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("x")
                        .HasColumnType("REAL");

                    b.Property<double>("y")
                        .HasColumnType("REAL");

                    b.HasKey("id");

                    b.HasIndex("RandonneeUtilisateurTraceid");

                    b.HasIndex("randonneeId");

                    b.ToTable("gps");

                    b.HasData(
                        new
                        {
                            id = 1,
                            arrivee = false,
                            depart = true,
                            randonneeId = 1,
                            x = 45.536653134864743,
                            y = -73.494974340959118
                        },
                        new
                        {
                            id = 2,
                            arrivee = true,
                            depart = false,
                            randonneeId = 1,
                            x = 45.636653134864737,
                            y = -73.594974340959126
                        },
                        new
                        {
                            id = 3,
                            arrivee = false,
                            depart = true,
                            randonneeId = 2,
                            x = 45.354998999999999,
                            y = -73.150238000000002
                        },
                        new
                        {
                            id = 4,
                            arrivee = true,
                            depart = false,
                            randonneeId = 2,
                            x = 45.356924999999997,
                            y = -73.150233999999998
                        },
                        new
                        {
                            id = 5,
                            arrivee = false,
                            depart = true,
                            randonneeId = 3,
                            x = 45.538015000000001,
                            y = -73.156982999999997
                        },
                        new
                        {
                            id = 6,
                            arrivee = true,
                            depart = false,
                            randonneeId = 3,
                            x = 45.636653134864737,
                            y = -73.594974340959126
                        },
                        new
                        {
                            id = 7,
                            arrivee = false,
                            depart = true,
                            randonneeId = 4,
                            x = 45.354998999999999,
                            y = -73.150238000000002
                        },
                        new
                        {
                            id = 8,
                            arrivee = true,
                            depart = false,
                            randonneeId = 4,
                            x = 45.356924999999997,
                            y = -73.150233999999998
                        },
                        new
                        {
                            id = 9,
                            arrivee = false,
                            depart = true,
                            randonneeId = 5,
                            x = 45.354998999999999,
                            y = -73.150238000000002
                        },
                        new
                        {
                            id = 10,
                            arrivee = true,
                            depart = false,
                            randonneeId = 5,
                            x = 45.356924999999997,
                            y = -73.150233999999998
                        },
                        new
                        {
                            id = 11,
                            arrivee = false,
                            depart = true,
                            randonneeId = 6,
                            x = 45.354998999999999,
                            y = -73.160238000000007
                        },
                        new
                        {
                            id = 12,
                            arrivee = true,
                            depart = false,
                            randonneeId = 6,
                            x = 45.356924999999997,
                            y = -73.150233999999998
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

                    b.Property<int>("etatRandonnee")
                        .HasColumnType("INTEGER");

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
                            etatRandonnee = 0,
                            nom = "St-Brun",
                            typeRandonnee = 1,
                            utilisateurId = 1
                        },
                        new
                        {
                            id = 2,
                            description = "promenade moyennement cool la bas",
                            emplacement = "dehors",
                            etatRandonnee = 0,
                            nom = "ptite marche au subway",
                            typeRandonnee = 0,
                            utilisateurId = 2
                        },
                        new
                        {
                            id = 3,
                            description = "promenade fresh a bro s s a r d",
                            emplacement = "st-hilaire?",
                            etatRandonnee = 0,
                            nom = "Brossard",
                            typeRandonnee = 1,
                            utilisateurId = 3
                        },
                        new
                        {
                            id = 4,
                            description = "promenade au subway",
                            emplacement = "st-grégoire",
                            etatRandonnee = 0,
                            nom = "ma randonnée pédestre",
                            typeRandonnee = 0,
                            utilisateurId = 2
                        },
                        new
                        {
                            id = 5,
                            description = "ça doit être cool la bas",
                            emplacement = "quelque part",
                            etatRandonnee = 0,
                            nom = "rivière rouge",
                            typeRandonnee = 0,
                            utilisateurId = 2
                        },
                        new
                        {
                            id = 6,
                            description = "je pense qu'on a beaucoup de fun",
                            emplacement = "mont tremblant",
                            etatRandonnee = 0,
                            nom = "Ma randonnée",
                            typeRandonnee = 0,
                            utilisateurId = 1
                        });
                });

            modelBuilder.Entity("arsoudeServeur.Models.RandonneeUtilisateur", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("randonneeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("utilisateurId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("randonneeId");

                    b.HasIndex("utilisateurId");

                    b.ToTable("RandonneeUtilisateur");
                });

            modelBuilder.Entity("arsoudeServeur.Models.RandonneeUtilisateurTrace", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("randonneeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("utilisateurId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("randonneeId");

                    b.HasIndex("utilisateurId");

                    b.ToTable("utilisateursTrace");
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

                    b.Property<string>("role")
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
                            prenom = "robert",
                            role = "Administrator"
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
                            prenom = "Hulk",
                            role = "User"
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
                            prenom = "Grégory",
                            role = "User"
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

            modelBuilder.Entity("arsoudeServeur.Models.Avertissement", b =>
                {
                    b.HasOne("arsoudeServeur.Models.Randonnee", "randonnee")
                        .WithMany("avertissements")
                        .HasForeignKey("randonneeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("randonnee");
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
                    b.HasOne("arsoudeServeur.Models.RandonneeUtilisateurTrace", null)
                        .WithMany("gpsListe")
                        .HasForeignKey("RandonneeUtilisateurTraceid");

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

            modelBuilder.Entity("arsoudeServeur.Models.RandonneeUtilisateur", b =>
                {
                    b.HasOne("arsoudeServeur.Models.Randonnee", "randonnee")
                        .WithMany()
                        .HasForeignKey("randonneeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("arsoudeServeur.Models.Utilisateur", "utilisateur")
                        .WithMany("favoris")
                        .HasForeignKey("utilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("randonnee");

                    b.Navigation("utilisateur");
                });

            modelBuilder.Entity("arsoudeServeur.Models.RandonneeUtilisateurTrace", b =>
                {
                    b.HasOne("arsoudeServeur.Models.Randonnee", "randonnee")
                        .WithMany("traces")
                        .HasForeignKey("randonneeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("arsoudeServeur.Models.Utilisateur", "utilisateur")
                        .WithMany("traces")
                        .HasForeignKey("utilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("randonnee");

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

                    b.Navigation("avertissements");

                    b.Navigation("image")
                        .IsRequired();

                    b.Navigation("traces");
                });

            modelBuilder.Entity("arsoudeServeur.Models.RandonneeUtilisateurTrace", b =>
                {
                    b.Navigation("gpsListe");
                });

            modelBuilder.Entity("arsoudeServeur.Models.Utilisateur", b =>
                {
                    b.Navigation("favoris");

                    b.Navigation("traces");
                });
#pragma warning restore 612, 618
        }
    }
}
