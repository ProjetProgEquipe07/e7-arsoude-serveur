using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class AjoutAvertissementModelControllerService3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9df08dfc-8771-4c9f-8aeb-cc4be48fe024");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b170c6f8-f27c-49e8-b2e7-79fc92065841");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5d249d5d-d656-4bb6-bf80-658093861e23", null, "Administrator", "ADMINISTRATOR" },
                    { "b37d5a10-ce4d-4f54-a7d6-2b6346830551", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33fca2ea-a97f-4b24-9985-b352a115a714", "AQAAAAIAAYagAAAAEKEdmFQosogVq4mGrftaOtCc6s9u2HlYj2GXHGrYaEsA+vzyPwrf5//ygc7aoNVY7Q==", "01d524bc-bca3-4a03-b4d8-ad31a3d69ee6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89b74061-6bcb-41b3-bea9-3209bc86faa6", "AQAAAAIAAYagAAAAEAJVOtMypajCYKaFG7JYasXBfcHHb9+pub5wSw8QvFcg7a7Ue8U+O6JT4bIISVgobw==", "9b594bf9-4263-4519-a313-6413de8fc1b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "058b43de-655e-4db4-ba8b-8bba517ae050", "AQAAAAIAAYagAAAAEODYyGLNTgDz8zLMCi01yevopdesroYin5V3iP1Ym0FZHCJpKFBhO5x6UGWH++o/yg==", "2b77093e-a22a-4504-9a03-830cd5e881d7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d249d5d-d656-4bb6-bf80-658093861e23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b37d5a10-ce4d-4f54-a7d6-2b6346830551");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9df08dfc-8771-4c9f-8aeb-cc4be48fe024", null, "Administrator", "ADMINISTRATOR" },
                    { "b170c6f8-f27c-49e8-b2e7-79fc92065841", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c79d130-4b91-4379-9f8d-3ef5479bd349", "AQAAAAIAAYagAAAAEDaS1z5DJ1G4Fk5yJh48Ebi5sv3CetuZiDNbNsQE9GHWjjd/EDeSZApr0Ah1SEBi1w==", "25d560f0-a7ba-4087-982e-5acb9ed4708b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2f467bb-62f0-4498-b5f1-579ab7a2903c", "AQAAAAIAAYagAAAAEL/6qScPgmLUi32Z/+uw8kBs1OLew8lz8Ds8EFpTRYgByvZOKhJ+1lmbHyo8sFM8Eg==", "dbb340b6-e9a7-4553-a3e8-21d190669fab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7147309f-bde3-42cf-9f63-42868293cac1", "AQAAAAIAAYagAAAAEKGA4OY1jgMpBBmogat1o8sXCrDRalmJFO+fjEXYqbpBzPERWfcLCpOTp+BnPwbuGw==", "1064f30b-66d4-4ff3-9969-3ba17ad08296" });
        }
    }
}
