using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SeedDatav1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e9c2648-769f-4eac-8e0c-c6f506cabaca", "AQAAAAEAACcQAAAAEKGPlbvB9TbVq7XdROwHnid1mMzXD7L5VrQi9Lrdgq1KEpjtp6r+u70+wNfVv8L4gw==", "48b158df-4492-434e-b15c-b9e37b8c6ff1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2L,
                column: "FreeText1",
                value: "2 Photographers;Pre Birthday Shoot;Soft Copy;On The Day Event Coverage");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3L,
                column: "FreeText1",
                value: "1 Photographer;1 Videographer;Pre Birthday Shoot;4-5 minutes Video Highlights;Soft Copy;On The Day Event Coverage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39b6b686-2a2d-4173-b55a-b088cdfe99ce", "AQAAAAEAACcQAAAAEDrT10HAPgRas8zMN6isnp/YYYve+CNVU7Cs3Nzt1HDDOlZfboE8qKe+l9Ysy3zSjQ==", "6b8a9c94-f174-4a70-98a7-850457a6ba33" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2L,
                column: "FreeText1",
                value: "PACKAGE 2 (PHOTO)','P2-B',NULL,'2 Photographers;Pre Birthday Shoot;Soft Copy;On The Day Event Coverage");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3L,
                column: "FreeText1",
                value: "PACKAGE 3 (PHOTO & VIDEO)','P3-B',NULL,'1 Photographer;1 Videographer;Pre Birthday Shoot;4-5 minutes Video Highlights;Soft Copy;On The Day Event Coverage");
        }
    }
}
