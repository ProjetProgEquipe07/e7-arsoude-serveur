using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class Initialcreat2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "timer",
                table: "utilisateursTrace",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c770cab3-05c8-4ad9-ad2e-3bd7d2ec121a", "AQAAAAIAAYagAAAAEG02zmw3RtdW4gxK8bHfdhCPX/4Tq94t45lxh47BEVnVpiDzH5Oqhou59ErZyCBAsw==", "3c1bfe65-356b-494e-b6bc-208d1012ad81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fff7ff73-797d-49c6-951e-59fbaedb9379", "AQAAAAIAAYagAAAAECUvM3k22pveWV5b+JjC1vA0C0AKk+eIbfnUNwCOgVGv36Ax0UML5Sk1GyjrWOmtuA==", "197907c0-43c2-4a94-88ea-e9b8162afa66" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84f41619-0de5-473a-ac2b-ff347830b55e", "AQAAAAIAAYagAAAAEKxPawgfl31bxDMHqqKS3ycgf92J/BdliGeejvIIfs2ojSUlhDpjJ591Jq4EALU9hQ==", "a3f6ea42-6526-4a45-b8ea-4e702771afe6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "timer",
                table: "utilisateursTrace");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb3d5311-e855-4b9e-848b-8b9ad06978e8", "AQAAAAIAAYagAAAAEO/kwhoufGmgeKF25AFA5YyEx50BEkx5qUWeUsRNtORe0/fu2sBuarQMEcsjB3wXgA==", "846b691c-08cf-4df2-b0b1-67165dc85711" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea2a4388-3d6b-4c9b-8110-d88175053cf9", "AQAAAAIAAYagAAAAEFwYZJ36Bp9AqQHVbSYpKtDRSWkmxVjg6GUKn0OCEzknhz38dKy0K8vqsLCR9KL2UA==", "6851c748-07bd-4a46-a6b6-1a716f93cc0a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b101db50-c5f3-418d-8f88-61429b4ae983", "AQAAAAIAAYagAAAAEFaQc9uXHWbZcBedsynBKv/u+QtGt0dAkU0L2zhetzaSvWgZ0zWTMUjThutlahuUhg==", "a4d4c7a9-c73b-4070-8152-d4ecf851720a" });
        }
    }
}
