using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class seedAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId"},
                values: new object[] { "6ed57acf-cb38-4df4-ac5f-be45115fd783", "22dc9879-b5f7-4fff-bd8d-b3821455b6d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5479a485-a469-4bd5-9eaf-a6b8f54b2ce0", "AQAAAAEAACcQAAAAEGpTWmfyXEqDwihMT5BMozaJvI/94jLTbLNXMjAVygTPdsDIn0CXuGY9Bcr3kPGzHw==", "0f7cdd78-a14a-4c52-baa1-39cad8f20091" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22dc9879-b5f7-4fff-bd8d-b3821455b6d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca622645-65b6-46e9-af63-706e125f2d4d", "AQAAAAEAACcQAAAAEMZfxVZWzN4r7fCVgNkISYSTPx5yCVfQnhrgTOw1H/mGP6U5rv7IgpiGjQXcliokjw==", "219af195-851f-4a6c-8fe5-0d0244aef53b" });
        }
    }
}
