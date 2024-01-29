using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7500b006-50e9-40c4-9017-f5da8f13482b", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "25388c96-72a0-40f5-9c45-c442bee9ed26", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "25388c96-72a0-40f5-9c45-c442bee9ed26", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25388c96-72a0-40f5-9c45-c442bee9ed26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7500b006-50e9-40c4-9017-f5da8f13482b");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "25388c96-72a0-40f5-9c45-c442bee9ed26", null, "Randonneur", "RANDONNEUR" },
                    { "7500b006-50e9-40c4-9017-f5da8f13482b", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07af9e5a-acc4-4c16-ac2c-3b9db9129678", "AQAAAAIAAYagAAAAEBOIOyQWRqCh9Mc4UIsCmyWecSITHlEADL9C1DIeeAB9ZhJH9Ha4aMCpyPHpcLG/xw==", "5cc0079a-4b28-46f6-b818-60a8bb589d73" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ff73c94-216c-4d85-9679-0b99942d0e12", "AQAAAAIAAYagAAAAEBJIh6Y2358R//DESeGkGxGjNkiRi79111qb2c+BPd7YOGyLWIvj7kGUWEa1pP7xOw==", "85157c46-d06c-49e8-80cd-24a03674fcb3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39175db5-fc9e-4c6a-8935-463b1c360eb7", "AQAAAAIAAYagAAAAECEoA7HodXCQZn8nyb8DOg3QVzYKxv6zpRmCoiirlNb6GqDl9Ud4t33MA8u5wzil4Q==", "21e57ce8-f91d-42b2-8f51-4ac037d5c209" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7500b006-50e9-40c4-9017-f5da8f13482b", "11111111-1111-1111-1111-111111111111" },
                    { "25388c96-72a0-40f5-9c45-c442bee9ed26", "11111111-1111-1111-1111-111111111112" },
                    { "25388c96-72a0-40f5-9c45-c442bee9ed26", "11111111-1111-1111-1111-111111111113" }
                });
        }
    }
}
