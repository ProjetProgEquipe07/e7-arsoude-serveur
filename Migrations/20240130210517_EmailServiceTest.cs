using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class EmailServiceTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "80a5eac6-9c15-4350-a880-d4bbcaa875a8", null, "Administrator", "ADMINISTRATOR" },
                    { "b56011d8-5cf0-42d5-b78a-345ac0ef6b18", null, "Randonneur", "RANDONNEUR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f31bddb-33ac-4069-be90-6a6a3f9b7b3d", "AQAAAAIAAYagAAAAEKz2BCiVcFEGmvGYVP98RTtr9M75szN0AtFwvWx+DNhnKQWk4svHOyGG5TKVya2NqA==", "e01c0633-c0a3-4df2-8571-cf1b110a75ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f910b8ab-a157-40e7-8d4f-69a52e23163c", "AQAAAAIAAYagAAAAEGlb+7UAoeMgJ2OR5jruovdZwNjFn8MQXjiQJ4UkqVrN1jVASXRUGruil2WNqZCyXQ==", "e0aaf621-d452-4317-8138-b27b4680a5d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55bbb437-2ba5-401d-931b-e8c8be2e5d6a", "AQAAAAIAAYagAAAAEPic0HajY7BrtasPlHvSVqm7njP5ZJrIxoVfawJ7gF3MHybdpBliBsdH2s/0JgYp0A==", "e3e49bde-6fc1-491c-a6be-651722825289" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "80a5eac6-9c15-4350-a880-d4bbcaa875a8", "11111111-1111-1111-1111-111111111111" },
                    { "b56011d8-5cf0-42d5-b78a-345ac0ef6b18", "11111111-1111-1111-1111-111111111112" },
                    { "b56011d8-5cf0-42d5-b78a-345ac0ef6b18", "11111111-1111-1111-1111-111111111113" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "80a5eac6-9c15-4350-a880-d4bbcaa875a8", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b56011d8-5cf0-42d5-b78a-345ac0ef6b18", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b56011d8-5cf0-42d5-b78a-345ac0ef6b18", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80a5eac6-9c15-4350-a880-d4bbcaa875a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b56011d8-5cf0-42d5-b78a-345ac0ef6b18");

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
    }
}
