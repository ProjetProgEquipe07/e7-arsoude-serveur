using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class Userfix5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_utilisateurs_publication_Publicationid",
                table: "utilisateurs");

            migrationBuilder.DropIndex(
                name: "IX_utilisateurs_Publicationid",
                table: "utilisateurs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "381377c4-e577-4cd1-90c8-3fc173629eef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbfc6b73-fc48-4d7b-bdd4-8525fe894474");

            migrationBuilder.DropColumn(
                name: "Publicationid",
                table: "utilisateurs");

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    utilisateurId = table.Column<int>(type: "INTEGER", nullable: false),
                    publicationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.id);
                    table.ForeignKey(
                        name: "FK_Like_publication_publicationId",
                        column: x => x.publicationId,
                        principalTable: "publication",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Like_utilisateurs_utilisateurId",
                        column: x => x.utilisateurId,
                        principalTable: "utilisateurs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a44d364c-0724-4b4f-a8ea-b9495593a885", null, "Administrator", "ADMINISTRATOR" },
                    { "c3dd523b-e6e6-4800-a6d2-f61c153d7f2f", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78d51754-943d-424a-9f38-610a18a58607", "AQAAAAIAAYagAAAAED0M3rJarW1T8S2vB2lXUxrMTP6SCpREZvO354Y7uIFhi+SatsvxxAjHMYLmI2tqbg==", "6c78dfdf-fe76-4a01-aab1-3a6175d03bc1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05c218da-d2a9-4def-b485-0157fe89dae8", "AQAAAAIAAYagAAAAEIdTf65l3QXXABigvHWuhLziFKy7KhhLn5FsN0VvXLIBIhGHm0iE4XeqXFkbIQSqOg==", "b7f09175-5582-4b61-ac4a-0c796d3ca005" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e424e846-07ec-4831-b8c9-110f89d0c4d5", "AQAAAAIAAYagAAAAEIB3h4HHX7MdVn5hCbnPySEX3KjCA/8vnfZF4JpxDn8T3cfeTp+mOqiY+YUeyAMt0A==", "1ba0b06a-e9dd-45e1-a726-b4361244e3a2" });

            migrationBuilder.CreateIndex(
                name: "IX_Like_publicationId",
                table: "Like",
                column: "publicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_utilisateurId",
                table: "Like",
                column: "utilisateurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a44d364c-0724-4b4f-a8ea-b9495593a885");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3dd523b-e6e6-4800-a6d2-f61c153d7f2f");

            migrationBuilder.AddColumn<int>(
                name: "Publicationid",
                table: "utilisateurs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "381377c4-e577-4cd1-90c8-3fc173629eef", null, "Administrator", "ADMINISTRATOR" },
                    { "cbfc6b73-fc48-4d7b-bdd4-8525fe894474", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86da64f4-eb5a-481b-85cb-15244fd27fde", "AQAAAAIAAYagAAAAECWOvXfQ1ik9YINjsdAcw0xgotRdS+cHSIz0CrzjtFO/4pBisQPmtWS/JSQFXCarJg==", "dfc8b5d8-49f5-47ba-912c-910606550bc1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c16fd60-5343-4caa-b728-59cb8fb088f1", "AQAAAAIAAYagAAAAECxkN+3EEJEpgcxpvu67wzB0j8+LOSPFGuKz41uZ1d9JZrcKkbsSq8XciEuAlQNoJA==", "21f3dc8f-96d3-499e-be4b-0e8a43504798" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b70aad8-bcc5-4e4c-91cf-7bce43cbadec", "AQAAAAIAAYagAAAAECa0dSlMmbsszEq2/WmgxKiLCWBp1cegNnnuFdKIojh4Uu+iOMsARK2NDnplu7lzig==", "5d00e2af-fb81-4f43-a886-ba773e035299" });

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 1,
                column: "Publicationid",
                value: null);

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 2,
                column: "Publicationid",
                value: null);

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 3,
                column: "Publicationid",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_utilisateurs_Publicationid",
                table: "utilisateurs",
                column: "Publicationid");

            migrationBuilder.AddForeignKey(
                name: "FK_utilisateurs_publication_Publicationid",
                table: "utilisateurs",
                column: "Publicationid",
                principalTable: "publication",
                principalColumn: "id");
        }
    }
}
