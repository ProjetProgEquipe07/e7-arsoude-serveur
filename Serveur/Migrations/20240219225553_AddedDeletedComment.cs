using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class AddedDeletedComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1d1f2c7-9d44-4041-ace9-bc7bff033d50", "AQAAAAIAAYagAAAAEEI4l54hSpCcK4Wm7rYVT3nWAyDbkdhlOhKt0A9tLqmX2iLETfhag7VQrde/OFXU1w==", "02c01e48-cc45-4044-9145-45493404f9f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f6db231-8e4a-40df-9277-c10c61130dfa", "AQAAAAIAAYagAAAAEEA5H5QsFC9J8qIQN2NkzGTh98yfreTXQxMX32i+y3rl/Xd7D5wp7r6mPDzVSgm2AQ==", "b9d3f549-b1c2-4d70-90d1-7310a4f6494e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49da5ad1-e54d-4244-b378-9363583ce988", "AQAAAAIAAYagAAAAEDL2ns+CN8+4sHlUKvNGhsWt5mMj4ejeC53XI7r0P37QJvoAYHGc+tNm2gkONwbEgQ==", "72f52430-75d5-45c2-955c-3389eb5b6ed5" });

            migrationBuilder.UpdateData(
                table: "commentaires",
                keyColumn: "id",
                keyValue: 4,
                column: "message",
                value: "Arsoude is a fantastic hiking app that has completely changed the way I explore the great outdoors. With detailed trail maps, GPS tracking, and real-time weather updates, I can confidently go on new adventures without worrying about getting lost. The app also features a community forum where users can share tips, photos, and recommendations, making it easy to connect with other outdoor enthusiasts. Overall, Arsoude has become an essential tool for my hiking excursions and I highly recommend it to anyone looking to discover new trails.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f846ff6-f7e2-44a3-b70e-bb724b12dc6b", "AQAAAAIAAYagAAAAECSdJTYXIFzc8JPhzZnlTMVf/KVsbXupNrSzlLQ5L3DseMKfdd52f/XNIln1ZrFdDg==", "22b19346-8a9d-4bd6-bc54-c90df874f29e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b886fc8e-fa4d-426a-9d76-d0f5076bdc33", "AQAAAAIAAYagAAAAEBwLDHpUSbbChnQII+iXcO+MA6foZOM8jVBAX299NCHGgD180aIy1E3fEUS65B6qlw==", "4faab8c9-02f7-42a7-933f-7e1c23598ba4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "008c427d-5e35-4bb5-9bcc-913b0e141db6", "AQAAAAIAAYagAAAAEHbAXmiB6gkDiHJH0zK32+ilFtelwmETL/JyBZrXWxJhylKXcCAuswT1c/kJ6XQSLQ==", "72ac4e2f-015d-4d4d-9a40-64edc63e2dc7" });

            migrationBuilder.UpdateData(
                table: "commentaires",
                keyColumn: "id",
                keyValue: 4,
                column: "message",
                value: "Your purpose in life is to be in that chat, blowing a dick daily.\r\nYour life is nothing!\r\nYou serve zero purpose. You should kill yourself NOW.\r\nAnd give somebody else a piece of that oxygen, an ozone layer thats covered up so we can breathe inside this blue trapped  bubble, cause what are you here for? To worship me? Kill yourself. I mean that not a hundred percent, but a thousand percent.\r\nI've never seen somebody so worthless in mt life. I deadass. Have not seen such a worthless nigga in my life. If he has kids, oh my god");
        }
    }
}
