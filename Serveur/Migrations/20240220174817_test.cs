using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eeaeb75c-ccc2-4c65-9162-4313b773fcd0", "AQAAAAIAAYagAAAAECmaiTMN1vdeBCyL3l8H4lf4TFcg+wj4Z4Tv/sucd+6gdTrVOBnecy+EDVGUGiCXuQ==", "ad13a952-ee73-4f01-b679-1cf7adadfd87" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a198b978-174a-4ba6-8340-48b5bca3e54e", "AQAAAAIAAYagAAAAEE0DkdZrIuSrJNX/wkogDxDrGIftR/drqMupzCo/yM7YrhuaE7IKYvIXucn7khXFBg==", "33e54795-7f12-44db-a67a-3f8e074fe0c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3d446fc-3fcd-4ef8-b053-fff408c7e066", "AQAAAAIAAYagAAAAEGls/rK7AFwqWOSC6n+Er+Nju3yRMvR2re5c/A1Zi2LzUDOMu5ICa9wvV19pcMmUkg==", "b482602f-acb5-4e06-9ead-893bad514e1a" });
        }
    }
}
