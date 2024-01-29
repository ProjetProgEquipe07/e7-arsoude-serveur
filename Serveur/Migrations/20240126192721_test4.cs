using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9f034f51-1cda-4ef3-89eb-fa5fd3392606", null, "Administrator", "ADMINISTRATOR" },
                    { "f93557c5-9223-4648-9863-6b4337a2b303", null, "Randonneur", "RANDONNEUR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9925239-2b42-4687-ab81-2f203a42e78f", "AQAAAAIAAYagAAAAEGXjfBEt1rsqdmqafPL55kUxbUXSOrhG1ZXhnLuhFqaiHwS9BbDxOgUhQyM0irG7kg==", "db411e6c-a476-4890-a685-d562120fe357" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "554695d6-988f-4020-9bcb-3b76f11daf01", "AQAAAAIAAYagAAAAEETtS76n+S/yZVZeprdjdSdGLdq2ZKPkEtBxopJnIUWt2URNTlESJ/Ie2FE6GaXseQ==", "ad84191b-0b51-4bc5-9803-1a98b4114824" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd9238e9-7a88-4e4f-80a9-bf818fa74cb5", "AQAAAAIAAYagAAAAEAabSmgr2yooF6uMTzEf2LPmEi7uehURHC/MORQGOcTessdtWZ1O6ySO9EP9boqEGQ==", "29105f63-6130-4149-9525-3900e92fb620" });

            migrationBuilder.InsertData(
                table: "images",
                columns: new[] { "id", "lien", "randonneeId" },
                values: new object[,]
                {
                    { 2, "https://stbruno.ca/culture/wp-content/uploads/2016/08/23_lacsmontagne_actuelle_01-600x400.jpg", 2 },
                    { 3, "https://stbruno.ca/culture/wp-content/uploads/2016/08/23_lacsmontagne_actuelle_01-600x400.jpg", 3 },
                    { 4, "https://stbruno.ca/culture/wp-content/uploads/2016/08/23_lacsmontagne_actuelle_01-600x400.jpg", 4 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9f034f51-1cda-4ef3-89eb-fa5fd3392606", "11111111-1111-1111-1111-111111111111" },
                    { "f93557c5-9223-4648-9863-6b4337a2b303", "11111111-1111-1111-1111-111111111112" },
                    { "f93557c5-9223-4648-9863-6b4337a2b303", "11111111-1111-1111-1111-111111111113" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9f034f51-1cda-4ef3-89eb-fa5fd3392606", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f93557c5-9223-4648-9863-6b4337a2b303", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f93557c5-9223-4648-9863-6b4337a2b303", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f034f51-1cda-4ef3-89eb-fa5fd3392606");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f93557c5-9223-4648-9863-6b4337a2b303");

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
        }
    }
}
