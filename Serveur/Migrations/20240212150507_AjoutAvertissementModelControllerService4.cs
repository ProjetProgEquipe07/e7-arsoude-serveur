using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class AjoutAvertissementModelControllerService4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "382c3207-20e9-4afe-8271-1f115245afb9", null, "User", "USER" },
                    { "fa89c9ec-2784-47a0-824a-1b5177bbe452", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36bd25c8-7b1e-48a2-a1db-680011aec814", "AQAAAAIAAYagAAAAEHpbPPe20D7W4zEmokJkCKzDQtG7as2g5SiUizCS3Mi2SdQtQKfWoHLVQSS9WCbttw==", "3c3570e1-8e13-4f8b-83bf-e823e25ffebc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "642477b0-f90e-4712-ac19-c12c778bf29c", "AQAAAAIAAYagAAAAED8REGUYSKKTNehOHfoDhAYq0LXNUxq7SRmvQgmoA4VQexhsCYjhjsJXjjrEa/xdOg==", "da1ead62-d600-40a7-8e5f-36ad2a568141" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d19ba367-25a1-4b25-9dc3-328a68110598", "AQAAAAIAAYagAAAAEGwzyWTRhGFWZc6FiuanvDiPeQZFSnNawXKLn1V4vieKdJ5iowwZ6sB7XoBujZSLJQ==", "59558cb9-1f2f-44c0-aa17-120f4ca0b0cc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "382c3207-20e9-4afe-8271-1f115245afb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa89c9ec-2784-47a0-824a-1b5177bbe452");

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
    }
}
