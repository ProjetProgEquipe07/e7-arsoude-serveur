using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudeServeur.Migrations
{
    /// <inheritdoc />
    public partial class AjoutSeedCommentaire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "510b4a44-67e5-492e-a174-c62dc8327ab6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bd90665-2473-466e-9dc0-d9e7ce8218d2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "56834e83-7e21-436b-bbe3-531d3274b829", null, "User", "USER" },
                    { "b79a671c-6f3a-4af1-a423-f87c3e4d5570", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d34e36c5-406d-4157-ba56-be7612f39a12", "AQAAAAIAAYagAAAAEKHb0pq53qtnn1XgY3YiD/r7Gwe6C9/udxY02qrXIChjeu/PVezeqAb4WPoRKM+NZg==", "65f0b986-3b39-4837-8a4e-74d2da460b03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e42ed90b-fc15-4c44-980c-30293aa8ba93", "AQAAAAIAAYagAAAAEJmHHnNWLLDnEsJ5dSua+kL6w6EPmAwREDi44R5EAwkxAwlmL3uhXFC+UjolvO9wLw==", "fd80e3e9-321f-46fc-aee0-c2fba7bb4581" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b736e5c9-53d3-4641-add2-632d7b8c390b", "AQAAAAIAAYagAAAAEB46/f/RDJ7//go0Xfr+Jc+FBsXJ3sg9Uor8soq/uHGh9O+zEs27k/CpWNb24pJYqg==", "92516e02-fa87-45ab-8501-6e46bf1ecd4d" });

            migrationBuilder.InsertData(
                table: "commentaires",
                columns: new[] { "id", "randonneeId", "review", "texte", "utilisateurId" },
                values: new object[,]
                {
                    { 1, 1, 3, "You are a worthless bitch ass nigga\r\nYour life literally is as valuable as a summer ant. I'm just gonna stomp you.\r\nYou're gonna keep coming back. I'm gonna seal up all my cracks, youre gonna keep coming back\r\n \r\nWhy? Cause you keep smelling the syrup, you worthless bitch ass nigga. Your gonna stay on my dick until you die.\r\nYou serve no purpose in life. Your purpose in life is to be on my stream sucking on my dick daily.\r\n \r\nYour purpose in life is to be in that chat, blowing a dick daily.\r\nYour life is nothing!\r\nYou serve zero purpose. You should kill yourself NOW.\r\nAnd give somebody else a piece of that oxygen, an ozone layer thats covered up so we can breathe inside this blue trapped  bubble, cause what are you here for? To worship me? Kill yourself. I mean that not a 100% but a thousand percent.\r\n \r\nImagine if a nigga like that has kids. Like imagine somebody like that has kids", 2 },
                    { 2, 2, 3, "Imagine if a nigga like that has kids. Like imagine. Imagine if somebody like that has kids. I will feel so sorry for his children cause the nigga literally serves no purpose. Imagine a father, now we got a lot of niggas with wife and kids and shit like that who keeps sucking on my dick daily on the internet but imagine if this nigga actually had children. This niggas devoting the time he could be spending with his kids checking out a black man on stream cucking him relentlessly. That's crazy! I've never seen somebody so relentless to be seen. Somebody so worthless that they'll come into this stream and keep coming in this bitch over and over and over and over and over again when we keep banning you\r\nNigga let me.. let me.. let's do you a favor", 1 },
                    { 3, 4, 3, "Lets go to the 99 cents store and lets pick out a rope together. Imma give you an assisted suicide. Lets pick out a rope together right? And we're gonna take all the greatest trolls clips, put a tv screen right in front of you.\r\nI'm gonna hang that rope at the top of the motherfucking garage.\r\nWe're gonna forcefully pry your eyes open, we probably don't even need to do that cause your on my dick daily. We're gonna pry your eyes open until you consistently watch clips over and over and over and over again to the point where you're gonna be like 'Wait a minute, this is a little bit too much'\r\nYou're just gonna start going crazy.\r\nYou're gonna start going crazy.\r\nJust, your eyes are gonna bleed your retinas are just gonna start pouring out, pouring out blood and just getting\r\ncracks and veins in your retinas are gonna start engaging and bulging. Then I'm gonna grab that rope for you and say 'Are you ready?' You're gonna say 'Yeah' I'm gonna take it and PULL IT\r\nwhile you beg me, beg me and I mean beg me to kill you and choke you, choke the worthless life out of your sorry ass until you're fucking dead, croaked with a blue face nigga. Cause you don't deserve your soul.\r\nI've never seen somebody so fucking worthless and relentless that keep coming in a niggas chat over and over and over again. Somebody like that needs to die.\r\nThere is really no reason for him to be alive. We lost prominent niggas on earth, that served a purpose that had... so this nigga could be on earth trolling a stream daily, like come on my nigga. Like, your life is just worthless, just please kill yourself.\r\nGo outside, throw some steaks in a fucking alley and hope a bunch of stray dogs jump on you starts chewing your fucking dick your dick off, biting pieces and shit off of you like that cause you literally just gotta go. Like this nigga off of earth. Please", 2 },
                    { 4, 2, 1, "Lets go to the 99 cents store and lets pick out a rope together. Imma give you an assisted suicide. Lets pick out a rope together right? And we're gonna take all the greatest trolls clips, put a tv screen right in front of you.\r\nI'm gonna hang that rope at the top of the motherfucking garage.\r\nWe're gonna forcefully pry your eyes open, we probably don't even need to do that cause your on my dick daily. We're gonna pry your eyes open until you consistently watch clips over and over and over and over again to the point where you're gonna be like 'Wait a minute, this is a little bit too much'\r\nYou're just gonna start going crazy.\r\nYou're gonna start going crazy.\r\nJust, your eyes are gonna bleed your retinas are just gonna start pouring out, pouring out blood and just getting\r\ncracks and veins in your retinas are gonna start engaging and bulging. Then I'm gonna grab that rope for you and say 'Are you ready?' You're gonna say 'Yeah' I'm gonna take it and PULL IT\r\nwhile you beg me, beg me and I mean beg me to kill you and choke you, choke the worthless life out of your sorry ass until you're fucking dead, croaked with a blue face nigga. Cause you don't deserve your soul.\r\nI've never seen somebody so fucking worthless and relentless that keep coming in a niggas chat over and over and over again. Somebody like that needs to die.\r\nThere is really no reason for him to be alive. We lost prominent niggas on earth, that served a purpose that had... so this nigga could be on earth trolling a stream daily, like come on my nigga. Like, your life is just worthless, just please kill yourself.\r\nGo outside, throw some steaks in a fucking alley and hope a bunch of stray dogs jump on you starts chewing your fucking dick your dick off, biting pieces and shit off of you like that cause you literally just gotta go. Like this nigga off of earth. Please", 3 },
                    { 5, 6, 5, "Lets go to the 99 cents store and lets pick out a rope together. Imma give you an assisted suicide. Lets pick out a rope together right? And we're gonna take all the greatest trolls clips, put a tv screen right in front of you.\r\nI'm gonna hang that rope at the top of the motherfucking garage.\r\nWe're gonna forcefully pry your eyes open, we probably don't even need to do that cause your on my dick daily. We're gonna pry your eyes open until you consistently watch clips over and over and over and over again to the point where you're gonna be like 'Wait a minute, this is a little bit too much'\r\nYou're just gonna start going crazy.\r\nYou're gonna start going crazy.\r\nJust, your eyes are gonna bleed your retinas are just gonna start pouring out, pouring out blood and just getting\r\ncracks and veins in your retinas are gonna start engaging and bulging. Then I'm gonna grab that rope for you and say 'Are you ready?' You're gonna say 'Yeah' I'm gonna take it and PULL IT\r\nwhile you beg me, beg me and I mean beg me to kill you and choke you, choke the worthless life out of your sorry ass until you're fucking dead, croaked with a blue face nigga. Cause you don't deserve your soul.\r\nI've never seen somebody so fucking worthless and relentless that keep coming in a niggas chat over and over and over again. Somebody like that needs to die.\r\nThere is really no reason for him to be alive. We lost prominent niggas on earth, that served a purpose that had... so this nigga could be on earth trolling a stream daily, like come on my nigga. Like, your life is just worthless, just please kill yourself.\r\nGo outside, throw some steaks in a fucking alley and hope a bunch of stray dogs jump on you starts chewing your fucking dick your dick off, biting pieces and shit off of you like that cause you literally just gotta go. Like this nigga off of earth. Please", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56834e83-7e21-436b-bbe3-531d3274b829");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b79a671c-6f3a-4af1-a423-f87c3e4d5570");

            migrationBuilder.DeleteData(
                table: "commentaires",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "commentaires",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "commentaires",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "commentaires",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "commentaires",
                keyColumn: "id",
                keyValue: 5);

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
        }
    }
}
