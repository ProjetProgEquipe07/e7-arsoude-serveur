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
                keyValues: new object[] { "ba5c1093-55e6-49d1-9241-9fddbb45b598", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8680bb5f-a9ce-42ee-8717-8e74d8b69239", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8680bb5f-a9ce-42ee-8717-8e74d8b69239", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8680bb5f-a9ce-42ee-8717-8e74d8b69239");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba5c1093-55e6-49d1-9241-9fddbb45b598");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ddeb9f3-f38e-43be-8d19-354b821d44d3", null, "Administrator", "ADMINISTRATOR" },
                    { "79486b91-54cc-400e-880c-6c89f5327b5d", null, "Randonneur", "RANDONNEUR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19c09e31-7d71-4fd9-8762-071261cfb6f4", "AQAAAAIAAYagAAAAEFPpjTI1jEjXxgb435OBMoehwIM37GB+fbkdyGjU5POiBBncvxqZcPt1bA4Q4bXc+Q==", "b7cea203-1727-4d69-8159-c32cdb190f91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4a98657-f3f8-4717-b0ea-377a8ec9e70f", "AQAAAAIAAYagAAAAEJs4pw5OScCI4r6t1JsgHlONL9xAHxZItV6ngWh8cHNpLritKv8CdgdETNgl++qN6g==", "8a6fb5b6-2f13-4bd0-9933-a520fc28ff22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2fac39b-d1e9-4c1a-9301-c21e6e0e32b8", "AQAAAAIAAYagAAAAEDkLzqeGfCgHanhT5oZOV+Yc4dnL9sBAzlHvwTbgNeihcYRvXSH4NGGMNU9p41kRiw==", "3358b1b8-fa0c-4349-afc0-0ce2d7d0e435" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4ddeb9f3-f38e-43be-8d19-354b821d44d3", "11111111-1111-1111-1111-111111111111" },
                    { "79486b91-54cc-400e-880c-6c89f5327b5d", "11111111-1111-1111-1111-111111111112" },
                    { "79486b91-54cc-400e-880c-6c89f5327b5d", "11111111-1111-1111-1111-111111111113" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4ddeb9f3-f38e-43be-8d19-354b821d44d3", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "79486b91-54cc-400e-880c-6c89f5327b5d", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "79486b91-54cc-400e-880c-6c89f5327b5d", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ddeb9f3-f38e-43be-8d19-354b821d44d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79486b91-54cc-400e-880c-6c89f5327b5d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8680bb5f-a9ce-42ee-8717-8e74d8b69239", null, "Randonneur", "RANDONNEUR" },
                    { "ba5c1093-55e6-49d1-9241-9fddbb45b598", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7391015-9c68-4373-bed0-d1444a095e48", "AQAAAAIAAYagAAAAENGwh0ihwFFW35NIL/DMCo+wMNkk2irHUrEfW8ftnDvfJFEYrWSTQ60ad8NqZm1B0A==", "539f1c1f-62ca-42d0-a20e-998bdd656707" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58cbd040-0d62-4474-9cca-49b7c27d4006", "AQAAAAIAAYagAAAAEG1Bb4N/eqzbMxOJXcKLcPO6QolFQmiJYXUg2ujl+k4hN/rVPQ9PtedXObv8+3vPwA==", "c34bc35f-9acd-4344-a20c-a9b912c13ffd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10c45a1d-9b67-4d91-824c-46438a46f041", "AQAAAAIAAYagAAAAEI3SNEahJ9DaiHEdvoFNs8SNa/F0s1hCw7MGPSSg+NTrDK0uCx19zyB+jASwu+Cl9A==", "9e7e7991-4661-4edc-be28-3d6d0b50f5ff" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ba5c1093-55e6-49d1-9241-9fddbb45b598", "11111111-1111-1111-1111-111111111111" },
                    { "8680bb5f-a9ce-42ee-8717-8e74d8b69239", "11111111-1111-1111-1111-111111111112" },
                    { "8680bb5f-a9ce-42ee-8717-8e74d8b69239", "11111111-1111-1111-1111-111111111113" }
                });
        }
    }
}
