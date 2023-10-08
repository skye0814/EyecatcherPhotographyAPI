using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ApplicationUserInCustomerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce1d4e8d-ddb6-4116-b013-ab34ff26cda9", "AQAAAAEAACcQAAAAEJZssMAyVnhssrnkdCP0ZcsZXT75XI1Vy8UCxsGhKv3Bv8HYY53eeAcvBGcIpcYApQ==", "7bad81ce-d9a7-4593-bd49-d368fba83cbb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "22dc9879-b5f7-4fff-bd8d-b3821455b6d5", 0, "608e21e1-9bda-438b-b11b-238203ca4a35", "IdentityUser", "skye0814@gmail.com", false, false, null, "SKYE0814@GMAIL.COM", "SKYE0814", "AQAAAAEAACcQAAAAEGd904MgPqX3UblC2tBoiZ7Z7QnFyMhg6MVl2yKyM1ou+byaE9GbvkDXNGHA3CMPmw==", null, false, "59e8bab4-ed2c-4a5a-b5d4-3e914b22fc1a", false, "skye0814" });
        }
    }
}
