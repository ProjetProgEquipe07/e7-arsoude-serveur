using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class AjoutAvertissementModelControllerService2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70e34ebd-5686-4db3-b73a-126b50b81b08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf8e3bd1-e048-4bd3-b247-aaeaae58e1a8");

            migrationBuilder.AddColumn<double>(
                name: "x",
                table: "avertissements",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "y",
                table: "avertissements",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9df08dfc-8771-4c9f-8aeb-cc4be48fe024", null, "Administrator", "ADMINISTRATOR" },
                    { "b170c6f8-f27c-49e8-b2e7-79fc92065841", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c79d130-4b91-4379-9f8d-3ef5479bd349", "AQAAAAIAAYagAAAAEDaS1z5DJ1G4Fk5yJh48Ebi5sv3CetuZiDNbNsQE9GHWjjd/EDeSZApr0Ah1SEBi1w==", "25d560f0-a7ba-4087-982e-5acb9ed4708b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2f467bb-62f0-4498-b5f1-579ab7a2903c", "AQAAAAIAAYagAAAAEL/6qScPgmLUi32Z/+uw8kBs1OLew8lz8Ds8EFpTRYgByvZOKhJ+1lmbHyo8sFM8Eg==", "dbb340b6-e9a7-4553-a3e8-21d190669fab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7147309f-bde3-42cf-9f63-42868293cac1", "AQAAAAIAAYagAAAAEKGA4OY1jgMpBBmogat1o8sXCrDRalmJFO+fjEXYqbpBzPERWfcLCpOTp+BnPwbuGw==", "1064f30b-66d4-4ff3-9969-3ba17ad08296" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9df08dfc-8771-4c9f-8aeb-cc4be48fe024");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b170c6f8-f27c-49e8-b2e7-79fc92065841");

            migrationBuilder.DropColumn(
                name: "x",
                table: "avertissements");

            migrationBuilder.DropColumn(
                name: "y",
                table: "avertissements");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "70e34ebd-5686-4db3-b73a-126b50b81b08", null, "Administrator", "ADMINISTRATOR" },
                    { "cf8e3bd1-e048-4bd3-b247-aaeaae58e1a8", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e400fb6a-c2f5-467f-b431-207d9bd2c809", "AQAAAAIAAYagAAAAEAvNridrqqf7s8+t7dDWdRuQVuKlL7LhYfJjIlD4j32fRtFdJvCX4OjPO/b/WcX7Vg==", "f2d92607-e92a-4021-87f5-a8a468303aed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "815cbd69-aefe-4412-90e5-95e88fed8fa5", "AQAAAAIAAYagAAAAEO+RZhfouQ0RQ2f3B5ylabwq46EV0fL6+QtZCKSR69C8FFZKw85goNqf2kksdYe2PQ==", "d6e0cccf-66df-4823-a3f4-bafdf4dfff72" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1164d13-9a1d-44e0-9de6-bf4eda0843c9", "AQAAAAIAAYagAAAAEMshWBTgoakrYBzdL0ZLVfUj35i2GloNSlu50Wr7/Zj/f4gT39W322H1KrqIKQ2b5Q==", "1da7e1c8-8599-4531-a5d7-ea7d9d496e86" });
        }
    }
}
