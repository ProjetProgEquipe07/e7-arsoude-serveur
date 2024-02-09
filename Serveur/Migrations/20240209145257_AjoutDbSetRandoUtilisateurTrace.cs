using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class AjoutDbSetRandoUtilisateurTrace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gps_RandonneeUtilisateurTrace_RandonneeUtilisateurTraceid",
                table: "gps");

            migrationBuilder.DropForeignKey(
                name: "FK_RandonneeUtilisateurTrace_randonnees_randonneeId",
                table: "RandonneeUtilisateurTrace");

            migrationBuilder.DropForeignKey(
                name: "FK_RandonneeUtilisateurTrace_utilisateurs_utilisateurId",
                table: "RandonneeUtilisateurTrace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RandonneeUtilisateurTrace",
                table: "RandonneeUtilisateurTrace");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edd86992-441b-47ff-93f7-4ad50e7e812f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffc9d022-608b-4796-974d-589296108496");

            migrationBuilder.RenameTable(
                name: "RandonneeUtilisateurTrace",
                newName: "utilisateursTrace");

            migrationBuilder.RenameIndex(
                name: "IX_RandonneeUtilisateurTrace_utilisateurId",
                table: "utilisateursTrace",
                newName: "IX_utilisateursTrace_utilisateurId");

            migrationBuilder.RenameIndex(
                name: "IX_RandonneeUtilisateurTrace_randonneeId",
                table: "utilisateursTrace",
                newName: "IX_utilisateursTrace_randonneeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_utilisateursTrace",
                table: "utilisateursTrace",
                column: "id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6855fa68-6584-4ad1-846a-6b3592390881", null, "Administrator", "ADMINISTRATOR" },
                    { "eee1d3b3-eafc-4f3e-90ca-e43796b8ffb5", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ffd82bb-cc1c-4b08-ac30-e3a3ef0d475b", "AQAAAAIAAYagAAAAEOjtlx2WJFNP3WVynbEz2TnW2O3s+VDWprqTzwhmpsa5LrnV6u/5eiqQC6fatbipIA==", "d1927159-e21a-449f-b845-6e2c07bb9c94" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "907be8bd-8490-4a2c-b6a5-b3fb06743d82", "AQAAAAIAAYagAAAAEDezXX0H6tjw2UAejDzNLlTM69eA2aV53tm0Hti43cVsbiqArkZVx5D1HGXeroHB9Q==", "1d999d95-407d-4942-8be7-e096c2378c2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6679e015-2b15-4bc2-84d3-6e1e086f2b20", "AQAAAAIAAYagAAAAELj9JnwEd1PuLGCwHz41zwR6cFCtQmSWVpmQ3RR3oMuy1yNjQAUOMKgpozmLkcyAow==", "d5b69f8c-d0f2-4813-bfe3-79a3168ca676" });

            migrationBuilder.AddForeignKey(
                name: "FK_gps_utilisateursTrace_RandonneeUtilisateurTraceid",
                table: "gps",
                column: "RandonneeUtilisateurTraceid",
                principalTable: "utilisateursTrace",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_utilisateursTrace_randonnees_randonneeId",
                table: "utilisateursTrace",
                column: "randonneeId",
                principalTable: "randonnees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_utilisateursTrace_utilisateurs_utilisateurId",
                table: "utilisateursTrace",
                column: "utilisateurId",
                principalTable: "utilisateurs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gps_utilisateursTrace_RandonneeUtilisateurTraceid",
                table: "gps");

            migrationBuilder.DropForeignKey(
                name: "FK_utilisateursTrace_randonnees_randonneeId",
                table: "utilisateursTrace");

            migrationBuilder.DropForeignKey(
                name: "FK_utilisateursTrace_utilisateurs_utilisateurId",
                table: "utilisateursTrace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_utilisateursTrace",
                table: "utilisateursTrace");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6855fa68-6584-4ad1-846a-6b3592390881");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eee1d3b3-eafc-4f3e-90ca-e43796b8ffb5");

            migrationBuilder.RenameTable(
                name: "utilisateursTrace",
                newName: "RandonneeUtilisateurTrace");

            migrationBuilder.RenameIndex(
                name: "IX_utilisateursTrace_utilisateurId",
                table: "RandonneeUtilisateurTrace",
                newName: "IX_RandonneeUtilisateurTrace_utilisateurId");

            migrationBuilder.RenameIndex(
                name: "IX_utilisateursTrace_randonneeId",
                table: "RandonneeUtilisateurTrace",
                newName: "IX_RandonneeUtilisateurTrace_randonneeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RandonneeUtilisateurTrace",
                table: "RandonneeUtilisateurTrace",
                column: "id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "edd86992-441b-47ff-93f7-4ad50e7e812f", null, "Administrator", "ADMINISTRATOR" },
                    { "ffc9d022-608b-4796-974d-589296108496", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea299a5c-ec3f-45b3-8da6-973ba198ce25", "AQAAAAIAAYagAAAAECB+AvKSB9bt1t1Vu6BrnvR7MlpGPRUCObbNqK9AXv+f3sWeITFRr0Kp1hnLjiSzLw==", "7fefc947-8c9b-4e34-9de1-3cac9e91fc49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8090bf0a-7c0b-4347-904a-63dc728e6c78", "AQAAAAIAAYagAAAAEJs/xhWXv59YuSBQZYQb69q5plNsAsvLCEr6p+K6VcikStwRjid4aBz/CZlVp9G+Rg==", "039ead9b-ec09-4bb5-acb6-aafdea3bec73" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9834014-d33b-4591-8610-95bebf17dd75", "AQAAAAIAAYagAAAAEKRh/2/c+i4wIzIFRLxKZiFJAhxcjf25nNKGce6Tc6Hsb73bs95J8AdtF+R3wTalPQ==", "d742c2d6-6841-4645-90f1-542b51c73a73" });

            migrationBuilder.AddForeignKey(
                name: "FK_gps_RandonneeUtilisateurTrace_RandonneeUtilisateurTraceid",
                table: "gps",
                column: "RandonneeUtilisateurTraceid",
                principalTable: "RandonneeUtilisateurTrace",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_RandonneeUtilisateurTrace_randonnees_randonneeId",
                table: "RandonneeUtilisateurTrace",
                column: "randonneeId",
                principalTable: "randonnees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RandonneeUtilisateurTrace_utilisateurs_utilisateurId",
                table: "RandonneeUtilisateurTrace",
                column: "utilisateurId",
                principalTable: "utilisateurs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
