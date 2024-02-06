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
                            Id = "9d98d0bc-039d-4e62-aaf3-340a2906737e",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "c3bc3f5e-7954-4156-8553-c0cf537d1d68",
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
                            ConcurrencyStamp = "76bc608c-68be-4f46-ad04-f19c719ba252",
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAECx9hwmttlwHLzBbcYOI2iDIfIfzI7AofnYTcx+2E2dxB5+B76lR7mc8b2KdJuuPJw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d8445ac4-73a5-41b9-99d7-df37df2e7fe2",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = "11111111-1111-1111-1111-111111111112",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c06b0e15-24d2-4271-ba40-59f0415126c7",
                            Email = "user1@hotmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER1@HOTMAIL.COM",
                            NormalizedUserName = "USER1@HOTMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEMRw0EcaqVtbLk3qU5VfT83FyYOS0KI/j9ALAKZj0AnA14DBwU37MARxGqNRpIGiRQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1a5979ad-7f98-4e4f-8f7f-a83084aeded5",
                            TwoFactorEnabled = false,
                            UserName = "user1@hotmail.com"
                        },
                        new
                        {
                            Id = "11111111-1111-1111-1111-111111111113",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5c94771c-bc83-4408-91f1-652b78cdbf74",
                            Email = "user2@hotmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@HOTMAIL.COM",
                            NormalizedUserName = "USER2@HOTMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEB4mrY4oyv9nL9AVk08Vu9Aqk0vTdto83DeAZZ6N/sG0y+EbEeWVJ/wJ2Fh1CV4mSw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "359929f6-a2e3-42ed-9061-4f0934e7c3ea",
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
                            RoleId = "9d98d0bc-039d-4e62-aaf3-340a2906737e"
                        },
                        new
                        {
                            UserId = "11111111-1111-1111-1111-111111111112",
                            RoleId = "c3bc3f5e-7954-4156-8553-c0cf537d1d68"
                        },
                        new
                        {
                            UserId = "11111111-1111-1111-1111-111111111113",
                            RoleId = "c3bc3f5e-7954-4156-8553-c0cf537d1d68"
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
                            nom = "St-Brun",
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
                            description = "promenade fresh a bro s s a r d",
                            emplacement = "st-hilaire?",
                            nom = "Brossard",
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
                            codePostal = "$%&&?%",
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

            modelBuilder.Entity("arsoudeServeur.Models.Utilisateur", b =>
                {
                    b.Navigation("favoris");
                });
#pragma warning restore 612, 618
        }
    }
}
