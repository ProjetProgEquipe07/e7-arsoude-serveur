using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class AjoutEtatRando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_commentaires_randonnees_randonneeid",
                table: "commentaires");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "382c3207-20e9-4afe-8271-1f115245afb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa89c9ec-2784-47a0-824a-1b5177bbe452");

            migrationBuilder.RenameColumn(
                name: "randonneeid",
                table: "commentaires",
                newName: "randonneeId");

            migrationBuilder.RenameColumn(
                name: "randonnéeId",
                table: "commentaires",
                newName: "review");

            migrationBuilder.RenameIndex(
                name: "IX_commentaires_randonneeid",
                table: "commentaires",
                newName: "IX_commentaires_randonneeId");

            migrationBuilder.AlterColumn<string>(
                name: "texte",
                table: "commentaires",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "510b4a44-67e5-492e-a174-c62dc8327ab6", null, "Administrator", "ADMINISTRATOR" },
                    { "5bd90665-2473-466e-9dc0-d9e7ce8218d2", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac58bbbf-8a71-4490-905c-0e370b11ce66", "AQAAAAIAAYagAAAAELRVR0ScO+t/Z18mMsY/VSEkjYJeHtbpxGf+9xIh2+BB7TcypB++L3O2vcsuzFLnUQ==", "d8fa5ccb-a568-4df7-b45a-6cb9d7edc48a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4e9a57d-caba-470c-be9f-5052675df6c4", "AQAAAAIAAYagAAAAEBpE10kpJN9unsT/sqfaoO7CaZHhXmAO9HCVyrS/crrcNQBtx7+oQ5nPFveSTaGTsw==", "00561922-54d4-4eb3-9622-e8df295fbb54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "feabceb3-b980-47bf-84c2-62383395f190", "AQAAAAIAAYagAAAAEDfoEVuOfQc27CXhLgPLNzZUL6uglq6bAgOhb3Knr0IojiR4q6M83hob/RBSLFUsTw==", "d5490846-89a1-43c5-84e3-990e98bb7e52" });

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

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "adresse", "codePostal" },
                values: new object[] { "", "E3A 4R4" });

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "adresse", "codePostal" },
                values: new object[] { "", "E3A 4R4" });

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "adresse", "codePostal" },
                values: new object[] { "1260, rue Mill, suite 100", "E3A 4R4" });

            migrationBuilder.AddForeignKey(
                name: "FK_commentaires_randonnees_randonneeId",
                table: "commentaires",
                column: "randonneeId",
                principalTable: "randonnees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_commentaires_randonnees_randonneeId",
                table: "commentaires");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "510b4a44-67e5-492e-a174-c62dc8327ab6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bd90665-2473-466e-9dc0-d9e7ce8218d2");

            migrationBuilder.RenameColumn(
                name: "randonneeId",
                table: "commentaires",
                newName: "randonneeid");

            migrationBuilder.RenameColumn(
                name: "review",
                table: "commentaires",
                newName: "randonnéeId");

            migrationBuilder.RenameIndex(
                name: "IX_commentaires_randonneeId",
                table: "commentaires",
                newName: "IX_commentaires_randonneeid");

            migrationBuilder.AlterColumn<string>(
                name: "texte",
                table: "commentaires",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "382c3207-20e9-4afe-8271-1f115245afb9", null, "User", "USER" },
                    { "fa89c9ec-2784-47a0-824a-1b5177bbe452", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36bd25c8-7b1e-48a2-a1db-680011aec814", "AQAAAAIAAYagAAAAEHpbPPe20D7W4zEmokJkCKzDQtG7as2g5SiUizCS3Mi2SdQtQKfWoHLVQSS9WCbttw==", "3c3570e1-8e13-4f8b-83bf-e823e25ffebc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "642477b0-f90e-4712-ac19-c12c778bf29c", "AQAAAAIAAYagAAAAED8REGUYSKKTNehOHfoDhAYq0LXNUxq7SRmvQgmoA4VQexhsCYjhjsJXjjrEa/xdOg==", "da1ead62-d600-40a7-8e5f-36ad2a568141" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d19ba367-25a1-4b25-9dc3-328a68110598", "AQAAAAIAAYagAAAAEGwzyWTRhGFWZc6FiuanvDiPeQZFSnNawXKLn1V4vieKdJ5iowwZ6sB7XoBujZSLJQ==", "59558cb9-1f2f-44c0-aa17-120f4ca0b0cc" });

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

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "adresse", "codePostal" },
                values: new object[] { null, "E3A4R4" });

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "adresse", "codePostal" },
                values: new object[] { null, "E3A4R4" });

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "adresse", "codePostal" },
                values: new object[] { null, "E3A4R4" });

            migrationBuilder.AddForeignKey(
                name: "FK_commentaires_randonnees_randonneeid",
                table: "commentaires",
                column: "randonneeid",
                principalTable: "randonnees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
