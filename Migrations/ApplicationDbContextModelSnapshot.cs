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
                            Id = "60fdfb05-6d5c-4ed8-94a4-ad3828505b64",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "6724746c-8ef1-4c10-a809-7fc22221d111",
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
                            ConcurrencyStamp = "3c062aee-dec7-420e-866e-befe34600f3f",
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEAcTXmmeVAYYI6Oo6/UpO9pGQ75F95qAOzLX2LAiSUV3kv1W6OQnxCMGdXW0RWFNjg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b51e2d22-e951-4366-a82e-6b7590f1f430",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = "11111111-1111-1111-1111-111111111112",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4b1d9c88-e3e5-427d-b9bf-28337b71790a",
                            Email = "user1@hotmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER1@HOTMAIL.COM",
                            NormalizedUserName = "USER1@HOTMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEPIcLPY0wwppqb/GsHPRBflrF/Whk2nshCRuGVSHxx/93+oNtQsJl9EdM8rEePtfDQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "06fb5dd6-3d8a-46ef-a986-75e921814a6c",
                            TwoFactorEnabled = false,
                            UserName = "user1@hotmail.com"
                        },
                        new
                        {
                            Id = "11111111-1111-1111-1111-111111111113",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "61088e4f-6f0f-4d1f-a94e-6c0c36f6e485",
                            Email = "user2@hotmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@HOTMAIL.COM",
                            NormalizedUserName = "USER2@HOTMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEEqygMPWmEXO46OUATa8g5fxTZ2ICsk8wauX/5Eqnoj51wVSmxoB5hXQjYbL4i6TKA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8b1ab336-03f8-4ebb-a08c-24d96fc6f471",
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
                            RoleId = "60fdfb05-6d5c-4ed8-94a4-ad3828505b64"
                        },
                        new
                        {
                            UserId = "11111111-1111-1111-1111-111111111112",
                            RoleId = "6724746c-8ef1-4c10-a809-7fc22221d111"
                        },
                        new
                        {
                            UserId = "11111111-1111-1111-1111-111111111113",
                            RoleId = "6724746c-8ef1-4c10-a809-7fc22221d111"
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
                            nom = "st-bruno",
                            typeRandonnee = 0,
                            utilisateurId = 1
                        },
                        new
                        {
                            id = 2,
                            description = "promenade moyennement cool la bas",
                            emplacement = "st-grégoire",
                            nom = "st-grégoire",
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
                            nom = "prévost",
                            prenom = "bertrand"
                        },
                        new
                        {
                            id = 3,
                            anneeDeNaissance = 0,
                            codePostal = "E3A4R4",
                            courriel = "user2@hotmail.com",
                            identityUserId = "11111111-1111-1111-1111-111111111113",
                            moisDeNaissance = 0,
                            nom = "audet",
                            prenom = "michelle"
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
