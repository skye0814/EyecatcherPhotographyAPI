using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class CartModelFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Carts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da9b53e2-98c3-4b7a-8858-64fc30fe6c8c", "AQAAAAEAACcQAAAAEFmIl33kgeOab2fpyVWcGoENjd2IKfqCquOspU5dYfqk5C0kNOhYfIwo1ucNUV8Ggw==", "f85b23fa-e3c8-4f6e-8a91-5e6aa4dde07a" });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_Id",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_Id",
                table: "Carts",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_Id",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_Id",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Carts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1750379-93bc-4ced-aad3-0f392c20b871", "AQAAAAEAACcQAAAAECOhT6Y305v71D3DQlbCIO2OGu9JBOp7VkyQEgPaA2eBItZSJUoeNbAbyBtF06jOoQ==", "a2c49d40-4185-411f-9102-e9c86b88ba06" });
        }
    }
}
