using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94170ed1-4514-4300-ba70-e5d3101e0837");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffd03655-3d26-47c2-a939-69ed7abb6816");

            migrationBuilder.RenameColumn(
                name: "TypeRandonnée",
                table: "randonnées",
                newName: "TypeRandonnee");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f16cf2cf-8bf6-4929-9d84-cf0d0ec23ec0", null, "Randonneur", "RANDONNEUR" },
                    { "faee8a6f-a3ba-4db6-ad11-875e22b548ba", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "324861e1-d31d-4928-959f-10386f3132b5", "AQAAAAIAAYagAAAAENx+23SRaCbbXi+VUF2hAeS8s36Rr4VjUpHGfhgr16WipaHTnbI/pGFTBDLYJ6dMIA==", "b2733433-fee2-4909-ba93-de93a95c8edc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c6bf290-076b-4ff8-8c0e-51854ae4f67a", "AQAAAAIAAYagAAAAEKn/EOPZePjuQCE7378eB9iKcHXlOfzX6hYZlL5dF41JQf9bzbWKnLNFAwlydSj2vw==", "3637dbc3-e73d-4166-b8e9-1eeed115252b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "685ea9de-b35a-4c92-9d34-d92b0d38aada", "AQAAAAIAAYagAAAAEAHMwilze2FZjLId2Dgx9I7D0jxPuDslCJcu5zL0tV2pNn8L30v3VrZS3b0+vb0Lig==", "056e356b-ba82-4edb-b90d-167dc9806a75" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "faee8a6f-a3ba-4db6-ad11-875e22b548ba", "11111111-1111-1111-1111-111111111111" },
                    { "f16cf2cf-8bf6-4929-9d84-cf0d0ec23ec0", "11111111-1111-1111-1111-111111111112" },
                    { "f16cf2cf-8bf6-4929-9d84-cf0d0ec23ec0", "11111111-1111-1111-1111-111111111113" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "faee8a6f-a3ba-4db6-ad11-875e22b548ba", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f16cf2cf-8bf6-4929-9d84-cf0d0ec23ec0", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f16cf2cf-8bf6-4929-9d84-cf0d0ec23ec0", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f16cf2cf-8bf6-4929-9d84-cf0d0ec23ec0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "faee8a6f-a3ba-4db6-ad11-875e22b548ba");

            migrationBuilder.RenameColumn(
                name: "TypeRandonnee",
                table: "randonnées",
                newName: "TypeRandonnée");

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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ffd03655-3d26-47c2-a939-69ed7abb6816", "11111111-1111-1111-1111-111111111111" },
                    { "94170ed1-4514-4300-ba70-e5d3101e0837", "11111111-1111-1111-1111-111111111112" },
                    { "94170ed1-4514-4300-ba70-e5d3101e0837", "11111111-1111-1111-1111-111111111113" }
                });
        }
    }
}
