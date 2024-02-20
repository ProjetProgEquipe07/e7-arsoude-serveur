using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class Userfix6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a44d364c-0724-4b4f-a8ea-b9495593a885");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3dd523b-e6e6-4800-a6d2-f61c153d7f2f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "afb259b1-c678-48e2-8d94-d2f14d5a54e7", null, "Administrator", "ADMINISTRATOR" },
                    { "c0d3e2e1-4ff2-415d-95d1-d22e2b208c69", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3764ce3-c14e-45f8-8eb5-a30eb343c27b", "AQAAAAIAAYagAAAAED+XPaWFU/JkLh4gRFTO+Ucwj7gZSdD7bjLWyzcVd/i5n2didG2zr09XnpR+vKZqZg==", "562e68a8-91bb-410b-b4bc-048867a67346" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12e32ff5-3d24-433b-9502-edbd44a6e7d7", "AQAAAAIAAYagAAAAEKhoFqleA6pnCwy0gyvwDqlDhjROimsbQ1mxGpNs5Plxr9jRKkFnHcCsXVSQvTlg1Q==", "2087fca7-8eb5-461e-8556-002ff21dc7b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8928abcd-aa54-460d-9bb2-ced6f1c2c4af", "AQAAAAIAAYagAAAAEGqeu71pfkTPrx1uQYbJkoiaYX/Hfe6VuCfzGnwsKGDq8189rw3SH3T5SKpIJg2otQ==", "ab584f9e-f735-49de-80f4-c600a086017d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afb259b1-c678-48e2-8d94-d2f14d5a54e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0d3e2e1-4ff2-415d-95d1-d22e2b208c69");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a44d364c-0724-4b4f-a8ea-b9495593a885", null, "Administrator", "ADMINISTRATOR" },
                    { "c3dd523b-e6e6-4800-a6d2-f61c153d7f2f", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78d51754-943d-424a-9f38-610a18a58607", "AQAAAAIAAYagAAAAED0M3rJarW1T8S2vB2lXUxrMTP6SCpREZvO354Y7uIFhi+SatsvxxAjHMYLmI2tqbg==", "6c78dfdf-fe76-4a01-aab1-3a6175d03bc1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05c218da-d2a9-4def-b485-0157fe89dae8", "AQAAAAIAAYagAAAAEIdTf65l3QXXABigvHWuhLziFKy7KhhLn5FsN0VvXLIBIhGHm0iE4XeqXFkbIQSqOg==", "b7f09175-5582-4b61-ac4a-0c796d3ca005" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e424e846-07ec-4831-b8c9-110f89d0c4d5", "AQAAAAIAAYagAAAAEIB3h4HHX7MdVn5hCbnPySEX3KjCA/8vnfZF4JpxDn8T3cfeTp+mOqiY+YUeyAMt0A==", "1ba0b06a-e9dd-45e1-a726-b4361244e3a2" });
        }
    }
}
