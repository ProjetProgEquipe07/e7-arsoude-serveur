using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class Userfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b81c2cd-f31a-42ea-acd3-bff3093dd325");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e68df4fc-b8bd-4366-8557-85878be6dddb");

            migrationBuilder.AddColumn<int>(
                name: "Publicationid",
                table: "utilisateurs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "publication",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    etat = table.Column<int>(type: "INTEGER", nullable: false),
                    randonneeId = table.Column<int>(type: "INTEGER", nullable: false),
                    utilisateurId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publication", x => x.id);
                    table.ForeignKey(
                        name: "FK_publication_randonnees_randonneeId",
                        column: x => x.randonneeId,
                        principalTable: "randonnees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_publication_utilisateurs_utilisateurId",
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
                    { "2cdc13c0-a112-4bc8-ae64-ea0bf3736097", null, "User", "USER" },
                    { "751299d8-d882-4c1a-a660-d8bb60fbefbc", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79440125-799f-4e18-a232-f7a85bb6788a", "AQAAAAIAAYagAAAAEARc9KI8hnLAseFRTzBlKdHB+zZjMAsgp7Dxym1mVYMPjvQKlMLlgVof0GBIBVDEOA==", "d9d46119-4fa8-424a-a353-42733a6f0aa5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "389ec59a-f8b0-4dc0-927b-19967d1f3338", "AQAAAAIAAYagAAAAELJlbI/jkycyD0ad54/9JXlB0VhpOzx5pgCsxVv6EQiNw0HPVLVh2DgWCy8j2rcWbg==", "e4969408-eaf4-45d4-9b94-a316d7b5ea7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d3feacb-02e3-4698-8a2e-6539b16b0545", "AQAAAAIAAYagAAAAEMqDMIl29HGgImTIY6gDIcaEAlkuQhwN/btPHJCiIy9HlZAOczSSQAFeakDk2V1Haw==", "5b08d0aa-e895-402b-9f0b-5bd1098be43b" });

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

            migrationBuilder.CreateIndex(
                name: "IX_publication_randonneeId",
                table: "publication",
                column: "randonneeId");

            migrationBuilder.CreateIndex(
                name: "IX_publication_utilisateurId",
                table: "publication",
                column: "utilisateurId");

            migrationBuilder.AddForeignKey(
                name: "FK_utilisateurs_publication_Publicationid",
                table: "utilisateurs",
                column: "Publicationid",
                principalTable: "publication",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_utilisateurs_publication_Publicationid",
                table: "utilisateurs");

            migrationBuilder.DropTable(
                name: "publication");

            migrationBuilder.DropIndex(
                name: "IX_utilisateurs_Publicationid",
                table: "utilisateurs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cdc13c0-a112-4bc8-ae64-ea0bf3736097");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "751299d8-d882-4c1a-a660-d8bb60fbefbc");

            migrationBuilder.DropColumn(
                name: "Publicationid",
                table: "utilisateurs");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9b81c2cd-f31a-42ea-acd3-bff3093dd325", null, "User", "USER" },
                    { "e68df4fc-b8bd-4366-8557-85878be6dddb", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08cda59a-a57d-4b44-b0e8-c04d00ccb37d", "AQAAAAIAAYagAAAAEE3ShvCqEpZkx0h6N9mbX51VDPAPuifMcbXDDKg3sbeTr8o3saxRKTbNPVHe0fgmEQ==", "ac08ce5b-ac9b-4a92-8b80-1e17670a9fbf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e95aead7-986c-41ea-b7ff-625559339538", "AQAAAAIAAYagAAAAEIiKePQofmC+0+WsLq85q+2wAwj1pc2+VbEmEInEEkB1SuTkCIf3JJzqc9W60r3LBQ==", "27d56524-9a30-4ca8-9d0b-151460eb7c8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1af5cfc0-1b5a-4c56-882b-54baafb02b35", "AQAAAAIAAYagAAAAEIrBi6AqxJIxjNn30u85KIWM72/F9m299VnwTPh97NKNS93OI3rgSSLmevaQLtl5WQ==", "65d914b8-91a9-4cb6-a3aa-7950fc4da453" });
        }
    }
}
