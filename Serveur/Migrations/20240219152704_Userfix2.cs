using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class Userfix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cdc13c0-a112-4bc8-ae64-ea0bf3736097");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "751299d8-d882-4c1a-a660-d8bb60fbefbc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "805b0735-00ea-4d19-9331-3cb919b288ef", null, "Administrator", "ADMINISTRATOR" },
                    { "ca9a3c83-deef-48f4-a093-c11f07179f3a", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d8d52e7-e107-4ff8-9406-f729401ea849", "AQAAAAIAAYagAAAAEFTYifRk6L30/RcgZdTLmJzMkKzd7lIEIoDLKvHdEa7EJPMR0qdPqNkvdK4rwYm7nw==", "089fb0a7-ad8c-4810-8c5a-d32120265d81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1185a74a-45df-4c95-8340-dff209293cca", "AQAAAAIAAYagAAAAEKxt3NFh114Mme6x+zI5ElYK6wwWDxbBjso+cA+EEVB5VwpXxCnuBCZm63ixJW6oAA==", "8162a329-3cb0-4fc0-938f-861560c17e45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31c7a884-6f61-455f-9ab5-069f4d9a79d2", "AQAAAAIAAYagAAAAEDea0xrauRbHYGa8qlOE0JTsIR8wjUwWCpOiwfXXnD8lYv2m9YNolXo7s0dFxL4u2w==", "7552a47b-165c-4f22-afb3-5f8874eaeb8b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "805b0735-00ea-4d19-9331-3cb919b288ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca9a3c83-deef-48f4-a093-c11f07179f3a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2cdc13c0-a112-4bc8-ae64-ea0bf3736097", null, "User", "USER" },
                    { "751299d8-d882-4c1a-a660-d8bb60fbefbc", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79440125-799f-4e18-a232-f7a85bb6788a", "AQAAAAIAAYagAAAAEARc9KI8hnLAseFRTzBlKdHB+zZjMAsgp7Dxym1mVYMPjvQKlMLlgVof0GBIBVDEOA==", "d9d46119-4fa8-424a-a353-42733a6f0aa5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "389ec59a-f8b0-4dc0-927b-19967d1f3338", "AQAAAAIAAYagAAAAELJlbI/jkycyD0ad54/9JXlB0VhpOzx5pgCsxVv6EQiNw0HPVLVh2DgWCy8j2rcWbg==", "e4969408-eaf4-45d4-9b94-a316d7b5ea7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d3feacb-02e3-4698-8a2e-6539b16b0545", "AQAAAAIAAYagAAAAEMqDMIl29HGgImTIY6gDIcaEAlkuQhwN/btPHJCiIy9HlZAOczSSQAFeakDk2V1Haw==", "5b08d0aa-e895-402b-9f0b-5bd1098be43b" });
        }
    }
}
