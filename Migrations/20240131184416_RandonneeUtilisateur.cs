using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class RandonneeUtilisateur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "058092cb-e76e-4233-be2b-9cae7e716143", null, "Administrator", "ADMINISTRATOR" },
                    { "7f721c52-ddab-4275-90ef-008e53466faf", null, "Randonneur", "RANDONNEUR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83345033-9329-4a8d-8dbf-7791995679f5", "AQAAAAIAAYagAAAAEK3cu0CJRvLbr8hsSveU34kMN21Y8PCOrk3B9NWKz/Lt6hBucZcQhHVwrocEEDicZA==", "22698b79-ea5b-4e46-bd9c-50c8926ed141" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbdc7aeb-556c-4a4c-baa3-eedc4522b14a", "AQAAAAIAAYagAAAAEHa7oyN3PUi/7aKzFOVIvH08v7CYnRiS3iuxlP/WPrLpLKIEsGNUsfdNK4XAfq7J8A==", "1454897c-124c-4d12-92a9-e3f61e4212d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c9284c7-dd9a-4219-b336-7eb9f8b13e94", "AQAAAAIAAYagAAAAEF82SjKZFgjP4dCszIo0OevoOOyHIJROfWk6s65JixYA+NzZlpQ0DDSxo79qvf6aPA==", "f3aab6c3-a77a-4f6b-b61c-c3d155a1c071" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "058092cb-e76e-4233-be2b-9cae7e716143", "11111111-1111-1111-1111-111111111111" },
                    { "7f721c52-ddab-4275-90ef-008e53466faf", "11111111-1111-1111-1111-111111111112" },
                    { "7f721c52-ddab-4275-90ef-008e53466faf", "11111111-1111-1111-1111-111111111113" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RandonneeUtilisateur_randonneeId",
                table: "RandonneeUtilisateur",
                column: "randonneeId");

            migrationBuilder.CreateIndex(
                name: "IX_RandonneeUtilisateur_utilisateurId",
                table: "RandonneeUtilisateur",
                column: "utilisateurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RandonneeUtilisateur");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "058092cb-e76e-4233-be2b-9cae7e716143", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7f721c52-ddab-4275-90ef-008e53466faf", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7f721c52-ddab-4275-90ef-008e53466faf", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "058092cb-e76e-4233-be2b-9cae7e716143");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f721c52-ddab-4275-90ef-008e53466faf");

            migrationBuilder.CreateTable(
                name: "favorisUtilisateur",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    randonneeId = table.Column<int>(type: "INTEGER", nullable: false),
                    utilisateurId = table.Column<int>(type: "INTEGER", nullable: false)
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
    }
}
