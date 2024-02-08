using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class seedFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c4611a83-7eac-4c33-bbbc-b763f87f20d7", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "82e10d1a-9b4d-4126-b91f-903113c9ae43", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "82e10d1a-9b4d-4126-b91f-903113c9ae43", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82e10d1a-9b4d-4126-b91f-903113c9ae43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4611a83-7eac-4c33-bbbc-b763f87f20d7");

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "utilisateurs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "approuve",
                table: "randonnees",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b47be686-8047-406d-aed8-7ad0ad4ec5f4", null, "Administrator", "ADMINISTRATOR" },
                    { "f0f2ea46-0db5-4240-9b19-4d405a70fb0c", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb84a0f9-960f-4a72-b8a3-062f9ae79d55", "AQAAAAIAAYagAAAAEMEI7LEYtXFrrnfzR1aDdM5/MGL9PjfuGLBPTKzfaSl2N6CzxrYZKW54GV8Ou4Kn4Q==", "b9152258-bf5d-4ac8-af0f-9ab2de809515" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c6c6eb3-85a5-4d7b-82b1-b7b23cadc112", "AQAAAAIAAYagAAAAEAAt0faV38rs4KKIqZNbigyreBEX/C/1uFy7q1wGJ+jTCwkN51n7AqHq1YyZrIHaMg==", "6b6fd430-3076-4b0a-a497-a1f6c5ea59fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b7ce735-6033-4eb7-947c-9692ce6172be", "AQAAAAIAAYagAAAAELMj/SSV8Bw3grKah/BOGGffUtUzyvOE0nwiY5H5ySN1lRrxIanIJJm8uWDHVTu0Bg==", "52cee5a9-b975-47e5-ac75-91f7b3548eab" });

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 1,
                column: "approuve",
                value: true);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 2,
                column: "approuve",
                value: true);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 3,
                column: "approuve",
                value: true);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 4,
                column: "approuve",
                value: true);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 5,
                column: "approuve",
                value: true);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 6,
                column: "approuve",
                value: true);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 7,
                column: "approuve",
                value: true);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 8,
                column: "approuve",
                value: false);

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "adresse", "codePostal", "role" },
                values: new object[] { "", "E3A 4R4", "Administrator" });

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "adresse", "codePostal", "role" },
                values: new object[] { "", "E3A 4R4", "User" });

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "adresse", "codePostal", "role" },
                values: new object[] { "1260, rue Mill, suite 100", "E3A 4R4", "User" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b47be686-8047-406d-aed8-7ad0ad4ec5f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0f2ea46-0db5-4240-9b19-4d405a70fb0c");

            migrationBuilder.DropColumn(
                name: "role",
                table: "utilisateurs");

            migrationBuilder.DropColumn(
                name: "approuve",
                table: "randonnees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "82e10d1a-9b4d-4126-b91f-903113c9ae43", null, "User", "USER" },
                    { "c4611a83-7eac-4c33-bbbc-b763f87f20d7", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43362770-fff5-464a-a09c-f4fd8d99badf", "AQAAAAIAAYagAAAAEMA+oxNIjE6XqFjBbw45PTeYIy7UA+P8vQR+zGqr61XXUlvXuAobEZnYyaziYQWwcg==", "356be55d-eb17-4d2b-badb-c96e21528407" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0b65ccd-195f-4794-a8b7-9211a7827a4b", "AQAAAAIAAYagAAAAEIBACVLAcIGL+Lua+5L9tLggpRCIopzVbJmx5qdBQS3q7fsbonyez9hPND8Ciac89A==", "607f81b3-2081-4a2a-94df-1cf4119c66b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e275151-6eea-4646-b67f-7b9b417ee7f0", "AQAAAAIAAYagAAAAECRw/UB2QgRAj4IRsVDW1smci9QoXC372IYCsUBNbIQDAT3Sv83gLIUVdjJkxqonrQ==", "c198d3e7-8b76-4f2d-9e75-4f18513df974" });

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "adresse", "codePostal" },
                values: new object[] { null, "E3A4R4" });

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "adresse", "codePostal" },
                values: new object[] { null, "E3A4R4" });

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "adresse", "codePostal" },
                values: new object[] { null, "E3A4R4" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c4611a83-7eac-4c33-bbbc-b763f87f20d7", "11111111-1111-1111-1111-111111111111" },
                    { "82e10d1a-9b4d-4126-b91f-903113c9ae43", "11111111-1111-1111-1111-111111111112" },
                    { "82e10d1a-9b4d-4126-b91f-903113c9ae43", "11111111-1111-1111-1111-111111111113" }
                });
        }
    }
}
