using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ProductLabelSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "945ea3dc-2b16-434a-9cef-a8943ad91752", "AQAAAAEAACcQAAAAEPY5iUp8J8jyDoSpNsWuJ0dbe6GNO12XLJ23ZzybrrHeGtLcxVV0DZ4U+6vuaBWpkw==", "8b7e72bf-9863-4028-be2f-9baef330addf" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1L,
                column: "Label",
                value: "Classic");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2L,
                column: "Label",
                value: "Classic");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3L,
                column: "Label",
                value: "Elite");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4L,
                column: "Label",
                value: "Prime");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5L,
                column: "Label",
                value: "Classic");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6L,
                column: "Label",
                value: "Classic");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7L,
                column: "Label",
                value: "Elite");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8L,
                column: "Label",
                value: "Elite");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 9L,
                column: "Label",
                value: "Classic");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 10L,
                column: "Label",
                value: "Elite");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 11L,
                column: "Label",
                value: "Elite");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 12L,
                column: "Label",
                value: "Prime");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 13L,
                column: "Label",
                value: "Prime");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 14L,
                column: "Label",
                value: "Prime");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 15L,
                column: "Label",
                value: "Prime");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 16L,
                column: "Label",
                value: "Grand");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da9b53e2-98c3-4b7a-8858-64fc30fe6c8c", "AQAAAAEAACcQAAAAEFmIl33kgeOab2fpyVWcGoENjd2IKfqCquOspU5dYfqk5C0kNOhYfIwo1ucNUV8Ggw==", "f85b23fa-e3c8-4f6e-8a91-5e6aa4dde07a" });
        }
    }
}
