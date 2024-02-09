using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class AjoutDbSetRandoUtilisateurTrace3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "dbbbc41e-da2b-4149-8f8e-87df7e7785bd", null, "Administrator", "ADMINISTRATOR" },
                    { "e8c83b2a-e296-4e9a-9c16-9f79199ce49f", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "647d1964-0e43-4ac0-85cd-284534320580", "AQAAAAIAAYagAAAAENuMNynXr6S1m9BZX73y6d5EMjAnFjiF3L/JLPUetzfFRYKDMr0b7OSRL02ogDJoDw==", "522587ac-aece-4b82-b87d-4e7a9d29f853" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12fa93b4-e0d7-4486-980c-feb53bdb7856", "AQAAAAIAAYagAAAAEIOQowVmXsZzSdCjfuIav9B8Dtx6u7zt7vGTzCPkc6UzFGzac5/u0nriloyKQoV+kg==", "e5827e56-3719-44f0-8e22-f133765a6b97" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f45cc5b-dbd1-4a16-928d-4542845d5023", "AQAAAAIAAYagAAAAEFpkyAxtrgvUJF/kBLYkcEiRYaKFzcKyM5i6PBUZyTAxNrlp0PEOFkZczP6uZgFoZA==", "1a3a773f-e8fb-4fb3-a60b-50d26f0d7ab2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbbbc41e-da2b-4149-8f8e-87df7e7785bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8c83b2a-e296-4e9a-9c16-9f79199ce49f");

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
    }
}
