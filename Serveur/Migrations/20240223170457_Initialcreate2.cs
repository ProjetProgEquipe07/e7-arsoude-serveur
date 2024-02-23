using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class Initialcreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69d7acaa-f0d1-427e-b92b-7d7e00a3ad97", "AQAAAAIAAYagAAAAEPG3pdMSA+Uc+mm/Oyn/8u1C8OZR7z0YH0WE452HC9y3yHIOL1r05pxMdmB6uQvHrw==", "baabf6bc-e455-41a7-9002-ba919c2079d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "575f3e30-ec12-46b5-a8d0-7661d4b9a0c6", "AQAAAAIAAYagAAAAEHpeQKa+RwdASA06xMbhjRdNa0T+QwaWqM/tuDMYHSyyVh1tQleVCqHJmRJUWSHVpg==", "e18da311-3361-4568-b517-9a2862d0d871" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7237e611-5ee8-4d83-888c-d84626ce4f36", "AQAAAAIAAYagAAAAEFoSp4LReFJzp3gzIx9Wkuat26vCdwcMxjYt+aDLfKfGH7Exo8KTPVEcAP2DaEXvbg==", "f07d4251-ea23-47e3-888c-9623401a0a01" });
        }
    }
}
