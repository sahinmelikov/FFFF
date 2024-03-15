using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QrSystem.Migrations
{
    public partial class yorumsil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNote",
                table: "SaxlanilanS");

            migrationBuilder.AddColumn<string>(
                name: "OrderNote",
                table: "BasketİtemVM",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNote",
                table: "BasketİtemVM");

            migrationBuilder.AddColumn<string>(
                name: "OrderNote",
                table: "SaxlanilanS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
