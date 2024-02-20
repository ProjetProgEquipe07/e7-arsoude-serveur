using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class Userfix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "381377c4-e577-4cd1-90c8-3fc173629eef", null, "Administrator", "ADMINISTRATOR" },
                    { "cbfc6b73-fc48-4d7b-bdd4-8525fe894474", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86da64f4-eb5a-481b-85cb-15244fd27fde", "AQAAAAIAAYagAAAAECWOvXfQ1ik9YINjsdAcw0xgotRdS+cHSIz0CrzjtFO/4pBisQPmtWS/JSQFXCarJg==", "dfc8b5d8-49f5-47ba-912c-910606550bc1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c16fd60-5343-4caa-b728-59cb8fb088f1", "AQAAAAIAAYagAAAAECxkN+3EEJEpgcxpvu67wzB0j8+LOSPFGuKz41uZ1d9JZrcKkbsSq8XciEuAlQNoJA==", "21f3dc8f-96d3-499e-be4b-0e8a43504798" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b70aad8-bcc5-4e4c-91cf-7bce43cbadec", "AQAAAAIAAYagAAAAECa0dSlMmbsszEq2/WmgxKiLCWBp1cegNnnuFdKIojh4Uu+iOMsARK2NDnplu7lzig==", "5d00e2af-fb81-4f43-a886-ba773e035299" });

            migrationBuilder.InsertData(
                table: "publication",
                columns: new[] { "id", "etat", "randonneeId", "utilisateurId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 2, 2 },
                    { 3, 1, 3, 3 },
                    { 4, 1, 4, 2 },
                    { 5, 1, 5, 2 },
                    { 6, 1, 6, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "381377c4-e577-4cd1-90c8-3fc173629eef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbfc6b73-fc48-4d7b-bdd4-8525fe894474");

            migrationBuilder.DeleteData(
                table: "publication",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "publication",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "publication",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "publication",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "publication",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "publication",
                keyColumn: "id",
                keyValue: 6);

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
    }
}
