using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddAppUserInDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: "ffa913a6-5448-4d58-9ad7-ed7729d31345");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5");

            migrationBuilder.AddColumn<string>(
                name: "CustomerID",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "22dc9879-b5f7-4fff-bd8d-b3821455b6d5", 0, "ca622645-65b6-46e9-af63-706e125f2d4d", "IdentityUser", "skye0814@gmail.com", false, false, null, "SKYE0814@GMAIL.COM", "SKYE0814", "AQAAAAEAACcQAAAAEMZfxVZWzN4r7fCVgNkISYSTPx5yCVfQnhrgTOw1H/mGP6U5rv7IgpiGjQXcliokjw==", null, false, "219af195-851f-4a6c-8fe5-0d0244aef53b", false, "skye0814" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "ContactNumber", "FirstName", "Id", "LastName", "MiddleName" },
                values: new object[] { "ffa913a6-5448-4d58-9ad7-ed7729d31345", null, null, "John Matthew", "22dc9879-b5f7-4fff-bd8d-b3821455b6d5", "Arquelola", "Cruz" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomerID",
                table: "AspNetUsers",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerID",
                table: "AspNetUsers",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CustomerID",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: "ffa913a6-5448-4d58-9ad7-ed7729d31345");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce1d4e8d-ddb6-4116-b013-ab34ff26cda9", "AQAAAAEAACcQAAAAEJZssMAyVnhssrnkdCP0ZcsZXT75XI1Vy8UCxsGhKv3Bv8HYY53eeAcvBGcIpcYApQ==", "7bad81ce-d9a7-4593-bd49-d368fba83cbb" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "ContactNumber", "FirstName", "Id", "LastName", "MiddleName" },
                values: new object[] { "ffa913a6-5448-4d58-9ad7-ed7729d31345", null, null, "John Matthew", "22dc9879-b5f7-4fff-bd8d-b3821455b6d5", "Arquelola", "Cruz" });
        }
    }
}
