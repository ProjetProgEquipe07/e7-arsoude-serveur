using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class reeeeeeeeee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f87a636b-46f7-4ad8-bcdb-b8de4462eee3", "AQAAAAIAAYagAAAAEDdsMzRLrFxhYKcvq/T4VSprLQt3/RDvLVr7xZf8pjJB/LZFUkJRRurOzt+7vA8Wog==", "9d225053-22ec-4fb0-9ee9-a176c9e7cc76" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20cfe303-16d8-4a9f-ad5c-dd180804e194", "AQAAAAIAAYagAAAAEPTGjOx4q1OUglBCaxRHeNoCT/rEyDUFiTzaawvItizCQGYFiFyoSvDR1XqrbSoeag==", "bcbd92af-307d-417c-9212-25b308884570" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3526a6e-4a3f-42df-bcbc-a8ac2515c2f2", "AQAAAAIAAYagAAAAEKuLusKUvxilxHCb0/S6+d4sz4cH41KnYfTTN+dqdEVJOhk/BH/AeL4I7EQxZAx0Sw==", "55a77dc2-a068-4624-b82d-6445dd3a8d96" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
