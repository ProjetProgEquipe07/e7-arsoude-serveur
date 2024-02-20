using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class helpme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e2d6499-08eb-47b6-937d-317dbd8ec43c", "AQAAAAIAAYagAAAAEDqRdocHfzB3pPA6kfV2qnsMtqF6ymON7KkYiCVSJY2Kr3bqUj4CKl3ZL03xbpxz7g==", "21411a90-dc9a-4358-9b2e-2c27580c2a5a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b598ef68-a3f9-453e-8185-b71243b4f9b7", "AQAAAAIAAYagAAAAEGBoNqLchAoRRAOVWexrnnI8LQtYUjBSmPvWQXAK+D9tURAlounGD5cuqhjwCDwGvg==", "3cea158a-ca7b-42cd-bb7e-5770d2385761" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7729753-bc60-4eb3-b268-b6113fb230c7", "AQAAAAIAAYagAAAAEHdBl32iJxGHyXbeLoqHf+i7QwI6vN/77cXwfo5LV05qXhA9ITXOafP7sqH/Nny7Wg==", "1b9e5966-772c-40c7-8ace-e1337358fb3b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ccc190ed-301b-4096-84f7-b361910150bd", "AQAAAAIAAYagAAAAEB9NIoVzWy6FE/oLPpikyGRelxPc76n/InzVb9X9tAz/FYtnlK4rbjQSVv3c7yu5aw==", "dca1755d-3b74-490b-a0c9-47b9bfb88393" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "002c8394-40b5-4e05-98fd-c6d9cc602474", "AQAAAAIAAYagAAAAEH/8uXvVoNiiP+NT/27pJYS5pcK7uC9Dc8RF0G1LJtJ2uJIOZeZMgKF7ZhdLVV1CUw==", "32453bbe-3e26-4fdb-8edb-5ccff46272bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00e7e2c1-2854-4027-96ea-2a0a9a84e62e", "AQAAAAIAAYagAAAAEBG+1GowxEwaDiDJoh/Wt0E/Cyq0V/citUlKB+Ffwsxm+t+Vnu3cRGX8xY2ef+ZP6g==", "ca7923ca-d83d-4f27-b093-0ed8ffeab562" });
        }
    }
}
