using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class AjoutAvertissementModelControllerService1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbbbc41e-da2b-4149-8f8e-87df7e7785bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8c83b2a-e296-4e9a-9c16-9f79199ce49f");

            migrationBuilder.CreateTable(
                name: "avertissements",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    typeAvertissement = table.Column<int>(type: "INTEGER", nullable: false),
                    DateSuppresion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    randonneeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avertissements", x => x.id);
                    table.ForeignKey(
                        name: "FK_avertissements_randonnees_randonneeId",
                        column: x => x.randonneeId,
                        principalTable: "randonnees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_avertissements_randonneeId",
                table: "avertissements",
                column: "randonneeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "avertissements");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70e34ebd-5686-4db3-b73a-126b50b81b08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf8e3bd1-e048-4bd3-b247-aaeaae58e1a8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "dbbbc41e-da2b-4149-8f8e-87df7e7785bd", null, "Administrator", "ADMINISTRATOR" },
                    { "e8c83b2a-e296-4e9a-9c16-9f79199ce49f", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "647d1964-0e43-4ac0-85cd-284534320580", "AQAAAAIAAYagAAAAENuMNynXr6S1m9BZX73y6d5EMjAnFjiF3L/JLPUetzfFRYKDMr0b7OSRL02ogDJoDw==", "522587ac-aece-4b82-b87d-4e7a9d29f853" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12fa93b4-e0d7-4486-980c-feb53bdb7856", "AQAAAAIAAYagAAAAEIOQowVmXsZzSdCjfuIav9B8Dtx6u7zt7vGTzCPkc6UzFGzac5/u0nriloyKQoV+kg==", "e5827e56-3719-44f0-8e22-f133765a6b97" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f45cc5b-dbd1-4a16-928d-4542845d5023", "AQAAAAIAAYagAAAAEFpkyAxtrgvUJF/kBLYkcEiRYaKFzcKyM5i6PBUZyTAxNrlp0PEOFkZczP6uZgFoZA==", "1a3a773f-e8fb-4fb3-a60b-50d26f0d7ab2" });
        }
    }
}
