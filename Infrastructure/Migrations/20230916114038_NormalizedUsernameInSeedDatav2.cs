using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class NormalizedUsernameInSeedDatav2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38b13138-2eb6-415b-b1d4-c36f6c6fdee4",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "88e24bfc-cd25-49e6-8133-e23ee6061f2b", "CUSTOMER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ed57acf-cb38-4df4-ac5f-be45115fd783",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "a2f91fe9-24a5-4bca-98e2-4fb4b869c363", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "074b23e8-04fb-4a98-9f65-a153da614799", "AQAAAAEAACcQAAAAEJP25rcldOoRRi38j4Y5ZkjoDl+6c7CpWBDyLR7tig0g4p8Hsd0HxOWiy6NPWkmKow==", "9187fc0e-5745-486f-b27a-fe79b75b36fb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38b13138-2eb6-415b-b1d4-c36f6c6fdee4",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "00da166b-972c-4a58-90db-dc4508d019b0", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ed57acf-cb38-4df4-ac5f-be45115fd783",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "cc028fe8-9a39-44a4-b9f3-c2dfe148da31", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d337332-5fb6-418a-b22b-166b2bf10854", "AQAAAAEAACcQAAAAEBktFnMGOe4GszqMmtOSOkxexA1G9YgwNk7bsvdaRy92IOnyQiywyLr26cwDpCxZ+g==", "3ad45454-e682-4455-935d-e840260162a2" });
        }
    }
}
