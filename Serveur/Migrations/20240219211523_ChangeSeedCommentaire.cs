using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSeedCommentaire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e560367-30d1-4003-b937-692b779d5c0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebce605d-74e4-4df9-b002-d4da2f61a101");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20ecc001-459b-4e28-a00a-3b496cc27166", "AQAAAAIAAYagAAAAEEmPqbDU/AiOyWkBPAYXqgOX4FzN47qJ4Ar08bD8LypWkcE3qbZnXWklO/X0PYIXKQ==", "bcfcd3b2-65b4-419e-b283-9330f2a6f794" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49d66fea-c852-4613-ab48-cc90f0283dea", "AQAAAAIAAYagAAAAEKptJQyP0f/HS5NjOpl74c+Wmlwz84qIGbFQs8aEy7txmRmSiV6ckpXj+nADK/mb1A==", "bd78fc99-6818-4c9f-94f3-f9d7ef6ae38a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a637b816-29bc-4487-8c33-c41344a63651", "AQAAAAIAAYagAAAAEJsVBRV+msSB32vAT5BbhkEWEWxg+IwkQGEa/B4a5Tj4cedUcIjSD1Drkf/5QM72kQ==", "67de3bfc-a34a-4739-b48c-f2cad4161517" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e560367-30d1-4003-b937-692b779d5c0b", null, "Administrator", "ADMINISTRATOR" },
                    { "ebce605d-74e4-4df9-b002-d4da2f61a101", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bab0e6c7-f28c-4ab3-b7a5-a036a13d1ecb", "AQAAAAIAAYagAAAAECzZYtB48gMprvv5zMjB5YLayAgaUbmDQR73UkhKbmOtGszVzsBmI78DWtTY61gyCw==", "14999965-b643-439f-9372-2d81f96582bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d53880b6-032f-4ae2-a5ae-e8eadd675a44", "AQAAAAIAAYagAAAAED7Mxs+oMFPHmwq1ri1zlbSYlQWkxRS5UtOldlaauZXM2p81Bot50sLEgo641HkDxw==", "f722ccc1-87cd-42b1-86b3-acad0ebad95f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28544d2c-82ca-46ea-9676-b647a9a82122", "AQAAAAIAAYagAAAAEHGZurJBQa35s2CP//4Lh2xxXqy/2+mMImzTdef5ZS+PNs+kGkDlJvzmRK7b+/+S8w==", "8004dd21-fa27-46a5-bc2e-5deff18d01a3" });
        }
    }
}
