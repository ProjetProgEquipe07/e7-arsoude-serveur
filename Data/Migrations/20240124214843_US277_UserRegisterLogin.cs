using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace arsoudServeur.Data.Migrations
{
    /// <inheritdoc />
    public partial class US277_UserRegisterLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cd0e70f3-a655-4390-9e96-3eda795edeae", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "99adeab6-799f-4777-bd84-a468cc566f84", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "99adeab6-799f-4777-bd84-a468cc566f84", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99adeab6-799f-4777-bd84-a468cc566f84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd0e70f3-a655-4390-9e96-3eda795edeae");

            migrationBuilder.AlterColumn<string>(
                name: "adresse",
                table: "utilisateurs",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "351b031f-2385-421d-9d28-1a46079b23ad", null, "Randonneur", "RANDONNEUR" },
                    { "9cd47377-af01-4761-8e4d-151a1c32e3b1", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed603329-6e19-4023-becb-ff0018f698f2", "AQAAAAIAAYagAAAAEFcCf33+urGi6c0Z/A1229mukAy6CvEvHb25Qot7+pVZen/J0Nd1Dvp8stfL9xjRSw==", "b7795d44-c87f-49bd-8b0d-8814c9b5fb46" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5690ff58-9fce-4505-ad0d-a3a09499960f", "AQAAAAIAAYagAAAAEA2OjTUEP5Y45P8hcQbFyCb1XRjMTITwPG8p4nFzqw68qFEYjuT2EHgVLFsmGbAF6A==", "8b65f12b-110e-4f24-93d0-fc38ef10282b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "079ec84b-1ffe-49a9-bdf4-1c777962060b", "AQAAAAIAAYagAAAAEK/5enK2ChEPh2qrVK2ZgPuucjz9qo54u3OPGMwTL75uaKpILx6LqrO0FxQGy+4AsQ==", "7fe46aff-3623-4f1c-93f5-0b27991f509f" });

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 1,
                column: "adresse",
                value: null);

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 2,
                column: "adresse",
                value: null);

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 3,
                column: "adresse",
                value: null);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9cd47377-af01-4761-8e4d-151a1c32e3b1", "11111111-1111-1111-1111-111111111111" },
                    { "351b031f-2385-421d-9d28-1a46079b23ad", "11111111-1111-1111-1111-111111111112" },
                    { "351b031f-2385-421d-9d28-1a46079b23ad", "11111111-1111-1111-1111-111111111113" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9cd47377-af01-4761-8e4d-151a1c32e3b1", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "351b031f-2385-421d-9d28-1a46079b23ad", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "351b031f-2385-421d-9d28-1a46079b23ad", "11111111-1111-1111-1111-111111111113" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "351b031f-2385-421d-9d28-1a46079b23ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cd47377-af01-4761-8e4d-151a1c32e3b1");

            migrationBuilder.AlterColumn<string>(
                name: "adresse",
                table: "utilisateurs",
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
                    { "99adeab6-799f-4777-bd84-a468cc566f84", null, "Randonneur", "RANDONNEUR" },
                    { "cd0e70f3-a655-4390-9e96-3eda795edeae", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37e233ce-7159-4410-9908-b4f0f64fcf58", "AQAAAAIAAYagAAAAEHqsTuG/MaFLDlZKqxnQ+bYXn0CrXbRrwlkl+DL0Kf4rWo6gD9XehcR5QBk8WL3uBg==", "a2aa2e9c-4589-4c84-b8cc-f77e3a29186d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efa4b6c1-2b02-414d-a023-771575b5a09f", "AQAAAAIAAYagAAAAEHHCP1tD3Q8fszxqMBnkho0hyIBC9vxI2+lQoqcAGuYvVBn5ZfPAmaumXzxURdPJdw==", "c2b98b30-cd03-4cbc-b022-50385b3264f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "273dee78-7c48-4adf-b6d0-d2d4f85d25c7", "AQAAAAIAAYagAAAAEFcm0STtoBnbYbApzObOBvCLMUPXejG1Ebj1FVx6Cyk9P4/B7AD9CFURr5h9J+G8WA==", "7b567083-6997-4286-862b-aef7a8f36e33" });

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 1,
                column: "adresse",
                value: "");

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 2,
                column: "adresse",
                value: "");

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "id",
                keyValue: 3,
                column: "adresse",
                value: "");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cd0e70f3-a655-4390-9e96-3eda795edeae", "11111111-1111-1111-1111-111111111111" },
                    { "99adeab6-799f-4777-bd84-a468cc566f84", "11111111-1111-1111-1111-111111111112" },
                    { "99adeab6-799f-4777-bd84-a468cc566f84", "11111111-1111-1111-1111-111111111113" }
                });
        }
    }
}
