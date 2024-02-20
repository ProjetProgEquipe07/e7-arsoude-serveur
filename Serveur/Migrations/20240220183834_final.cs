using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36710a35-a2d0-4107-b567-0aaa5eb52bac", "AQAAAAIAAYagAAAAEKpZqHWSv0hf7vZajZzWOp0/r+P79P6tJGaaCwWiuVE7TShxk17nE4T0IzSj5ctTzg==", "49ce9054-965b-45cc-a396-bf467a423647" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0e05288-a187-4062-9c67-8cd777a3d963", "AQAAAAIAAYagAAAAEFUFM5c6ErINSMiOkQ7nF5RzH1fVeONx/i1AnHGv7kXD7TT9YqLB6poXc9nrBwPPRA==", "2376d845-b0d5-4c05-b22d-dbbf44c1d0fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4a80d64-4fbd-48f7-830a-abb99ecd4fac", "AQAAAAIAAYagAAAAEL6uYm0FctKRRRj9pP6NgarGaT6/kA2zK/BV0i5IP9ibZ1HMCEpaqXuOS9gtJ4jR3A==", "3512286a-f0d9-45ab-8e35-d77e16ea6ce1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
