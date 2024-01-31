﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                name: "commentaires",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    texte = table.Column<string>(type: "TEXT", nullable: false),
                    randonnéeId = table.Column<int>(type: "INTEGER", nullable: false),
                    randonneeid = table.Column<int>(type: "INTEGER", nullable: false),
                    utilisateurId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commentaires", x => x.id);
                    table.ForeignKey(
                        name: "FK_commentaires_randonnees_randonneeid",
                        column: x => x.randonneeid,
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
                    X = table.Column<double>(type: "REAL", nullable: false),
                    Y = table.Column<double>(type: "REAL", nullable: false),
                    Depart = table.Column<bool>(type: "INTEGER", nullable: false),
                    Arrivee = table.Column<bool>(type: "INTEGER", nullable: false),
                    randonneeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gps", x => x.id);
                    table.ForeignKey(
                        name: "FK_gps_randonnees_randonneeId",
                        column: x => x.randonneeId,
                        principalTable: "randonnees",
                        principalColumn: "id");
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "067b7ef7-4111-4b9f-a5b6-6567e4e2a35f", null, "User", "USER" },
                    { "24f84c96-2a16-4e7b-b8ed-c95580415e4b", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", 0, "5f1f5b2c-d1e4-4c04-a297-e8cfea726781", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEP0HfwetNRemUykD29jAhZoO3kypm8jkHReIVGokcFe91FMXDWPYLbeL0YlcR7RQkw==", null, false, "d91f2a6f-0e32-49bb-b151-399b3604078f", false, "admin@gmail.com" },
                    { "11111111-1111-1111-1111-111111111112", 0, "1f5215b9-3bbc-43ad-90f1-0c4793ac9d18", "user1@hotmail.com", true, false, null, "USER1@HOTMAIL.COM", "USER1@HOTMAIL.COM", "AQAAAAIAAYagAAAAEE5uNyvZaw/hOYfWf5/jpB+QTRj705QIConAfM/U6M5JlE+WQolP5kU5JwUc/bFNNQ==", null, false, "469c0106-3d76-47b4-aae0-a1db89f1475b", false, "user1@hotmail.com" },
                    { "11111111-1111-1111-1111-111111111113", 0, "a51ec699-6a73-457c-abf8-27433905c743", "user2@hotmail.com", true, false, null, "USER2@HOTMAIL.COM", "USER2@HOTMAIL.COM", "AQAAAAIAAYagAAAAEI7xGfFPUXDtFHZScV3/1mQwyS8w4gbGUHmHWqKbwKVZksfST1SG+6SZMCjt686Lpg==", null, false, "e8b1978f-7453-4acf-9b53-612416ae4955", false, "user2@hotmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "24f84c96-2a16-4e7b-b8ed-c95580415e4b", "11111111-1111-1111-1111-111111111111" },
                    { "067b7ef7-4111-4b9f-a5b6-6567e4e2a35f", "11111111-1111-1111-1111-111111111112" },
                    { "067b7ef7-4111-4b9f-a5b6-6567e4e2a35f", "11111111-1111-1111-1111-111111111113" }
                });

            migrationBuilder.InsertData(
                table: "utilisateurs",
                columns: new[] { "id", "adresse", "anneeDeNaissance", "codePostal", "courriel", "identityUserId", "moisDeNaissance", "nom", "prenom" },
                values: new object[,]
                {
                    { 1, null, 0, "E3A4R4", "admin@gmail.com", "11111111-1111-1111-1111-111111111111", 0, "tangerine", "robert" },
                    { 2, null, 0, "E3A4R4", "user1@hotmail.com", "11111111-1111-1111-1111-111111111112", 0, "Hogan", "Hulk" },
                    { 3, null, 0, "E3A4R4", "user2@hotmail.com", "11111111-1111-1111-1111-111111111113", 0, "Charles", "Grégory" }
                });

            migrationBuilder.InsertData(
                table: "randonnees",
                columns: new[] { "id", "description", "emplacement", "nom", "typeRandonnee", "utilisateurId" },
                values: new object[,]
                {
                    { 1, "promenade cool a st-brun", "st-bruno", "St-Bruno", 1, 1 },
                    { 2, "promenade moyennement cool la bas", "dehors", "ptite marche au subway", 0, 2 },
                    { 3, "promenade fresh a st-hilaire", "st-hilaire", "st-hilaire", 1, 3 },
                    { 4, "promenade au subway", "st-grégoire", "ma randonnée pédestre", 0, 2 },
                    { 5, "ça doit être cool la bas", "quelque part", "rivière rouge", 0, 2 },
                    { 6, "je pense qu'on a beaucoup de fun", "mont tremblant", "Ma randonnée", 0, 1 },
                    { 7, "J'ai eu beaucoup de plaisir", "st-jérome", "ayyyyyy", 0, 2 },
                    { 8, "moyennement le fun pour vrai", "ottoburn park", "st-grégoire", 0, 3 },
                    { 9, "lylian voulait une belle randonnée au tim", "gentilly ouest", "la randonnée a lylian", 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "gps",
                columns: new[] { "id", "Arrivee", "Depart", "X", "Y", "randonneeId" },
                values: new object[,]
                {
                    { 1, false, true, 45.536653134864743, -73.494974340959118, 1 },
                    { 2, true, false, 45.636653134864737, -73.594974340959126, 1 },
                    { 3, false, true, 45.354998999999999, -73.150238000000002, 2 },
                    { 4, true, false, 45.356924999999997, -73.150233999999998, 2 },
                    { 5, false, true, 45.538015000000001, -73.156982999999997, 3 },
                    { 6, true, false, 45.636653134864737, -73.594974340959126, 3 },
                    { 7, false, true, 45.354998999999999, -73.150238000000002, 4 },
                    { 8, true, false, 45.356924999999997, -73.150233999999998, 4 },
                    { 9, false, true, 45.354998999999999, -73.150238000000002, 5 },
                    { 10, true, false, 45.356924999999997, -73.150233999999998, 5 },
                    { 11, false, true, 45.354998999999999, -73.160238000000007, 6 },
                    { 12, true, false, 45.356924999999997, -73.150233999999998, 6 },
                    { 13, false, true, 45.364998999999997, -73.110237999999995, 7 },
                    { 14, true, false, 45.386924999999998, -73.152234000000007, 7 },
                    { 15, false, true, 45.364998999999997, -73.166238000000007, 8 },
                    { 16, true, false, 45.456924999999998, -73.128234000000006, 8 },
                    { 17, false, true, 45.541245000000004, -73.490803999999997, 9 },
                    { 18, true, false, 45.535905999999997, -73.496853000000002, 8 }
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
                name: "IX_commentaires_randonneeid",
                table: "commentaires",
                column: "randonneeid");

            migrationBuilder.CreateIndex(
                name: "IX_commentaires_utilisateurId",
                table: "commentaires",
                column: "utilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_gps_randonneeId",
                table: "gps",
                column: "randonneeId");

            migrationBuilder.CreateIndex(
                name: "IX_images_randonneeId",
                table: "images",
                column: "randonneeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_randonnees_utilisateurId",
                table: "randonnees",
                column: "utilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_utilisateurs_identityUserId",
                table: "utilisateurs",
                column: "identityUserId");
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
                name: "commentaires");

            migrationBuilder.DropTable(
                name: "gps");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "randonnees");

            migrationBuilder.DropTable(
                name: "utilisateurs");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}