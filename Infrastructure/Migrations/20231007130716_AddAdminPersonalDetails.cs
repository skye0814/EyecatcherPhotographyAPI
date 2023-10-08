using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddAdminPersonalDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AspNetUsersId",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "608e21e1-9bda-438b-b11b-238203ca4a35", "AQAAAAEAACcQAAAAEGd904MgPqX3UblC2tBoiZ7Z7QnFyMhg6MVl2yKyM1ou+byaE9GbvkDXNGHA3CMPmw==", "59e8bab4-ed2c-4a5a-b5d4-3e914b22fc1a" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "ContactNumber", "FirstName", "Id", "LastName", "MiddleName" },
                values: new object[] { new Guid("ffa913a6-5448-4d58-9ad7-ed7729d31345"), null, null, "John Matthew", "22dc9879-b5f7-4fff-bd8d-b3821455b6d5", "Arquelola", "Cruz" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: new Guid("ffa913a6-5448-4d58-9ad7-ed7729d31345"));

            migrationBuilder.AddColumn<Guid>(
                name: "AspNetUsersId",
                table: "Customers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "38b13138-2eb6-415b-b1d4-c36f6c6fdee4", "9c574ed9-2fb4-4444-afa4-188ccd11926b", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ed57acf-cb38-4df4-ac5f-be45115fd783", "a30645c6-6107-46a1-8b4a-bd3647ccd8ed", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec852182-2008-4bc8-9364-62df07801ae1", "AQAAAAEAACcQAAAAEC59NgcOFkX+NG8gZJLFWvAyg3Pe/p4VTQ9Q9zaKl240PmLHSpr0b+kCHuMEpxxjNQ==", "4691da6e-f4a1-488a-adb0-22c97fcbb31b" });
        }
    }
}
