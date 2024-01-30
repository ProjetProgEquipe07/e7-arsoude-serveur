using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "60fdfb05-6d5c-4ed8-94a4-ad3828505b64", null, "Administrator", "ADMINISTRATOR" },
                    { "6724746c-8ef1-4c10-a809-7fc22221d111", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c062aee-dec7-420e-866e-befe34600f3f", "AQAAAAIAAYagAAAAEAcTXmmeVAYYI6Oo6/UpO9pGQ75F95qAOzLX2LAiSUV3kv1W6OQnxCMGdXW0RWFNjg==", "b51e2d22-e951-4366-a82e-6b7590f1f430" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b1d9c88-e3e5-427d-b9bf-28337b71790a", "AQAAAAIAAYagAAAAEPIcLPY0wwppqb/GsHPRBflrF/Whk2nshCRuGVSHxx/93+oNtQsJl9EdM8rEePtfDQ==", "06fb5dd6-3d8a-46ef-a986-75e921814a6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61088e4f-6f0f-4d1f-a94e-6c0c36f6e485", "AQAAAAIAAYagAAAAEEqygMPWmEXO46OUATa8g5fxTZ2ICsk8wauX/5Eqnoj51wVSmxoB5hXQjYbL4i6TKA==", "8b1ab336-03f8-4ebb-a08c-24d96fc6f471" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "60fdfb05-6d5c-4ed8-94a4-ad3828505b64", "11111111-1111-1111-1111-111111111111" },
                    { "6724746c-8ef1-4c10-a809-7fc22221d111", "11111111-1111-1111-1111-111111111112" },
                    { "6724746c-8ef1-4c10-a809-7fc22221d111", "11111111-1111-1111-1111-111111111113" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "60fdfb05-6d5c-4ed8-94a4-ad3828505b64", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6724746c-8ef1-4c10-a809-7fc22221d111", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6724746c-8ef1-4c10-a809-7fc22221d111", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60fdfb05-6d5c-4ed8-94a4-ad3828505b64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6724746c-8ef1-4c10-a809-7fc22221d111");

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
    }
}
