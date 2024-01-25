using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeRandonnees");

            migrationBuilder.DropTable(
                name: "type");

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

            migrationBuilder.AddColumn<int>(
                name: "TypeRandonnée",
                table: "randonnées",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34393af2-553f-4c0a-a68a-7cd1bc93e602", null, "Administrator", "ADMINISTRATOR" },
                    { "bf065c64-7c3f-4839-8c56-2418dbb02254", null, "Randonneur", "RANDONNEUR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d5adcbf-9c95-46aa-b510-3fd8fa7acd23", "AQAAAAIAAYagAAAAEBtj6+CIIWfsNrwYuxVB+0Fe93FvgdaKiWnlPiNNkRaAwQEDH1uGFSw56+nvdQNfMw==", "8b0f48b3-0b30-4f5f-8207-d76fb35ed7d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fca1128c-e1af-432c-95b4-2ebefe166a5f", "AQAAAAIAAYagAAAAEDhoFLqrCmU1z4lhOttVWN9e2ZDJ6I/ceGF8RnC2FLbLhtWC1IuiIdi8BQXX5Hj8TA==", "ded4e4e7-902e-4b61-abf6-c3cecd6dfdff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89384c8f-f2e1-45b2-8363-000ffc05b024", "AQAAAAIAAYagAAAAEBXHE9jKH6tW6NlLAsaedVv/4ZNIV9Z+dwbFMotA/jWv49iuDgqgR847Wjao1EOLlQ==", "58f5ca4a-66ca-4376-80e5-3e079cecfc14" });

            migrationBuilder.UpdateData(
                table: "randonnées",
                keyColumn: "id",
                keyValue: 1,
                column: "TypeRandonnée",
                value: 0);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "34393af2-553f-4c0a-a68a-7cd1bc93e602", "11111111-1111-1111-1111-111111111111" },
                    { "bf065c64-7c3f-4839-8c56-2418dbb02254", "11111111-1111-1111-1111-111111111112" },
                    { "bf065c64-7c3f-4839-8c56-2418dbb02254", "11111111-1111-1111-1111-111111111113" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "34393af2-553f-4c0a-a68a-7cd1bc93e602", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bf065c64-7c3f-4839-8c56-2418dbb02254", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bf065c64-7c3f-4839-8c56-2418dbb02254", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34393af2-553f-4c0a-a68a-7cd1bc93e602");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf065c64-7c3f-4839-8c56-2418dbb02254");

            migrationBuilder.DropColumn(
                name: "TypeRandonnée",
                table: "randonnées");

            migrationBuilder.CreateTable(
                name: "type",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type", x => x.id);
                });

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
                table: "type",
                columns: new[] { "id", "nom" },
                values: new object[,]
                {
                    { 1, "Marche" },
                    { 2, "Vélo" }
                });

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
    }
}
