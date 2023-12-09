using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class CartModelRework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Carts_CartID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CartID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CartID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "TotalAmounts",
                table: "Carts");

            migrationBuilder.AddColumn<float>(
                name: "Amount",
                table: "Carts",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProductID",
                table: "Carts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1750379-93bc-4ced-aad3-0f392c20b871", "AQAAAAEAACcQAAAAECOhT6Y305v71D3DQlbCIO2OGu9JBOp7VkyQEgPaA2eBItZSJUoeNbAbyBtF06jOoQ==", "a2c49d40-4185-411f-9102-e9c86b88ba06" });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductID",
                table: "Carts",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Products_ProductID",
                table: "Carts",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Products_ProductID",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ProductID",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Carts");

            migrationBuilder.AddColumn<long>(
                name: "CartID",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerID",
                table: "Carts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalAmounts",
                table: "Carts",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ed502b7-f395-4a61-a2d8-0eb611d4b7ba", "AQAAAAEAACcQAAAAEDJwffIa4FvWglTUYq1bYGvK1TdyC9I9wYAWofA18oPZ6/L394TUl1VEijbeEYqJMg==", "b5e4141e-4820-46f8-bc53-3e0ede29038e" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CartID",
                table: "Products",
                column: "CartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Carts_CartID",
                table: "Products",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "CartID");
        }
    }
}
