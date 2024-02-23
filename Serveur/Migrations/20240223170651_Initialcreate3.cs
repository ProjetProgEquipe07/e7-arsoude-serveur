using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class Initialcreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "randonnees",
                type: "TEXT",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "nom",
                table: "randonneeAnglais",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "emplacement",
                table: "randonneeAnglais",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "randonneeAnglais",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9764bd83-7b95-424c-a456-633024bf723d", "AQAAAAIAAYagAAAAEJXGypKOiN4nbiXmRUGjwDXI7DLtBkDnGhWXTF/bKKXr6tsSPeBv0/ICGfl23CPxRw==", "ed5ec4a5-84c7-41aa-8c5b-dea3771b26a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b1d9acd-09b5-496c-93d2-c9b417c53c00", "AQAAAAIAAYagAAAAEOtUdCP1UwPU7ZaK1gHmdAkJM48rpbkY8r/3i0HJlF0s8zbQ0pdCqtU2cmvFFJefNg==", "6cf4d0a2-bb75-4a53-b140-62da5fe0c935" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b88a7cf1-db34-4274-b544-4d95cf86600a", "AQAAAAIAAYagAAAAENvyYzgvE/u344MrAAibBzeNpPRyFyVqlURueLSZl8pMNg1972TKuTEy66MokGuffg==", "c89386a6-6ab0-40d2-90e3-098b71784a1d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "randonnees",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nom",
                table: "randonneeAnglais",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "emplacement",
                table: "randonneeAnglais",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "randonneeAnglais",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b06f3b8-01b9-4192-820f-f2231c795809", "AQAAAAIAAYagAAAAEAZ++oEvzRkXC7lBx2ttD7cDtzb957LBWWGsyD71OsFsmmAXRQSWcKPA1LyWwzQBJw==", "6ecbbcdd-f98c-4285-9be7-4b24817a1019" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f30831b-fb64-4e5b-8f79-72ec2f3b56db", "AQAAAAIAAYagAAAAEK1oBiGfLgp509huJnZDwkVR8HUUxBr4ktHw1m3U2bieyBrhvmQ6pM3RNBqfwxSa2Q==", "32e4633c-59d3-40e1-acde-a4f78cc5a2d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8023037c-66f0-4d5d-816d-b462376b2c69", "AQAAAAIAAYagAAAAEL7y0n/mQnBqLNqglGdnh0qnOvBjtEZ+28S103F6eKDbF4K2H0WEPpTQI3ZFADIQ6Q==", "98e24b13-4922-49be-a779-00f750f13556" });
        }
    }
}
