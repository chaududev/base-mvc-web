using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCrud.Migrations
{
    public partial class MigradetionCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Address", "Birthday", "Date", "Email", "FullName", "Phone" },
                values: new object[] { 1, "42/32 Nguyễn Huệ, Huế", new DateTime(2001, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "chaudu301@gmail.com", "Châu Hoàng Bích Du", "0943357474" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Address", "Birthday", "Date", "Email", "FullName", "Phone" },
                values: new object[] { 2, "5 Nguyễn Tri Phương, Huế", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vietha@gmail.com", "Nguyễn Viết Hà", "0909099099" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
