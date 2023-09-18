using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38b13138-2eb6-415b-b1d4-c36f6c6fdee4",
                column: "ConcurrencyStamp",
                value: "aa54dd14-3502-4607-b3ae-bc8442ccec2c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ed57acf-cb38-4df4-ac5f-be45115fd783",
                column: "ConcurrencyStamp",
                value: "f138d5d8-c8dd-412f-a53a-34d79242f281");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3e48790-180a-4f50-96f5-59b76d7a955d", "AQAAAAEAACcQAAAAEBf87/J9vC/vl7wyPg/vkrREx+JAsNt+msyKYQxoxQbEMuoQsLylPQH0wL6zhiOsvw==", "2d3e6945-e14c-411f-b521-d0b5684cb2ed" });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryID",
                keyValue: 1L,
                column: "ImageUrl",
                value: "/images/productcategories/birthday1.jpg");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryID",
                keyValue: 2L,
                column: "ImageUrl",
                value: "/images/productcategories/christening1.jpg");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryID",
                keyValue: 3L,
                column: "ImageUrl",
                value: "/images/productcategories/wedding1.jpg");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryID",
                keyValue: 4L,
                column: "ImageUrl",
                value: "/images/productcategories/others1.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38b13138-2eb6-415b-b1d4-c36f6c6fdee4",
                column: "ConcurrencyStamp",
                value: "88e24bfc-cd25-49e6-8133-e23ee6061f2b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ed57acf-cb38-4df4-ac5f-be45115fd783",
                column: "ConcurrencyStamp",
                value: "a2f91fe9-24a5-4bca-98e2-4fb4b869c363");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "074b23e8-04fb-4a98-9f65-a153da614799", "AQAAAAEAACcQAAAAEJP25rcldOoRRi38j4Y5ZkjoDl+6c7CpWBDyLR7tig0g4p8Hsd0HxOWiy6NPWkmKow==", "9187fc0e-5745-486f-b27a-fe79b75b36fb" });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryID",
                keyValue: 1L,
                column: "ImageUrl",
                value: "https://localhost:7081/images/productcategories/birthday1.jpg");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryID",
                keyValue: 2L,
                column: "ImageUrl",
                value: "https://localhost:7081/images/productcategories/christening1.jpg");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryID",
                keyValue: 3L,
                column: "ImageUrl",
                value: "https://localhost:7081/images/productcategories/wedding1.jpg");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryID",
                keyValue: 4L,
                column: "ImageUrl",
                value: "https://localhost:7081/images/productcategories/others1.jpg");
        }
    }
}
