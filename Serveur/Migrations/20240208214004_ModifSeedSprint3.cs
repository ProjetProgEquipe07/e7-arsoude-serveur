using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class ModifSeedSprint3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0a30f7b8-ee18-4ddc-8ddd-0b37c19e4d8d", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e852b2c8-7912-4510-b953-88c30e833acc", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e852b2c8-7912-4510-b953-88c30e833acc", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a30f7b8-ee18-4ddc-8ddd-0b37c19e4d8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e852b2c8-7912-4510-b953-88c30e833acc");

            migrationBuilder.RenameColumn(
                name: "approuve",
                table: "randonnees",
                newName: "etatRandonnee");

            migrationBuilder.RenameColumn(
                name: "Y",
                table: "gps",
                newName: "y");

            migrationBuilder.RenameColumn(
                name: "X",
                table: "gps",
                newName: "x");

            migrationBuilder.RenameColumn(
                name: "Depart",
                table: "gps",
                newName: "depart");

            migrationBuilder.RenameColumn(
                name: "Arrivee",
                table: "gps",
                newName: "arrivee");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "edd86992-441b-47ff-93f7-4ad50e7e812f", null, "Administrator", "ADMINISTRATOR" },
                    { "ffc9d022-608b-4796-974d-589296108496", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea299a5c-ec3f-45b3-8da6-973ba198ce25", "AQAAAAIAAYagAAAAECB+AvKSB9bt1t1Vu6BrnvR7MlpGPRUCObbNqK9AXv+f3sWeITFRr0Kp1hnLjiSzLw==", "7fefc947-8c9b-4e34-9de1-3cac9e91fc49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8090bf0a-7c0b-4347-904a-63dc728e6c78", "AQAAAAIAAYagAAAAEJs/xhWXv59YuSBQZYQb69q5plNsAsvLCEr6p+K6VcikStwRjid4aBz/CZlVp9G+Rg==", "039ead9b-ec09-4bb5-acb6-aafdea3bec73" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9834014-d33b-4591-8610-95bebf17dd75", "AQAAAAIAAYagAAAAEKRh/2/c+i4wIzIFRLxKZiFJAhxcjf25nNKGce6Tc6Hsb73bs95J8AdtF+R3wTalPQ==", "d742c2d6-6841-4645-90f1-542b51c73a73" });

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 1,
                column: "etatRandonnee",
                value: 0);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 2,
                column: "etatRandonnee",
                value: 0);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 3,
                column: "etatRandonnee",
                value: 0);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 4,
                column: "etatRandonnee",
                value: 0);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 5,
                column: "etatRandonnee",
                value: 0);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 6,
                column: "etatRandonnee",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edd86992-441b-47ff-93f7-4ad50e7e812f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffc9d022-608b-4796-974d-589296108496");

            migrationBuilder.RenameColumn(
                name: "etatRandonnee",
                table: "randonnees",
                newName: "approuve");

            migrationBuilder.RenameColumn(
                name: "y",
                table: "gps",
                newName: "Y");

            migrationBuilder.RenameColumn(
                name: "x",
                table: "gps",
                newName: "X");

            migrationBuilder.RenameColumn(
                name: "depart",
                table: "gps",
                newName: "Depart");

            migrationBuilder.RenameColumn(
                name: "arrivee",
                table: "gps",
                newName: "Arrivee");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a30f7b8-ee18-4ddc-8ddd-0b37c19e4d8d", null, "Administrator", "ADMINISTRATOR" },
                    { "e852b2c8-7912-4510-b953-88c30e833acc", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a41ad730-63fa-4525-bee6-8fb33c211804", "AQAAAAIAAYagAAAAEMNSKp0M7rZ0Rfhv/hv3qfuRenW7JLsbBtVy7F2xP37tR/eRqBx1NwERye5aicbAZQ==", "439a71b0-8832-4270-bccd-f9628eb408f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0da94790-9f11-4330-b78b-01f17d9bdd20", "AQAAAAIAAYagAAAAEOwr0nS7SEdYRrZSEUWSFcEzm55n5HQgrNFfV0gjDFJ43b20YwMjjNJgDTukNkP8xw==", "4d356de9-029f-416c-b162-9895eadafd76" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88d3296f-a34f-46c5-823f-e73fa562fcc8", "AQAAAAIAAYagAAAAEIKedTZO15KhCA+MQUMCxz0+eiDNkxBszGmvvbpwDUSzCO2slaETKagQH5UN+5yGMA==", "511da26c-c524-400c-b305-1268a5a5d497" });

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 1,
                column: "approuve",
                value: true);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 2,
                column: "approuve",
                value: true);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 3,
                column: "approuve",
                value: true);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 4,
                column: "approuve",
                value: true);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 5,
                column: "approuve",
                value: true);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 6,
                column: "approuve",
                value: true);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0a30f7b8-ee18-4ddc-8ddd-0b37c19e4d8d", "11111111-1111-1111-1111-111111111111" },
                    { "e852b2c8-7912-4510-b953-88c30e833acc", "11111111-1111-1111-1111-111111111112" },
                    { "e852b2c8-7912-4510-b953-88c30e833acc", "11111111-1111-1111-1111-111111111113" }
                });
        }
    }
}
