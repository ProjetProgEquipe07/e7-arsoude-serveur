using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class favoris : Migration
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
                    { "29af1e9d-ce64-4705-a479-0436e229fe74", null, "Administrator", "ADMINISTRATOR" },
                    { "6cd5ac9d-38fa-4548-9dcb-f2815882d801", null, "Randonneur", "RANDONNEUR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2054398-ecca-4017-82d9-19ab926374f8", "AQAAAAIAAYagAAAAEMRKZNxdo1KGdUjA3H8jvzCZaL2yt0ZeYOj4iLsSnwuL/QQgrH980RiFOtfWgwW51w==", "1760a9fc-ae9c-42c5-b9f8-42eea39587af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92eaa2b8-eb96-4ee0-b3b4-92bfbce775f2", "AQAAAAIAAYagAAAAEEQGhN0Ov4kbEcGAKkp4fT9zSYmGsnopIFb2rbumWoFSKa9Zcec7MW4yJ3KyskW/2A==", "8a2bdd74-6715-45c5-ae84-827540738108" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0846703f-ebab-424f-b219-88e57a839669", "AQAAAAIAAYagAAAAEMYdMJsCppqoyB8GsNWnLS8c6YW/R0VYBvi5qNbDPO8oSOR6VGZbM84+WjtKJA1iJA==", "7ef74534-b442-4c56-8a5a-f0c9fa9e7b43" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "29af1e9d-ce64-4705-a479-0436e229fe74", "11111111-1111-1111-1111-111111111111" },
                    { "6cd5ac9d-38fa-4548-9dcb-f2815882d801", "11111111-1111-1111-1111-111111111112" },
                    { "6cd5ac9d-38fa-4548-9dcb-f2815882d801", "11111111-1111-1111-1111-111111111113" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "29af1e9d-ce64-4705-a479-0436e229fe74", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6cd5ac9d-38fa-4548-9dcb-f2815882d801", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6cd5ac9d-38fa-4548-9dcb-f2815882d801", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29af1e9d-ce64-4705-a479-0436e229fe74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cd5ac9d-38fa-4548-9dcb-f2815882d801");

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
