using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QrSystem.Migrations
{
    public partial class iii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfisantId",
                table: "Tables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfisantName",
                table: "BasketİtemVM",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_OfisantId",
                table: "Tables",
                column: "OfisantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Ofisant_OfisantId",
                table: "Tables",
                column: "OfisantId",
                principalTable: "Ofisant",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Ofisant_OfisantId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_OfisantId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "OfisantId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "OfisantName",
                table: "BasketİtemVM");
        }
    }
}
