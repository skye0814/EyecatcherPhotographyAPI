using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SeedDatav2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aedf0ff9-d199-4af0-9a5f-8eb434236e3c", "AQAAAAEAACcQAAAAEG5flMtoCcCcfLLEoO4rMP5s813YYK+vIx2vGUZTuUjfefzh1tSAGcNiTUHvTPQ4Cg==", "3f6fb498-a78d-4810-8f34-7f18f59b27e4" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 17L,
                column: "ProductCategoryID",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 18L,
                column: "ProductCategoryID",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 19L,
                column: "ProductCategoryID",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 20L,
                column: "ProductCategoryID",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 21L,
                column: "ProductCategoryID",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 22L,
                column: "ProductCategoryID",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 23L,
                column: "ProductCategoryID",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 24L,
                column: "ProductCategoryID",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 25L,
                column: "ProductCategoryID",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 26L,
                column: "ProductCategoryID",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 27L,
                column: "ProductCategoryID",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 28L,
                column: "ProductCategoryID",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 29L,
                column: "ProductCategoryID",
                value: 4L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: 17L,
                column: "ProductCategoryID",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 18L,
                column: "ProductCategoryID",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 19L,
                column: "ProductCategoryID",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 20L,
                column: "ProductCategoryID",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 21L,
                column: "ProductCategoryID",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 22L,
                column: "ProductCategoryID",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 23L,
                column: "ProductCategoryID",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 24L,
                column: "ProductCategoryID",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 25L,
                column: "ProductCategoryID",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 26L,
                column: "ProductCategoryID",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 27L,
                column: "ProductCategoryID",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 28L,
                column: "ProductCategoryID",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 29L,
                column: "ProductCategoryID",
                value: 1L);
        }
    }
}
