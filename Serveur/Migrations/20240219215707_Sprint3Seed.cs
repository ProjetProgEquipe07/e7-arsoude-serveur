using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class Sprint3Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "note",
                table: "commentaires",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f13bf880-09fc-4dec-9164-d465fbef7209", "AQAAAAIAAYagAAAAENNqtuhNluVx7ldAONmEwVcWtwKsUYFsyGRQKbV/LDplpffeYSwO/dp6SLp4k6ubMA==", "13dbacdc-544e-4c52-9608-037573bc9de9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a89ce742-b7da-4386-ac26-2d0bfd25c7a1", "AQAAAAIAAYagAAAAELUe9vHgGX85NxLwFzuItsKCTHsrIgVN+aI/AwI+IuZki8g9SupQJYKJVUlor9I3MQ==", "dc0e9c89-6c88-41d0-9506-036a40f84161" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "800a66ee-4f20-44c5-9dd6-bca5d5fd2d63", "AQAAAAIAAYagAAAAECqLfifVukTU1mXUHJ/ZLetnzRi/KmnrMfj+Shjdh+N5c8PobFxYiVpQxVH1cX9Ddg==", "4b82a56a-8289-4b52-9eb1-b075ee49c011" });

            migrationBuilder.UpdateData(
                table: "commentaires",
                keyColumn: "id",
                keyValue: 4,
                column: "message",
                value: "Your purpose in life is to be in that chat, blowing a dick daily.\r\nYour life is nothing!\r\nYou serve zero purpose. You should kill yourself NOW.\r\nAnd give somebody else a piece of that oxygen, an ozone layer thats covered up so we can breathe inside this blue trapped  bubble, cause what are you here for? To worship me? Kill yourself. I mean that not a hundred percent, but a thousand percent.\r\nI've never seen somebody so worthless in mt life. I deadass. Have not seen such a worthless nigga in my life. If he has kids, oh my god");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "note",
                table: "commentaires",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d08088d-3978-4d55-b886-135214f23755", "AQAAAAIAAYagAAAAENy07yc/USSs1PTWzB+InUNlywLyQnoWUXK81teQ1UnYrwe1mo7awWq6mfenOwyY7w==", "4a1ef539-6fca-4dab-87de-55c4f588a3e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d48c58c2-1b44-434f-91b5-6cca1e32d5ff", "AQAAAAIAAYagAAAAEHBzx8Jovb5SdNB4zGPuSUiIIABXL0oYoXJKaPGECHqoOrmZXUtflyh/4MLkFg91Og==", "45ce8a17-1e09-4c0b-9ae6-591bb48d7bf5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7836969-5784-41e6-b6de-0fccf471386c", "AQAAAAIAAYagAAAAEOzkYAwJ6uGjOWAqxVNaAGjZBcruqS2gKrGqmix6hxAm6UReDmYD2KiqELp+z1QrBg==", "274a3bf4-b46b-4c3d-8ce1-b92742fc2f4e" });

            migrationBuilder.UpdateData(
                table: "commentaires",
                keyColumn: "id",
                keyValue: 4,
                column: "message",
                value: "Arsoude is a fantastic hiking app that has completely changed the way I explore the great outdoors. With detailed trail maps, GPS tracking, and real-time weather updates, I can confidently go on new adventures without worrying about getting lost. The app also features a community forum where users can share tips, photos, and recommendations, making it easy to connect with other outdoor enthusiasts. Overall, Arsoude has become an essential tool for my hiking excursions and I highly recommend it to anyone looking to discover new trails.");
        }
    }
}
