using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class NormalizedUsernameInSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38b13138-2eb6-415b-b1d4-c36f6c6fdee4",
                column: "ConcurrencyStamp",
                value: "00da166b-972c-4a58-90db-dc4508d019b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ed57acf-cb38-4df4-ac5f-be45115fd783",
                column: "ConcurrencyStamp",
                value: "cc028fe8-9a39-44a4-b9f3-c2dfe148da31");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d337332-5fb6-418a-b22b-166b2bf10854", "SKYE0814@GMAIL.COM", "SKYE0814", "AQAAAAEAACcQAAAAEBktFnMGOe4GszqMmtOSOkxexA1G9YgwNk7bsvdaRy92IOnyQiywyLr26cwDpCxZ+g==", "3ad45454-e682-4455-935d-e840260162a2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38b13138-2eb6-415b-b1d4-c36f6c6fdee4",
                column: "ConcurrencyStamp",
                value: "d2540f98-17d2-454b-a973-e46ee56e3b3b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ed57acf-cb38-4df4-ac5f-be45115fd783",
                column: "ConcurrencyStamp",
                value: "3bd2c763-bd0d-4b68-89a9-35e860d25bce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "937dcb08-13e9-4b79-80b5-5f653cf30cb2", "", "", "AQAAAAEAACcQAAAAENARZYQ9Z+ZkIVAzYp5uHG3XNSYsKnoBzH4MzED0BtNWPFh78CWruzWEYiMJDfCarw==", "8b1cb2cb-a7d0-44a4-8855-0a6d5f9e113f" });
        }
    }
}
