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
                keyValues: new object[] { "fb4a8ade-404d-4931-80f0-49e48f89d169", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f46a73dc-844e-4ed5-a8fd-ea83f535391d", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f46a73dc-844e-4ed5-a8fd-ea83f535391d", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f46a73dc-844e-4ed5-a8fd-ea83f535391d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb4a8ade-404d-4931-80f0-49e48f89d169");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "f46a73dc-844e-4ed5-a8fd-ea83f535391d", null, "Randonneur", "RANDONNEUR" },
                    { "fb4a8ade-404d-4931-80f0-49e48f89d169", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac1bfd48-5753-41e0-a0cb-b1d554039e82", "AQAAAAIAAYagAAAAED7+QmjKj71JmrludQuL8v29qL+j+VonF47ZsSb1h6Fe2T+wl3zMUJdkSoFgetYwzw==", "ca9419ca-b9c2-48a4-8358-614a618d15ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "746468d2-a077-4f72-9f9c-b45b76533e9f", "AQAAAAIAAYagAAAAEGMSggHb+LhFDKbY9JIiYLOnVmOp7fgnyQQ7HJmnRYh/4M8b4ieJpNAJ1/X2e3eTTw==", "07ce17d5-c4bb-4960-a040-c1d80ac559db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c59d585-d803-463b-91d6-59672997ec07", "AQAAAAIAAYagAAAAED8K27Sn1I42XmKncpXU8mZ1dcEY8BeO3d0cO9rkaKrEl7mssKpFMypTgKlkB+/tMg==", "f75d8284-37a7-4f5e-82f6-07926776caf7" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "fb4a8ade-404d-4931-80f0-49e48f89d169", "11111111-1111-1111-1111-111111111111" },
                    { "f46a73dc-844e-4ed5-a8fd-ea83f535391d", "11111111-1111-1111-1111-111111111112" },
                    { "f46a73dc-844e-4ed5-a8fd-ea83f535391d", "11111111-1111-1111-1111-111111111113" }
                });
        }
    }
}
