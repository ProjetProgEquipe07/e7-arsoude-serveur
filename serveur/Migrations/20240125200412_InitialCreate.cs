using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeRandonnée");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a6e784a4-8e7a-4b8b-b813-5488bc0bce0d", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2a6cdfb5-cfce-4fd1-9ab6-1fa83fc84126", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2a6cdfb5-cfce-4fd1-9ab6-1fa83fc84126", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a6cdfb5-cfce-4fd1-9ab6-1fa83fc84126");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6e784a4-8e7a-4b8b-b813-5488bc0bce0d");

            migrationBuilder.CreateTable(
                name: "TypeRandonnees",
                columns: table => new
                {
                    randonnéeid = table.Column<int>(type: "INTEGER", nullable: false),
                    typesRandonnéeid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeRandonnees", x => new { x.randonnéeid, x.typesRandonnéeid });
                    table.ForeignKey(
                        name: "FK_TypeRandonnees_randonnées_randonnéeid",
                        column: x => x.randonnéeid,
                        principalTable: "randonnées",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeRandonnees_type_typesRandonnéeid",
                        column: x => x.typesRandonnéeid,
                        principalTable: "type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a5d531c9-33d3-4447-a8a3-0615017539cd", null, "Randonneur", "RANDONNEUR" },
                    { "d8f8aeb0-2675-40f3-bba5-ba5a76f6d466", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94a2b2e1-ea12-4827-bf3f-77cd7b5f7b91", "AQAAAAIAAYagAAAAEAJTNKxIglWdPf9PiuEQ1DkS13aIIxQKTUbf741hkYpPBOA3EIo5RQeMgDZU3yAwEw==", "e9a52789-0539-451b-bcaf-2d2e960d843d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf6816b4-313c-43ba-ab08-1080b0a0dd1c", "AQAAAAIAAYagAAAAELtccPFbNNFafViHiqHUYNtotjT0O86a6TOE3Cnh3QncxrBeccPh6f8R4ECcd5b/AA==", "b15d9c70-3096-45e8-bc2b-bf1ce3cb1699" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5348968e-b9fb-4ff4-9a3d-20adcb6a8648", "AQAAAAIAAYagAAAAENpZgzoRfs3IgrEgZJHst89T4MnG4Vf1PBiOaW7M5cis6RjfoxOy0NGtLfiN1y6dhA==", "3e9b1085-7ab3-47e7-bd2b-3738e4f104d8" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "d8f8aeb0-2675-40f3-bba5-ba5a76f6d466", "11111111-1111-1111-1111-111111111111" },
                    { "a5d531c9-33d3-4447-a8a3-0615017539cd", "11111111-1111-1111-1111-111111111112" },
                    { "a5d531c9-33d3-4447-a8a3-0615017539cd", "11111111-1111-1111-1111-111111111113" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypeRandonnees_typesRandonnéeid",
                table: "TypeRandonnees",
                column: "typesRandonnéeid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeRandonnees");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d8f8aeb0-2675-40f3-bba5-ba5a76f6d466", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a5d531c9-33d3-4447-a8a3-0615017539cd", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a5d531c9-33d3-4447-a8a3-0615017539cd", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5d531c9-33d3-4447-a8a3-0615017539cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8f8aeb0-2675-40f3-bba5-ba5a76f6d466");

            migrationBuilder.CreateTable(
                name: "TypeRandonnée",
                columns: table => new
                {
                    randonnéeId = table.Column<int>(type: "INTEGER", nullable: false),
                    typeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeRandonnée", x => new { x.randonnéeId, x.typeId });
                    table.ForeignKey(
                        name: "FK_TypeRandonnée_randonnées_randonnéeId",
                        column: x => x.randonnéeId,
                        principalTable: "randonnées",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeRandonnée_type_typeId",
                        column: x => x.typeId,
                        principalTable: "type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a6cdfb5-cfce-4fd1-9ab6-1fa83fc84126", null, "Randonneur", "RANDONNEUR" },
                    { "a6e784a4-8e7a-4b8b-b813-5488bc0bce0d", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8206c706-49c8-4a89-9d54-13e6a50eb1bd", "AQAAAAIAAYagAAAAEAnLmoos9/GAEhlZVE6jBIPN33YIkroT8pFXkclsK8eIUk+/r7Te1OogkO7KV0ZBww==", "025b9a89-7bf6-44a3-bc63-265928ea0d99" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f15d933e-23b4-44ef-b8d5-a16d6be0cc9a", "AQAAAAIAAYagAAAAEFKvwBg67Te+swAWwaS8mDYLEz8OkYSIbABOxhFKLkJN2KVtME9ygrSiUniMbAL7Bg==", "f1e3626c-e7a2-48f8-9be9-9ae95ae0ec58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8240bf68-540e-47ef-9b75-e3a7d94f12aa", "AQAAAAIAAYagAAAAEIUTfvM1zurf9ZljFxoMekWtvLuW5hxNF9IOtL7cI6+A0xuf89lHYu+0gCBQXV/zxg==", "22af66e8-17e0-4bc5-894b-0b229583470c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a6e784a4-8e7a-4b8b-b813-5488bc0bce0d", "11111111-1111-1111-1111-111111111111" },
                    { "2a6cdfb5-cfce-4fd1-9ab6-1fa83fc84126", "11111111-1111-1111-1111-111111111112" },
                    { "2a6cdfb5-cfce-4fd1-9ab6-1fa83fc84126", "11111111-1111-1111-1111-111111111113" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypeRandonnée_typeId",
                table: "TypeRandonnée",
                column: "typeId");
        }
    }
}
