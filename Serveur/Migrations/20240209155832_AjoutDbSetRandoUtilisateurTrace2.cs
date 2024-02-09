using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class AjoutDbSetRandoUtilisateurTrace2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6855fa68-6584-4ad1-846a-6b3592390881");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eee1d3b3-eafc-4f3e-90ca-e43796b8ffb5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ac95bc6-b558-47d0-9ffe-0282310f3939", null, "Administrator", "ADMINISTRATOR" },
                    { "5f66af6b-3703-4958-bb74-c794a7471b09", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d36916a8-7d6a-4b03-bb4a-ed0256ba83b5", "AQAAAAIAAYagAAAAEEKBbG9OrhnWZU+QvMqm+o82dhw2TTFEol1o08hI4pYQSuUqGrv1S7aZEMgQ+t6ATA==", "ede51cc6-64d1-41d1-9868-3050bab36475" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6edd2f6-473a-497e-8c4e-0c608c74f340", "AQAAAAIAAYagAAAAEGHeN4y8U4wAEiBvl7iOdFcq48vJQlLrj4sF8QUNH9ZL+84kfQp++1LDYTH0T9hTvA==", "18d1aab1-b581-448c-967c-7598d3f84170" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d9415cb-86e8-4660-b97e-6726643e8762", "AQAAAAIAAYagAAAAEGR11NNAVg7RPz6nMl5bzNMREr3HGMbjMI5ql6H6QxHSZpVSEXErDQnOMe0X+njt5A==", "d04ad418-0e06-4592-a915-c5481ceb0a23" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ac95bc6-b558-47d0-9ffe-0282310f3939");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f66af6b-3703-4958-bb74-c794a7471b09");

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
        }
    }
}
