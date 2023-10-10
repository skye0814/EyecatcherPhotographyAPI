using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class PutKeyInCustomerID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_Id",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ed57acf-cb38-4df4-ac5f-be45115fd783", "22dc9879-b5f7-4fff-bd8d-b3821455b6d5" });

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: "ffa913a6-5448-4d58-9ad7-ed7729d31345");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5");

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryID",
                keyValue: 4L);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Customers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerID",
                table: "Customers",
                column: "CustomerID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_Id",
                table: "Customers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_Id",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerID",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "22dc9879-b5f7-4fff-bd8d-b3821455b6d5", 0, "5479a485-a469-4bd5-9eaf-a6b8f54b2ce0", "IdentityUser", "skye0814@gmail.com", false, false, null, "SKYE0814@GMAIL.COM", "SKYE0814", "AQAAAAEAACcQAAAAEGpTWmfyXEqDwihMT5BMozaJvI/94jLTbLNXMjAVygTPdsDIn0CXuGY9Bcr3kPGzHw==", null, false, "0f7cdd78-a14a-4c52-baa1-39cad8f20091", false, "skye0814" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "ProductCategoryID", "CategoryDescription", "CategoryName", "ImageUrl" },
                values: new object[] { 1L, "EyeCatch your birthday with wonderful shots", "Birthday Services", "images/productcategories/birthday1.jpg" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "ProductCategoryID", "CategoryDescription", "CategoryName", "ImageUrl" },
                values: new object[] { 2L, "EyeCatch your beautiful kid of joy", "Christening Services", "images/productcategories/christening1.jpg" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "ProductCategoryID", "CategoryDescription", "CategoryName", "ImageUrl" },
                values: new object[] { 3L, "EyeCatch your wedding memories with your lifetime partner", "Wedding Services", "images/productcategories/wedding1.jpg" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "ProductCategoryID", "CategoryDescription", "CategoryName", "ImageUrl" },
                values: new object[] { 4L, "Want to see more? Click here for other EyeCatcher services", "Other Services", "images/productcategories/others1.jpg" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6ed57acf-cb38-4df4-ac5f-be45115fd783", "22dc9879-b5f7-4fff-bd8d-b3821455b6d5" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "ContactNumber", "FirstName", "Id", "LastName", "MiddleName" },
                values: new object[] { "ffa913a6-5448-4d58-9ad7-ed7729d31345", null, null, "John Matthew", "22dc9879-b5f7-4fff-bd8d-b3821455b6d5", "Arquelola", "Cruz" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 1L, null, "1 Photographer;Pre Birthday Shoot;Soft Copy;On The Day Event Coverage", null, null, null, 4500.0, 1L, null, "PACKAGE 1 (PHOTO)", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 2L, null, "2 Photographers;Pre Birthday Shoot;Soft Copy;On The Day Event Coverage", null, null, null, 6500.0, 1L, null, "PACKAGE 2 (PHOTO)", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 3L, null, "1 Photographer;1 Videographer;Pre Birthday Shoot;4-5 minutes Video Highlights;Soft Copy;On The Day Event Coverage", null, null, null, 8500.0, 1L, null, "PACKAGE 3 (PHOTO & VIDEO)", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 4L, null, "2 Photographers;1 videographer;Pre Debut or Birthday Shoot;Soft Copy;4-5 minutes Video Highlights;Unlimited Shots Photo Booth (2 hours);20 pages Hardbound Photo Album;Hair and Make Up Artist;On The Day Event Coverage", null, null, null, 22000.0, 1L, null, "ALL IN PACKAGE", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 5L, null, "", null, null, null, 3000.0, 2L, null, "PACKAGE 1 (PHOTO)", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 6L, null, "", null, null, null, 5500.0, 2L, null, "PACKAGE 2 (PHOTO)", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 7L, null, "", null, null, null, 7500.0, 2L, null, "PACKAGE 3 (PHOTO & VIDEO)", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 8L, null, "", null, null, null, 5500.0, 2L, null, "PACKAGE 4 (PHOTO+PHOTOBOOTH)", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 9L, null, "", null, null, null, 6500.0, 3L, null, "PACKAGE A (PHOTO)", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 10L, null, "", null, null, null, 12500.0, 3L, null, "PACKAGE B1 (PHOTO & VIDEO)", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 11L, null, "", null, null, null, 14000.0, 3L, null, "PACKAGE B2 (PHOTO & VIDEO)", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 12L, null, "", null, null, null, 17000.0, 3L, null, "PACKAGE C1 (PHOTO+VIDEO+ALBUM)", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 13L, null, "", null, null, null, 18500.0, 3L, null, "PACKAGE C2 (PHOTO+VIDEO+ALBUM)", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 14L, null, "", null, null, null, 17500.0, 3L, null, "PACKAGE D1 (PHOTO+VIDEO+HMUA)", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 15L, null, "", null, null, null, 17500.0, 3L, null, "PACKAGE D2 (PHOTO+VIDEO+ALBUM)", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 16L, null, "", null, null, null, 38000.0, 3L, null, "PACKAGE E (ALL IN)", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 17L, null, "", null, null, null, 5000.0, 4L, null, "HAIR AND MAKE UP ARTIST A", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 18L, null, "", null, null, null, 12000.0, 4L, null, "HAIR AND MAKE UP ARTIST B", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 19L, null, "", null, null, null, 500.0, 4L, null, "BRIDESMAIDS HAIR AND MAKE UP", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 20L, null, "", null, null, null, 5000.0, 4L, null, "COORDINATOR", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 21L, null, "", null, null, null, 5000.0, 4L, null, "SOUNDS AND LIGHTS", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 22L, null, "", null, null, null, 5000.0, 4L, null, "EMCEE", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 23L, null, "", null, null, null, 4500.0, 4L, null, "40-PAGE PHOTO ALBUM IN HARDBOUND", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 24L, null, "", null, null, null, 2500.0, 4L, null, "20-PAGE PHOTO ALBUM IN HARDBOUND", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 25L, null, "", null, null, null, 6000.0, 4L, null, "SAME DAY EDIT (SDE EDITOR)", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 26L, null, "", null, null, null, 4000.0, 4L, null, "AERIAL DRONE SHOTS", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 27L, null, "", null, null, null, 700.0, 4L, null, "FLASH DRIVE", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 28L, null, "", null, null, null, 3000.0, 4L, null, "ADDITIONAL PHOTOGRAPHER", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CartID", "FreeText1", "FreeText2", "FreeText3", "FreeText4", "Price", "ProductCategoryID", "ProductDescription", "ProductName", "ProductTag" },
                values: new object[] { 29L, null, "", null, null, null, 4500.0, 4L, null, "ADDITIONAL VIDEOGRAPHER", "" });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_Id",
                table: "Customers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
