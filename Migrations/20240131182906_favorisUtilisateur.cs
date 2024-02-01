using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class favorisUtilisateur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "29af1e9d-ce64-4705-a479-0436e229fe74", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6cd5ac9d-38fa-4548-9dcb-f2815882d801", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6cd5ac9d-38fa-4548-9dcb-f2815882d801", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29af1e9d-ce64-4705-a479-0436e229fe74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cd5ac9d-38fa-4548-9dcb-f2815882d801");

            migrationBuilder.CreateTable(
                name: "favorisUtilisateur",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    utilisateurId = table.Column<int>(type: "INTEGER", nullable: false),
                    randonneeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favorisUtilisateur", x => x.id);
                    table.ForeignKey(
                        name: "FK_favorisUtilisateur_randonnees_randonneeId",
                        column: x => x.randonneeId,
                        principalTable: "randonnees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_favorisUtilisateur_utilisateurs_utilisateurId",
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
                    { "4265b861-35ed-4067-98d9-c6bd5813a5b7", null, "Administrator", "ADMINISTRATOR" },
                    { "a3b37f10-b6c5-4c01-8308-b4f746b361ae", null, "Randonneur", "RANDONNEUR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f6d6955-6e04-4d20-a214-8a425702c80b", "AQAAAAIAAYagAAAAENWeu1Uv/hIT3FWEAZj+HH728FUy7ArzBIvOV0EtuEH76mvQo8albnsjnnmcruh34A==", "e8cbf8bb-5079-4555-88e7-ecc602850888" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69882215-d7a8-4d08-8fb9-9e9dae903039", "AQAAAAIAAYagAAAAEIgVDHQbx0ITgF1QIYsOBxV1nD+iPqtpZB4eDg71ywsDQJWhPCVJDeJALCMBobE6fA==", "1947ae32-df0a-446a-9f17-2afb8cebbfde" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00c49fa9-54b9-4211-81fe-9cfe9716de63", "AQAAAAIAAYagAAAAEJ8FdnGKvDvdIM1xk45A420Rody2pPFyvcNNVfVL/ExQkgqblLv+xFpLJeNn7UaLig==", "9990394b-3058-44e4-91d6-a47be5a6d4f7" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4265b861-35ed-4067-98d9-c6bd5813a5b7", "11111111-1111-1111-1111-111111111111" },
                    { "a3b37f10-b6c5-4c01-8308-b4f746b361ae", "11111111-1111-1111-1111-111111111112" },
                    { "a3b37f10-b6c5-4c01-8308-b4f746b361ae", "11111111-1111-1111-1111-111111111113" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_favorisUtilisateur_randonneeId",
                table: "favorisUtilisateur",
                column: "randonneeId");

            migrationBuilder.CreateIndex(
                name: "IX_favorisUtilisateur_utilisateurId",
                table: "favorisUtilisateur",
                column: "utilisateurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "favorisUtilisateur");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4265b861-35ed-4067-98d9-c6bd5813a5b7", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a3b37f10-b6c5-4c01-8308-b4f746b361ae", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a3b37f10-b6c5-4c01-8308-b4f746b361ae", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4265b861-35ed-4067-98d9-c6bd5813a5b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3b37f10-b6c5-4c01-8308-b4f746b361ae");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29af1e9d-ce64-4705-a479-0436e229fe74", null, "Administrator", "ADMINISTRATOR" },
                    { "6cd5ac9d-38fa-4548-9dcb-f2815882d801", null, "Randonneur", "RANDONNEUR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2054398-ecca-4017-82d9-19ab926374f8", "AQAAAAIAAYagAAAAEMRKZNxdo1KGdUjA3H8jvzCZaL2yt0ZeYOj4iLsSnwuL/QQgrH980RiFOtfWgwW51w==", "1760a9fc-ae9c-42c5-b9f8-42eea39587af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92eaa2b8-eb96-4ee0-b3b4-92bfbce775f2", "AQAAAAIAAYagAAAAEEQGhN0Ov4kbEcGAKkp4fT9zSYmGsnopIFb2rbumWoFSKa9Zcec7MW4yJ3KyskW/2A==", "8a2bdd74-6715-45c5-ae84-827540738108" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0846703f-ebab-424f-b219-88e57a839669", "AQAAAAIAAYagAAAAEMYdMJsCppqoyB8GsNWnLS8c6YW/R0VYBvi5qNbDPO8oSOR6VGZbM84+WjtKJA1iJA==", "7ef74534-b442-4c56-8a5a-f0c9fa9e7b43" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "29af1e9d-ce64-4705-a479-0436e229fe74", "11111111-1111-1111-1111-111111111111" },
                    { "6cd5ac9d-38fa-4548-9dcb-f2815882d801", "11111111-1111-1111-1111-111111111112" },
                    { "6cd5ac9d-38fa-4548-9dcb-f2815882d801", "11111111-1111-1111-1111-111111111113" }
                });
        }
    }
}
