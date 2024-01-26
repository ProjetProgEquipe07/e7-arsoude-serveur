using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7b6e5b6c-450c-49cd-ae37-ae03a702a625", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2589644c-3e77-44d3-82c7-ea08baaa713c", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2589644c-3e77-44d3-82c7-ea08baaa713c", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2589644c-3e77-44d3-82c7-ea08baaa713c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b6e5b6c-450c-49cd-ae37-ae03a702a625");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "94170ed1-4514-4300-ba70-e5d3101e0837", null, "Randonneur", "RANDONNEUR" },
                    { "ffd03655-3d26-47c2-a939-69ed7abb6816", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "495d8782-e906-4667-afbd-80b1bf427b69", "AQAAAAIAAYagAAAAEEZoWPVK1yAa2NUf/oFFJa/zqe3S9di4EKGYfoCPQI+n5pcosy72fNzLvS8xuLtPAA==", "540273b8-0d1f-400a-ba88-1e541ca3c16d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05df65e0-6420-46a3-8866-7305039fea9d", "AQAAAAIAAYagAAAAEOGD6fTYA0qCm7PBMz00ozRX1a+l6uR2BdAu+PPEaBGmSztuEBKSzafqddsO0Wg74g==", "139cdfe9-f896-4376-aee4-1b9e76fcdf78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3e73807-6cad-4387-bd95-bee02ef45e4f", "AQAAAAIAAYagAAAAEHuzo91qa6yy4UCy+ZFL4QWKpMMxJC0foxyB/WHuteLp+du2s5Sn0DFWqS+M/C15bw==", "0068afc2-21c7-42f7-9913-0b7366d18879" });

            migrationBuilder.InsertData(
                table: "randonnées",
                columns: new[] { "id", "TypeRandonnée", "description", "emplacement", "nom", "utilisateurId" },
                values: new object[,]
                {
                    { 2, 0, "promenade cool a st-brun", "st-bruno", "st-brun", 1 },
                    { 3, 0, "promenade cool a st-brun", "st-bruno", "st-brun", 1 },
                    { 4, 0, "promenade cool a st-brun", "st-bruno", "st-brun", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ffd03655-3d26-47c2-a939-69ed7abb6816", "11111111-1111-1111-1111-111111111111" },
                    { "94170ed1-4514-4300-ba70-e5d3101e0837", "11111111-1111-1111-1111-111111111112" },
                    { "94170ed1-4514-4300-ba70-e5d3101e0837", "11111111-1111-1111-1111-111111111113" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ffd03655-3d26-47c2-a939-69ed7abb6816", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "94170ed1-4514-4300-ba70-e5d3101e0837", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "94170ed1-4514-4300-ba70-e5d3101e0837", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "randonnées",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "randonnées",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "randonnées",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94170ed1-4514-4300-ba70-e5d3101e0837");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffd03655-3d26-47c2-a939-69ed7abb6816");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2589644c-3e77-44d3-82c7-ea08baaa713c", null, "Randonneur", "RANDONNEUR" },
                    { "7b6e5b6c-450c-49cd-ae37-ae03a702a625", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9a00684-da11-4f08-addf-57c282976a61", "AQAAAAIAAYagAAAAEG7HRtK6HkJv/snxcFSDFMwtzGG81Sq+A/DJSzlfg3O80bssdBGjW9R7avt7xyR7fQ==", "d042a4cb-01d9-49a7-ab16-e5fda9845883" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ba459c0-30f8-4404-925d-734f5095098e", "AQAAAAIAAYagAAAAEJ335gQxBvfV+dL3Ot+9haqharXb/4JDeHM/f0goH9nl//eKN3QyH3/XhoIDlIZNZQ==", "7293fcde-f769-420f-a150-678e37fa9cfb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01995bdf-cf35-406d-a54c-83ccb3331de9", "AQAAAAIAAYagAAAAEBqCmO1xlHj5FCqWzazO8STaJ2JXHIWskz+cs5J4c2HNonHO8OhPkwCuxT8aUHEw2Q==", "3789924e-e88f-4780-b94e-1595f44d81fc" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7b6e5b6c-450c-49cd-ae37-ae03a702a625", "11111111-1111-1111-1111-111111111111" },
                    { "2589644c-3e77-44d3-82c7-ea08baaa713c", "11111111-1111-1111-1111-111111111112" },
                    { "2589644c-3e77-44d3-82c7-ea08baaa713c", "11111111-1111-1111-1111-111111111113" }
                });
        }
    }
}
