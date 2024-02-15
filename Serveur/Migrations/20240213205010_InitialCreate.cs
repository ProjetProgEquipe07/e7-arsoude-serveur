using System;
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
                name: "commentaires",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    texte = table.Column<string>(type: "TEXT", nullable: true),
                    review = table.Column<int>(type: "INTEGER", nullable: false),
                    randonneeId = table.Column<int>(type: "INTEGER", nullable: false),
                    utilisateurId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commentaires", x => x.id);
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
                    RandonneeUtilisateurTraceid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gps", x => x.id);
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
                    { "664b588a-399f-4509-8e5b-5eabbf47612c", null, "Administrator", "ADMINISTRATOR" },
                    { "a7465334-d9c5-420f-a04b-981bbeef25a2", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", 0, "529ee0e3-bd4b-4c6e-b873-e6c04353909f", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAENRZImkcK8pQ3i7C7AQGxnkgQ1uHlWF1jc7bEaop+vxMHpwy2fPepTqA7+nCuBuFyQ==", null, false, "3bc9ce4e-5e80-48a6-9498-9a82d6ceedb8", false, "admin@gmail.com" },
                    { "11111111-1111-1111-1111-111111111112", 0, "660289db-bf2e-4478-9b69-2432d2f75f91", "user1@hotmail.com", true, false, null, "USER1@HOTMAIL.COM", "USER1@HOTMAIL.COM", "AQAAAAIAAYagAAAAED/NVun3qmu5+xcfB9Sn7RnUlZ3vUXQhBwqn6HnkuK2qWGZhPhxSPopdzUse2Cr4ZA==", null, false, "c8552cf6-2525-4cbe-9682-d3c94bb792cd", false, "user1@hotmail.com" },
                    { "11111111-1111-1111-1111-111111111113", 0, "90f947bf-cf57-4a8d-bc2a-78d026547fea", "user2@hotmail.com", true, false, null, "USER2@HOTMAIL.COM", "USER2@HOTMAIL.COM", "AQAAAAIAAYagAAAAED2L1sEQTWgrT5qQJs6eDbabj30PmKxhvK+3xzpBkZl4mh8EV4t+aypWn5EfJbljXA==", null, false, "0abce4d6-e625-4189-96d8-f503f50c121e", false, "user2@hotmail.com" }
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
                    { 1, "promenade cool a st-brun", "st-bruno", 1, "St-Brun", 1, 1 },
                    { 2, "promenade moyennement cool la bas", "dehors", 1, "ptite marche au subway", 0, 2 },
                    { 3, "promenade fresh a bro s s a r d", "st-hilaire?", 1, "Brossard", 1, 3 },
                    { 4, "promenade au subway", "st-grégoire", 0, "ma randonnée pédestre", 0, 2 },
                    { 5, "ça doit être cool la bas", "quelque part", 2, "rivière rouge", 0, 2 },
                    { 6, "je pense qu'on a beaucoup de fun", "mont tremblant", 1, "Ma randonnée", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "commentaires",
                columns: new[] { "id", "randonneeId", "review", "texte", "utilisateurId" },
                values: new object[,]
                {
                    { 1, 1, 3, "You are a worthless bitch ass nigga\r\nYour life literally is as valuable as a summer ant. I'm just gonna stomp you.\r\nYou're gonna keep coming back. I'm gonna seal up all my cracks, youre gonna keep coming back\r\n \r\nWhy? Cause you keep smelling the syrup, you worthless bitch ass nigga. Your gonna stay on my dick until you die.\r\nYou serve no purpose in life. Your purpose in life is to be on my stream sucking on my dick daily.\r\n \r\nYour purpose in life is to be in that chat, blowing a dick daily.\r\nYour life is nothing!\r\nYou serve zero purpose. You should kill yourself NOW.\r\nAnd give somebody else a piece of that oxygen, an ozone layer thats covered up so we can breathe inside this blue trapped  bubble, cause what are you here for? To worship me? Kill yourself. I mean that not a 100% but a thousand percent.\r\n \r\nImagine if a nigga like that has kids. Like imagine somebody like that has kids", 2 },
                    { 2, 2, 3, "Imagine if a nigga like that has kids. Like imagine. Imagine if somebody like that has kids. I will feel so sorry for his children cause the nigga literally serves no purpose. Imagine a father, now we got a lot of niggas with wife and kids and shit like that who keeps sucking on my dick daily on the internet but imagine if this nigga actually had children. This niggas devoting the time he could be spending with his kids checking out a black man on stream cucking him relentlessly. That's crazy! I've never seen somebody so relentless to be seen. Somebody so worthless that they'll come into this stream and keep coming in this bitch over and over and over and over and over again when we keep banning you\r\nNigga let me.. let me.. let's do you a favor", 1 },
                    { 3, 4, 3, "Lets go to the 99 cents store and lets pick out a rope together. Imma give you an assisted suicide. Lets pick out a rope together right? And we're gonna take all the greatest trolls clips, put a tv screen right in front of you.\r\nI'm gonna hang that rope at the top of the motherfucking garage.\r\nWe're gonna forcefully pry your eyes open, we probably don't even need to do that cause your on my dick daily. We're gonna pry your eyes open until you consistently watch clips over and over and over and over again to the point where you're gonna be like 'Wait a minute, this is a little bit too much'\r\nYou're just gonna start going crazy.\r\nYou're gonna start going crazy.\r\nJust, your eyes are gonna bleed your retinas are just gonna start pouring out, pouring out blood and just getting\r\ncracks and veins in your retinas are gonna start engaging and bulging. Then I'm gonna grab that rope for you and say 'Are you ready?' You're gonna say 'Yeah' I'm gonna take it and PULL IT\r\nwhile you beg me, beg me and I mean beg me to kill you and choke you, choke the worthless life out of your sorry ass until you're fucking dead, croaked with a blue face nigga. Cause you don't deserve your soul.\r\nI've never seen somebody so fucking worthless and relentless that keep coming in a niggas chat over and over and over again. Somebody like that needs to die.\r\nThere is really no reason for him to be alive. We lost prominent niggas on earth, that served a purpose that had... so this nigga could be on earth trolling a stream daily, like come on my nigga. Like, your life is just worthless, just please kill yourself.\r\nGo outside, throw some steaks in a fucking alley and hope a bunch of stray dogs jump on you starts chewing your fucking dick your dick off, biting pieces and shit off of you like that cause you literally just gotta go. Like this nigga off of earth. Please", 2 },
                    { 4, 2, 1, "Lets go to the 99 cents store and lets pick out a rope together. Imma give you an assisted suicide. Lets pick out a rope together right? And we're gonna take all the greatest trolls clips, put a tv screen right in front of you.\r\nI'm gonna hang that rope at the top of the motherfucking garage.\r\nWe're gonna forcefully pry your eyes open, we probably don't even need to do that cause your on my dick daily. We're gonna pry your eyes open until you consistently watch clips over and over and over and over again to the point where you're gonna be like 'Wait a minute, this is a little bit too much'\r\nYou're just gonna start going crazy.\r\nYou're gonna start going crazy.\r\nJust, your eyes are gonna bleed your retinas are just gonna start pouring out, pouring out blood and just getting\r\ncracks and veins in your retinas are gonna start engaging and bulging. Then I'm gonna grab that rope for you and say 'Are you ready?' You're gonna say 'Yeah' I'm gonna take it and PULL IT\r\nwhile you beg me, beg me and I mean beg me to kill you and choke you, choke the worthless life out of your sorry ass until you're fucking dead, croaked with a blue face nigga. Cause you don't deserve your soul.\r\nI've never seen somebody so fucking worthless and relentless that keep coming in a niggas chat over and over and over again. Somebody like that needs to die.\r\nThere is really no reason for him to be alive. We lost prominent niggas on earth, that served a purpose that had... so this nigga could be on earth trolling a stream daily, like come on my nigga. Like, your life is just worthless, just please kill yourself.\r\nGo outside, throw some steaks in a fucking alley and hope a bunch of stray dogs jump on you starts chewing your fucking dick your dick off, biting pieces and shit off of you like that cause you literally just gotta go. Like this nigga off of earth. Please", 3 },
                    { 5, 6, 5, "Lets go to the 99 cents store and lets pick out a rope together. Imma give you an assisted suicide. Lets pick out a rope together right? And we're gonna take all the greatest trolls clips, put a tv screen right in front of you.\r\nI'm gonna hang that rope at the top of the motherfucking garage.\r\nWe're gonna forcefully pry your eyes open, we probably don't even need to do that cause your on my dick daily. We're gonna pry your eyes open until you consistently watch clips over and over and over and over again to the point where you're gonna be like 'Wait a minute, this is a little bit too much'\r\nYou're just gonna start going crazy.\r\nYou're gonna start going crazy.\r\nJust, your eyes are gonna bleed your retinas are just gonna start pouring out, pouring out blood and just getting\r\ncracks and veins in your retinas are gonna start engaging and bulging. Then I'm gonna grab that rope for you and say 'Are you ready?' You're gonna say 'Yeah' I'm gonna take it and PULL IT\r\nwhile you beg me, beg me and I mean beg me to kill you and choke you, choke the worthless life out of your sorry ass until you're fucking dead, croaked with a blue face nigga. Cause you don't deserve your soul.\r\nI've never seen somebody so fucking worthless and relentless that keep coming in a niggas chat over and over and over again. Somebody like that needs to die.\r\nThere is really no reason for him to be alive. We lost prominent niggas on earth, that served a purpose that had... so this nigga could be on earth trolling a stream daily, like come on my nigga. Like, your life is just worthless, just please kill yourself.\r\nGo outside, throw some steaks in a fucking alley and hope a bunch of stray dogs jump on you starts chewing your fucking dick your dick off, biting pieces and shit off of you like that cause you literally just gotta go. Like this nigga off of earth. Please", 3 }
                });

            migrationBuilder.InsertData(
                table: "gps",
                columns: new[] { "id", "RandonneeUtilisateurTraceid", "arrivee", "depart", "randonneeId", "x", "y" },
                values: new object[,]
                {
                    { 1, null, false, true, 1, 45.536653134864743, -73.494974340959118 },
                    { 2, null, true, false, 1, 45.636653134864737, -73.594974340959126 },
                    { 3, null, false, true, 2, 45.354998999999999, -73.150238000000002 },
                    { 4, null, true, false, 2, 45.356924999999997, -73.150233999999998 },
                    { 5, null, false, true, 3, 45.538015000000001, -73.156982999999997 },
                    { 6, null, true, false, 3, 45.636653134864737, -73.594974340959126 },
                    { 7, null, false, true, 4, 45.354998999999999, -73.150238000000002 },
                    { 8, null, true, false, 4, 45.356924999999997, -73.150233999999998 },
                    { 9, null, false, true, 5, 45.354998999999999, -73.150238000000002 },
                    { 10, null, true, false, 5, 45.356924999999997, -73.150233999999998 },
                    { 11, null, false, true, 6, 45.354998999999999, -73.160238000000007 },
                    { 12, null, true, false, 6, 45.356924999999997, -73.150233999999998 }
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
                name: "IX_commentaires_randonneeId",
                table: "commentaires",
                column: "randonneeId");

            migrationBuilder.CreateIndex(
                name: "IX_commentaires_utilisateurId",
                table: "commentaires",
                column: "utilisateurId");

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
