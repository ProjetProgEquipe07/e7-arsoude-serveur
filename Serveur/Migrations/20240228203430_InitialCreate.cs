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
                name: "randonneeAnglais",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    emplacement = table.Column<string>(type: "TEXT", nullable: true),
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
                name: "avertissementAnglais",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    avertissementId = table.Column<int>(type: "INTEGER", nullable: false),
                    randonneeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avertissementAnglais", x => x.id);
                    table.ForeignKey(
                        name: "FK_avertissementAnglais_avertissements_avertissementId",
                        column: x => x.avertissementId,
                        principalTable: "avertissements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_avertissementAnglais_randonnees_randonneeId",
                        column: x => x.randonneeId,
                        principalTable: "randonnees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.DropTable(
                name: "commentaires");


            migrationBuilder.CreateTable(
                name: "commentaires",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    message = table.Column<string>(type: "TEXT", nullable: true),
                    note = table.Column<int>(type: "INTEGER", nullable: true),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    randonneeId = table.Column<int>(type: "INTEGER", nullable: true),
                    utilisateurId = table.Column<int>(type: "INTEGER", nullable: true),
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
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_commentaires_utilisateurs_utilisateurId",
                        column: x => x.utilisateurId,
                        principalTable: "utilisateurs",
                        principalColumn: "id");
                });

            migrationBuilder.DropTable(
     name: "gps");

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

            migrationBuilder.CreateTable(
                name: "commentaireAnglais",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    message = table.Column<string>(type: "TEXT", nullable: true),
                    commentaireId = table.Column<int>(type: "INTEGER", nullable: false),
                    randonneeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commentaireAnglais", x => x.id);
                    table.ForeignKey(
                        name: "FK_commentaireAnglais_commentaires_commentaireId",
                        column: x => x.commentaireId,
                        principalTable: "commentaires",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_commentaireAnglais_randonnees_randonneeId",
                        column: x => x.randonneeId,
                        principalTable: "randonnees",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_avertissementAnglais_avertissementId",
                table: "avertissementAnglais",
                column: "avertissementId");

            migrationBuilder.CreateIndex(
                name: "IX_avertissementAnglais_randonneeId",
                table: "avertissementAnglais",
                column: "randonneeId");

            migrationBuilder.CreateIndex(
                name: "IX_commentaireAnglais_commentaireId",
                table: "commentaireAnglais",
                column: "commentaireId");

            migrationBuilder.CreateIndex(
                name: "IX_commentaireAnglais_randonneeId",
                table: "commentaireAnglais",
                column: "randonneeId");

            migrationBuilder.CreateIndex(
                name: "IX_commentaires_RandonneeAnglaisid",
                table: "commentaires",
                column: "RandonneeAnglaisid");


            migrationBuilder.CreateIndex(
                name: "IX_gps_RandonneeAnglaisid",
                table: "gps",
                column: "RandonneeAnglaisid");

            migrationBuilder.CreateIndex(
                name: "IX_randonneeAnglais_randonneeId",
                table: "randonneeAnglais",
                column: "randonneeId");

            migrationBuilder.CreateIndex(
                name: "IX_randonneeAnglais_utilisateurId",
                table: "randonneeAnglais",
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
                name: "avertissementAnglais");

            migrationBuilder.DropTable(
                name: "commentaireAnglais");

            migrationBuilder.DropTable(
                name: "CommentaireUtilisateur");

            migrationBuilder.DropTable(
                name: "gps");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "RandonneeUtilisateur");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "avertissements");

            migrationBuilder.DropTable(
                name: "commentaires");

            migrationBuilder.DropTable(
                name: "utilisateursTrace");

            migrationBuilder.DropTable(
                name: "randonneeAnglais");

            migrationBuilder.DropTable(
                name: "publication");

            migrationBuilder.DropTable(
                name: "randonnees");

            migrationBuilder.DropTable(
                name: "utilisateurs");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
