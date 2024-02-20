using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_utilisateursTrace_publication_publicationId",
                table: "utilisateursTrace");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae5b63dd-c7d6-4b03-a4b5-64c116873bac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de7fc1f6-88ae-46f9-a819-2d6af191b233");

            migrationBuilder.AlterColumn<int>(
                name: "publicationId",
                table: "utilisateursTrace",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c253b8e-1fa2-4d5e-be01-4ce04e4df527", null, "User", "USER" },
                    { "b0c0124e-c342-479c-820a-32036a98abda", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6cf7e8ae-e47e-4c11-8c44-2977a24c30f4", "AQAAAAIAAYagAAAAEHqmAVDRAA1Szn/hw9ImNzl9iMycN9hfZr6BbM+dlYE7/XVx8w3iCAfts5Y4IvMPNw==", "848cf965-0f84-4735-8e69-56c1fbc5f4ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7468756-682a-442d-9455-0238c65aa60b", "AQAAAAIAAYagAAAAEB01+2/VZvuwUGwxRspDhmzL5FgiIzpYEuiNb5ACAyvw8fxifvEsntS7QzhNj2Fhiw==", "c8e87b6a-ec3a-4a56-a6e8-acd10608d8b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e58bbc54-ad79-4f46-8a83-e4709a8169cb", "AQAAAAIAAYagAAAAEFI5NQkY+yshG3BbdizCeiFk3SwQkn3nmvje6XRS9NemsfOoOf/cbWe5hjByS62obA==", "1d50f279-18f3-4bff-9380-5e0a97e3f0cd" });

            migrationBuilder.AddForeignKey(
                name: "FK_utilisateursTrace_publication_publicationId",
                table: "utilisateursTrace",
                column: "publicationId",
                principalTable: "publication",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_utilisateursTrace_publication_publicationId",
                table: "utilisateursTrace");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c253b8e-1fa2-4d5e-be01-4ce04e4df527");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0c0124e-c342-479c-820a-32036a98abda");

            migrationBuilder.AlterColumn<int>(
                name: "publicationId",
                table: "utilisateursTrace",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ae5b63dd-c7d6-4b03-a4b5-64c116873bac", null, "Administrator", "ADMINISTRATOR" },
                    { "de7fc1f6-88ae-46f9-a819-2d6af191b233", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3466aeee-21b2-4124-88d9-4d194637a961", "AQAAAAIAAYagAAAAEEfOD4eNJwWi/cxczvAu/VmSguwKoHrirkAqJyEsTFnpALnF6Ahq9HrW76TC9b5N8A==", "704703f6-780a-4666-9e96-eeabdfc5a772" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27ff9cbd-090c-448f-a6fe-c91083d5714a", "AQAAAAIAAYagAAAAEAzN2OL6rorvonHxjxZTSafS6S/ohoI4q9oLIwGCbjnCBbJ5BoNlawpEN0k4xNCx8A==", "768b6196-1b78-42a6-885f-68f05f9f456a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04b5acbb-ff55-42c4-9548-7e899aad8c85", "AQAAAAIAAYagAAAAENG87XoUdI/wn/1Ylnm7mKdx5U6rOaoK6w+Zmd0upV2r1dr3kcQAGeLNKzcJyJMm9Q==", "71aa1611-88a0-4804-be66-29107944e564" });

            migrationBuilder.AddForeignKey(
                name: "FK_utilisateursTrace_publication_publicationId",
                table: "utilisateursTrace",
                column: "publicationId",
                principalTable: "publication",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
