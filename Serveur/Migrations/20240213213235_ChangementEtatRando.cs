using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class ChangementEtatRando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "664b588a-399f-4509-8e5b-5eabbf47612c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7465334-d9c5-420f-a04b-981bbeef25a2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9b81c2cd-f31a-42ea-acd3-bff3093dd325", null, "User", "USER" },
                    { "e68df4fc-b8bd-4366-8557-85878be6dddb", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08cda59a-a57d-4b44-b0e8-c04d00ccb37d", "AQAAAAIAAYagAAAAEE3ShvCqEpZkx0h6N9mbX51VDPAPuifMcbXDDKg3sbeTr8o3saxRKTbNPVHe0fgmEQ==", "ac08ce5b-ac9b-4a92-8b80-1e17670a9fbf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e95aead7-986c-41ea-b7ff-625559339538", "AQAAAAIAAYagAAAAEIiKePQofmC+0+WsLq85q+2wAwj1pc2+VbEmEInEEkB1SuTkCIf3JJzqc9W60r3LBQ==", "27d56524-9a30-4ca8-9d0b-151460eb7c8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1af5cfc0-1b5a-4c56-882b-54baafb02b35", "AQAAAAIAAYagAAAAEIrBi6AqxJIxjNn30u85KIWM72/F9m299VnwTPh97NKNS93OI3rgSSLmevaQLtl5WQ==", "65d914b8-91a9-4cb6-a3aa-7950fc4da453" });

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
                keyValue: "9b81c2cd-f31a-42ea-acd3-bff3093dd325");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e68df4fc-b8bd-4366-8557-85878be6dddb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "664b588a-399f-4509-8e5b-5eabbf47612c", null, "Administrator", "ADMINISTRATOR" },
                    { "a7465334-d9c5-420f-a04b-981bbeef25a2", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "529ee0e3-bd4b-4c6e-b873-e6c04353909f", "AQAAAAIAAYagAAAAENRZImkcK8pQ3i7C7AQGxnkgQ1uHlWF1jc7bEaop+vxMHpwy2fPepTqA7+nCuBuFyQ==", "3bc9ce4e-5e80-48a6-9498-9a82d6ceedb8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "660289db-bf2e-4478-9b69-2432d2f75f91", "AQAAAAIAAYagAAAAED/NVun3qmu5+xcfB9Sn7RnUlZ3vUXQhBwqn6HnkuK2qWGZhPhxSPopdzUse2Cr4ZA==", "c8552cf6-2525-4cbe-9682-d3c94bb792cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90f947bf-cf57-4a8d-bc2a-78d026547fea", "AQAAAAIAAYagAAAAED2L1sEQTWgrT5qQJs6eDbabj30PmKxhvK+3xzpBkZl4mh8EV4t+aypWn5EfJbljXA==", "0abce4d6-e625-4189-96d8-f503f50c121e" });

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 1,
                column: "etatRandonnee",
                value: 1);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 2,
                column: "etatRandonnee",
                value: 1);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 3,
                column: "etatRandonnee",
                value: 1);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 5,
                column: "etatRandonnee",
                value: 2);

            migrationBuilder.UpdateData(
                table: "randonnees",
                keyColumn: "id",
                keyValue: 6,
                column: "etatRandonnee",
                value: 1);
        }
    }
}
