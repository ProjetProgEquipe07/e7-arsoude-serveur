using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gps_randonnées_randonnéeId",
                table: "gps");

            migrationBuilder.DropForeignKey(
                name: "FK_images_randonnées_randonnéeId",
                table: "images");

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
                name: "randonnéeId",
                table: "images",
                newName: "randonneeId");

            migrationBuilder.RenameIndex(
                name: "IX_images_randonnéeId",
                table: "images",
                newName: "IX_images_randonneeId");

            migrationBuilder.RenameColumn(
                name: "randonnéeId",
                table: "gps",
                newName: "randonneeId");

            migrationBuilder.RenameIndex(
                name: "IX_gps_randonnéeId",
                table: "gps",
                newName: "IX_gps_randonneeId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37bd7b38-3ccb-4349-8e48-92cc5ff2b92d", null, "Administrator", "ADMINISTRATOR" },
                    { "e65df771-3bed-4420-9516-280768d4dd5a", null, "Randonneur", "RANDONNEUR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cffe5fa0-4ce4-43e6-aa50-a515535dc2ec", "AQAAAAIAAYagAAAAEHeTP1LPUB7bNZtFQo5vikbO10deLENvfT8yU6vvn0O3amyhojT1x9SUULKDK36URQ==", "07b82b91-8279-4389-b2d5-6d47c0164054" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9305db4-650e-486c-8b7b-53a0c1e8ba69", "AQAAAAIAAYagAAAAEFlMuHKndzs9fyBbDKl5QxeFLv/FxAmEKn/gtpsiSBHejNu3nSr5nl8CO283qS+fiQ==", "20bb695b-a4c3-4842-9c18-ed43fe3a1dc6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf30664d-8926-4243-bb9f-21cebba68bc6", "AQAAAAIAAYagAAAAEECpHjTuE44pRImCKaT/yRIZKMDHIg3KcM4aRcza9xdf96MdeBjOHCDAgSknZO1znA==", "865a1db6-e12b-4534-9fda-88431c21ecdb" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "37bd7b38-3ccb-4349-8e48-92cc5ff2b92d", "11111111-1111-1111-1111-111111111111" },
                    { "e65df771-3bed-4420-9516-280768d4dd5a", "11111111-1111-1111-1111-111111111112" },
                    { "e65df771-3bed-4420-9516-280768d4dd5a", "11111111-1111-1111-1111-111111111113" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_gps_randonnées_randonneeId",
                table: "gps",
                column: "randonneeId",
                principalTable: "randonnées",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_images_randonnées_randonneeId",
                table: "images",
                column: "randonneeId",
                principalTable: "randonnées",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gps_randonnées_randonneeId",
                table: "gps");

            migrationBuilder.DropForeignKey(
                name: "FK_images_randonnées_randonneeId",
                table: "images");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "37bd7b38-3ccb-4349-8e48-92cc5ff2b92d", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e65df771-3bed-4420-9516-280768d4dd5a", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e65df771-3bed-4420-9516-280768d4dd5a", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37bd7b38-3ccb-4349-8e48-92cc5ff2b92d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e65df771-3bed-4420-9516-280768d4dd5a");

            migrationBuilder.RenameColumn(
                name: "randonneeId",
                table: "images",
                newName: "randonnéeId");

            migrationBuilder.RenameIndex(
                name: "IX_images_randonneeId",
                table: "images",
                newName: "IX_images_randonnéeId");

            migrationBuilder.RenameColumn(
                name: "randonneeId",
                table: "gps",
                newName: "randonnéeId");

            migrationBuilder.RenameIndex(
                name: "IX_gps_randonneeId",
                table: "gps",
                newName: "IX_gps_randonnéeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_gps_randonnées_randonnéeId",
                table: "gps",
                column: "randonnéeId",
                principalTable: "randonnées",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_images_randonnées_randonnéeId",
                table: "images",
                column: "randonnéeId",
                principalTable: "randonnées",
                principalColumn: "id");
        }
    }
}
