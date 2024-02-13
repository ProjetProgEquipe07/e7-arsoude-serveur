using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class IN182 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "utilisateurs",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    courriel = table.Column<string>(type: "TEXT", nullable: false),
                    prenom = table.Column<string>(type: "TEXT", nullable: false),
                    nom = table.Column<string>(type: "TEXT", nullable: false),
                    codePostal = table.Column<string>(type: "TEXT", nullable: false),
                    role = table.Column<string>(type: "TEXT", nullable: false),
                    anneeDeNaissance = table.Column<int>(type: "INTEGER", nullable: false),
                    moisDeNaissance = table.Column<int>(type: "INTEGER", nullable: false),
                    adresse = table.Column<string>(type: "TEXT", nullable: true),
                    identityUserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utilisateurs", x => x.id);
                    table.ForeignKey(
                        name: "FK_utilisateurs_AspNetUsers_identityUserId",
                        column: x => x.identityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "randonnees",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    emplacement = table.Column<string>(type: "TEXT", nullable: false),
                    typeRandonnee = table.Column<int>(type: "INTEGER", nullable: false),
                    etatRandonnee = table.Column<int>(type: "INTEGER", nullable: false),
                    utilisateurId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_randonnees", x => x.id);
                    table.ForeignKey(
                        name: "FK_randonnees_utilisateurs_utilisateurId",
                        column: x => x.utilisateurId,
                        principalTable: "utilisateurs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "avertissements",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    typeAvertissement = table.Column<int>(type: "INTEGER", nullable: false),
                    DateSuppresion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    randonneeId = table.Column<int>(type: "INTEGER", nullable: false),
                    x = table.Column<double>(type: "REAL", nullable: false),
                    y = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avertissements", x => x.id);
                    table.ForeignKey(
                        name: "FK_avertissements_randonnees_randonneeId",
                        column: x => x.randonneeId,
                        principalTable: "randonnees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    lien = table.Column<string>(type: "TEXT", nullable: false),
                    randonneeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.id);
                    table.ForeignKey(
                        name: "FK_images_randonnees_randonneeId",
                        column: x => x.randonneeId,
                        principalTable: "randonnees",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "randonneeAnglais",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    emplacement = table.Column<string>(type: "TEXT", nullable: false),
                    typeRandonnee = table.Column<int>(type: "INTEGER", nullable: false),
                    etatRandonnee = table.Column<int>(type: "INTEGER", nullable: false),
                    randonneeId = table.Column<int>(type: "INTEGER", nullable: false),
                    utilisateurId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_randonneeAnglais", x => x.id);
                    table.ForeignKey(
                        name: "FK_randonneeAnglais_randonnees_randonneeId",
                        column: x => x.randonneeId,
                        principalTable: "randonnees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_randonneeAnglais_utilisateurs_utilisateurId",
                        column: x => x.utilisateurId,
                        principalTable: "utilisateurs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RandonneeUtilisateur",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    utilisateurId = table.Column<int>(type: "INTEGER", nullable: false),
                    randonneeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandonneeUtilisateur", x => x.id);
                    table.ForeignKey(
                        name: "FK_RandonneeUtilisateur_randonnees_randonneeId",
                        column: x => x.randonneeId,
                        principalTable: "randonnees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RandonneeUtilisateur_utilisateurs_utilisateurId",
                        column: x => x.utilisateurId,
                        principalTable: "utilisateurs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "utilisateursTrace",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    utilisateurId = table.Column<int>(type: "INTEGER", nullable: false),
                    randonneeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utilisateursTrace", x => x.id);
                    table.ForeignKey(
                        name: "FK_utilisateursTrace_randonnees_randonneeId",
                        column: x => x.randonneeId,
                        principalTable: "randonnees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_utilisateursTrace_utilisateurs_utilisateurId",
                        column: x => x.utilisateurId,
                        principalTable: "utilisateurs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "commentaires",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    texte = table.Column<string>(type: "TEXT", nullable: true),
                    review = table.Column<int>(type: "INTEGER", nullable: false),
                    randonneeId = table.Column<int>(type: "INTEGER", nullable: false),
                    utilisateurId = table.Column<int>(type: "INTEGER", nullable: false),
                    RandonneeAnglaisid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commentaires", x => x.id);
                    table.ForeignKey(
                        name: "FK_commentaires_randonneeAnglais_RandonneeAnglaisid",
                        column: x => x.RandonneeAnglaisid,
                        principalTable: "randonneeAnglais",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_commentaires_randonnees_randonneeId",
                        column: x => x.randonneeId,
                        principalTable: "randonnees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_commentaires_utilisateurs_utilisateurId",
                        column: x => x.utilisateurId,
                        principalTable: "utilisateurs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gps",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    x = table.Column<double>(type: "REAL", nullable: false),
                    y = table.Column<double>(type: "REAL", nullable: false),
                    depart = table.Column<bool>(type: "INTEGER", nullable: false),
                    arrivee = table.Column<bool>(type: "INTEGER", nullable: false),
                    randonneeId = table.Column<int>(type: "INTEGER", nullable: true),
                    randonneAnglaisId = table.Column<int>(type: "INTEGER", nullable: true),
                    RandonneeAnglaisid = table.Column<int>(type: "INTEGER", nullable: true),
                    RandonneeUtilisateurTraceid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gps", x => x.id);
                    table.ForeignKey(
                        name: "FK_gps_randonneeAnglais_RandonneeAnglaisid",
                        column: x => x.RandonneeAnglaisid,
                        principalTable: "randonneeAnglais",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_gps_randonnees_randonneeId",
                        column: x => x.randonneeId,
                        principalTable: "randonnees",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_gps_utilisateursTrace_RandonneeUtilisateurTraceid",
                        column: x => x.RandonneeUtilisateurTraceid,
                        principalTable: "utilisateursTrace",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7223cd62-c9c8-4778-86bc-7b340ea07174", null, "User", "USER" },
                    { "dda35078-d6c7-42e4-a026-b2fd855a92ec", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", 0, "8ec94ed3-9047-41f0-a876-8433ce3c9009", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEP3Qt62UPHd/j2o81Rth6iEIfbjWhBKiVliAVHqIwNNNRouCXdk1ih8phxV4dfIG5g==", null, false, "637f2a79-d612-44d2-a80b-fc684029e7af", false, "admin@gmail.com" },
                    { "11111111-1111-1111-1111-111111111112", 0, "213552df-a8af-405f-9bb3-b00669edc7db", "user1@hotmail.com", true, false, null, "USER1@HOTMAIL.COM", "USER1@HOTMAIL.COM", "AQAAAAIAAYagAAAAEFYMXQ5SdivbaZYYREQheynRZjNIVFlMIWX4f4JbONcIhmceMdqroMWH90Jr4PBbNA==", null, false, "8d47f3c6-f509-4e9f-adbe-bbcbe55a64e4", false, "user1@hotmail.com" },
                    { "11111111-1111-1111-1111-111111111113", 0, "a3242350-3405-49e5-877a-2bbd79ae6cfa", "user2@hotmail.com", true, false, null, "USER2@HOTMAIL.COM", "USER2@HOTMAIL.COM", "AQAAAAIAAYagAAAAEOQlHF+g2n/rnrVxkknbWL29PvKwK0oocbwEP0eNPzmQ9/UvoCT/R1ZhdGiyVwUWpQ==", null, false, "fabdcf35-27b3-4829-84de-4fbdfa3560a5", false, "user2@hotmail.com" }
                });

            migrationBuilder.InsertData(
                table: "utilisateurs",
                columns: new[] { "id", "adresse", "anneeDeNaissance", "codePostal", "courriel", "identityUserId", "moisDeNaissance", "nom", "prenom", "role" },
                values: new object[,]
                {
                    { 1, "", 0, "E3A 4R4", "admin@gmail.com", "11111111-1111-1111-1111-111111111111", 0, "tangerine", "robert", "Administrator" },
                    { 2, "", 0, "E3A 4R4", "user1@hotmail.com", "11111111-1111-1111-1111-111111111112", 0, "Hogan", "Hulk", "User" },
                    { 3, "1260, rue Mill, suite 100", 0, "E3A 4R4", "user2@hotmail.com", "11111111-1111-1111-1111-111111111113", 0, "Charles", "Grégory", "User" }
                });

            migrationBuilder.InsertData(
                table: "randonnees",
                columns: new[] { "id", "description", "emplacement", "etatRandonnee", "nom", "typeRandonnee", "utilisateurId" },
                values: new object[,]
                {
                    { 1, "promenade cool a st-brun", "st-bruno", 0, "St-Brun", 1, 1 },
                    { 2, "promenade moyennement cool la bas", "dehors", 0, "ptite marche au subway", 0, 2 },
                    { 3, "promenade fresh a bro s s a r d", "st-hilaire?", 0, "Brossard", 1, 3 },
                    { 4, "promenade au subway", "st-grégoire", 0, "ma randonnée pédestre", 0, 2 },
                    { 5, "ça doit être cool la bas", "quelque part", 0, "rivière rouge", 0, 2 },
                    { 6, "je pense qu'on a beaucoup de fun", "mont tremblant", 0, "Ma randonnée", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "gps",
                columns: new[] { "id", "RandonneeAnglaisid", "RandonneeUtilisateurTraceid", "arrivee", "depart", "randonneAnglaisId", "randonneeId", "x", "y" },
                values: new object[,]
                {
                    { 1, null, null, false, true, 1, 1, 45.536653134864743, -73.494974340959118 },
                    { 2, null, null, true, false, 1, 1, 45.636653134864737, -73.594974340959126 },
                    { 3, null, null, false, true, 2, 2, 45.354998999999999, -73.150238000000002 },
                    { 4, null, null, true, false, 2, 2, 45.356924999999997, -73.150233999999998 },
                    { 5, null, null, false, true, 3, 3, 45.538015000000001, -73.156982999999997 },
                    { 6, null, null, true, false, 3, 3, 45.636653134864737, -73.594974340959126 },
                    { 7, null, null, false, true, 4, 4, 45.354998999999999, -73.150238000000002 },
                    { 8, null, null, true, false, 4, 4, 45.356924999999997, -73.150233999999998 },
                    { 9, null, null, false, true, 5, 5, 45.354998999999999, -73.150238000000002 },
                    { 10, null, null, true, false, 5, 5, 45.356924999999997, -73.150233999999998 },
                    { 11, null, null, false, true, 6, 6, 45.354998999999999, -73.160238000000007 },
                    { 12, null, null, true, false, 6, 6, 45.356924999999997, -73.150233999999998 }
                });

            migrationBuilder.InsertData(
                table: "randonneeAnglais",
                columns: new[] { "id", "description", "emplacement", "etatRandonnee", "nom", "randonneeId", "typeRandonnee", "utilisateurId" },
                values: new object[,]
                {
                    { 1, "Cool walk in St-Bruno", "St-Bruno", 0, "St-Bruno", 1, 1, 1 },
                    { 2, "Moderately cool walk there", "Outside", 0, "Little Walk to Subway", 2, 0, 2 },
                    { 3, "Fresh walk in St-Hilaire", "St-Hilaire", 0, "St-Hilaire", 3, 1, 3 },
                    { 4, "Walk to Subway", "St-Grégoire", 0, "My Hiking Trip", 4, 0, 2 },
                    { 5, "It must be cool there", "Somewhere", 0, "Red River", 5, 0, 2 },
                    { 6, "I think it's a lot of fun", "Mont Tremblant", 0, "My Trek", 6, 0, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_avertissements_randonneeId",
                table: "avertissements",
                column: "randonneeId");

            migrationBuilder.CreateIndex(
                name: "IX_commentaires_RandonneeAnglaisid",
                table: "commentaires",
                column: "RandonneeAnglaisid");

            migrationBuilder.CreateIndex(
                name: "IX_commentaires_randonneeId",
                table: "commentaires",
                column: "randonneeId");

            migrationBuilder.CreateIndex(
                name: "IX_commentaires_utilisateurId",
                table: "commentaires",
                column: "utilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_gps_RandonneeAnglaisid",
                table: "gps",
                column: "RandonneeAnglaisid");

            migrationBuilder.CreateIndex(
                name: "IX_gps_randonneeId",
                table: "gps",
                column: "randonneeId");

            migrationBuilder.CreateIndex(
                name: "IX_gps_RandonneeUtilisateurTraceid",
                table: "gps",
                column: "RandonneeUtilisateurTraceid");

            migrationBuilder.CreateIndex(
                name: "IX_images_randonneeId",
                table: "images",
                column: "randonneeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_randonneeAnglais_randonneeId",
                table: "randonneeAnglais",
                column: "randonneeId");

            migrationBuilder.CreateIndex(
                name: "IX_randonneeAnglais_utilisateurId",
                table: "randonneeAnglais",
                column: "utilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_randonnees_utilisateurId",
                table: "randonnees",
                column: "utilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_RandonneeUtilisateur_randonneeId",
                table: "RandonneeUtilisateur",
                column: "randonneeId");

            migrationBuilder.CreateIndex(
                name: "IX_RandonneeUtilisateur_utilisateurId",
                table: "RandonneeUtilisateur",
                column: "utilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_utilisateurs_identityUserId",
                table: "utilisateurs",
                column: "identityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_utilisateursTrace_randonneeId",
                table: "utilisateursTrace",
                column: "randonneeId");

            migrationBuilder.CreateIndex(
                name: "IX_utilisateursTrace_utilisateurId",
                table: "utilisateursTrace",
                column: "utilisateurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "avertissements");

            migrationBuilder.DropTable(
                name: "commentaires");

            migrationBuilder.DropTable(
                name: "gps");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "RandonneeUtilisateur");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "randonneeAnglais");

            migrationBuilder.DropTable(
                name: "utilisateursTrace");

            migrationBuilder.DropTable(
                name: "randonnees");

            migrationBuilder.DropTable(
                name: "utilisateurs");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
