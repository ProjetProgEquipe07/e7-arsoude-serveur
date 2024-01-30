using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "beca0fe0-af2d-41d4-bc7e-e5d45259adf4", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3a0deb61-a559-4e12-a731-e41677ea9ecc", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3a0deb61-a559-4e12-a731-e41677ea9ecc", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a0deb61-a559-4e12-a731-e41677ea9ecc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "beca0fe0-af2d-41d4-bc7e-e5d45259adf4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83227251-95ae-451a-9be3-cf1229ae5501", null, "Administrator", "ADMINISTRATOR" },
                    { "f8e980e6-d3a3-4305-a643-d31c6d16a46d", null, "Randonneur", "RANDONNEUR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12ceb914-3666-4329-b233-0806dc79625e", "AQAAAAIAAYagAAAAEL9A85wvXVF07PFv70wwH3hrVJvylCj59JngdHOziXctmTGNyQMD/NnTCrHDSJQzng==", "f5aab91c-5eef-40b4-8b69-e55b83ee0881" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58537b4a-c20b-4ca7-8b60-950e594ac727", "AQAAAAIAAYagAAAAEIjioJ5TmtImDinhXrP2Wwk1BnAlBRhG7eRht5Ee3M+riJptu3tR7wyPTpJraHsHHQ==", "df3d7b73-3cc6-4dfe-8600-ffaf189d47e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c991d1dc-f9e0-4efd-82e6-925d59a75a71", "AQAAAAIAAYagAAAAELjAJ4zZnQ4zZSqRHPDLmxv1UpAjAcVBAeKMVFWGxOOTE1aUzvUiinZpdBsiJCrEiA==", "ed80b372-d54d-460f-95cd-14bdea48fe44" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "83227251-95ae-451a-9be3-cf1229ae5501", "11111111-1111-1111-1111-111111111111" },
                    { "f8e980e6-d3a3-4305-a643-d31c6d16a46d", "11111111-1111-1111-1111-111111111111" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "83227251-95ae-451a-9be3-cf1229ae5501", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f8e980e6-d3a3-4305-a643-d31c6d16a46d", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83227251-95ae-451a-9be3-cf1229ae5501");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8e980e6-d3a3-4305-a643-d31c6d16a46d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a0deb61-a559-4e12-a731-e41677ea9ecc", null, "Randonneur", "RANDONNEUR" },
                    { "beca0fe0-af2d-41d4-bc7e-e5d45259adf4", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ee365a9-d36b-455e-9372-e52460888713", "AQAAAAIAAYagAAAAELW7qsJ0WWdKEJcQA8elBEUblHez2NH6YEy3tJpYkpvEPXGJS6aYhCUhckpo5rEFLA==", "ec25599e-f871-4844-bb53-d1b0d4520f2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb25c8e6-d8d1-40ad-98d8-c5af6050dded", "AQAAAAIAAYagAAAAEKrBxXZbyxzvuCYOLf17gWBYKSstKhl3F2unUb/P6DA95Wkn+n2h2k/oA6TCgU+13A==", "0d01c4cd-211d-45d1-b6d0-5564beb87914" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d462634f-89b2-4ba0-b710-4c746adb2371", "AQAAAAIAAYagAAAAEOfmJHy6W4jGZcaEBjQ9BdyDhJv4d+fjCwHxR9PSkCargNDdDW+ScVvj3dQD8XHopA==", "6e0d2b18-ee7b-41ae-9df3-abb70e64c478" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "beca0fe0-af2d-41d4-bc7e-e5d45259adf4", "11111111-1111-1111-1111-111111111111" },
                    { "3a0deb61-a559-4e12-a731-e41677ea9ecc", "11111111-1111-1111-1111-111111111112" },
                    { "3a0deb61-a559-4e12-a731-e41677ea9ecc", "11111111-1111-1111-1111-111111111113" }
                });
        }
    }
}
