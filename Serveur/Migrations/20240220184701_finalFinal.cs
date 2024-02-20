using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class finalFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "377c194e-33c7-4ba4-b345-e585fdcc04ff", "AQAAAAIAAYagAAAAEGHfsjyNWvZ0StRlL7kL6ptJvOsd6DGtCJAGkzpHk/skF+4H9am/aZaNUIbxgqg7uw==", "3864a155-ae88-465e-b8d7-3e14d88663e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c4ad851-2812-4162-8342-77b46e40047f", "AQAAAAIAAYagAAAAEPa/sI9tqSqgo+u6h1ZIKfhjuRLY4cYivcvB9qCVOW8MV5e0IIEgcoY7GicRQDtlog==", "a48d7313-d887-414d-b112-562af8f77ceb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "372014ce-7a7f-4d62-a79b-b66ab21cefc0", "AQAAAAIAAYagAAAAEN4WUYgaMl1w+BsIxjomIoigRLCRjE/ve23N6qkaJaWileM0dTnu6IVw4RcDr7svVg==", "6834aa2b-417a-4a3d-80b5-1b25422d8407" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
