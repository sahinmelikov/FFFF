using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QrSystem.Migrations
{
    public partial class Add123u : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTimeExpired",
                table: "SaxlanilanS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTimeExpired",
                table: "SaxlanilanS",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
