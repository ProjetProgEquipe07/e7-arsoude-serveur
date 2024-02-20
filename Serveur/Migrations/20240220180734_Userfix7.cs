using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class Userfix7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "29673d52-bf9c-444c-ac47-8c6ef4accf55", null, "User", "USER" },
                    { "c2a18eec-02fc-45c7-b6e2-c35b5a3000c2", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "819e5b49-5a77-4005-a976-a16fe2898403", "AQAAAAIAAYagAAAAEJtBNe7HuKMLPugW79qqZI4Nl+GvfvvmIFiXYS8mA6RoAQ957bRtIpQQcxkvun2BRw==", "6ad96d8c-1d90-441e-9197-ad169a1ba944" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f1cb562-da6a-4bd3-9b08-0c61b64f4465", "AQAAAAIAAYagAAAAEKqx5PIf4gsf9/2grCRj76AS9OTm6wxFm+P4H7oWwqZgSwA3WAZ6QSrufdzYoDD+LQ==", "77b43273-1e02-4595-b517-ebdb88c9d5b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acf90775-bfdf-43af-91fe-39c3f8923dd4", "AQAAAAIAAYagAAAAEKH3HaQ1EruzAHd0S0XPAa1CALlCXF/LWj2g3Si8EYzdcdEKK1ncQ/LOIucP3+JPlQ==", "92e9bbbc-e066-4faa-b6e9-d472efac67c3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29673d52-bf9c-444c-ac47-8c6ef4accf55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2a18eec-02fc-45c7-b6e2-c35b5a3000c2");

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
    }
}
