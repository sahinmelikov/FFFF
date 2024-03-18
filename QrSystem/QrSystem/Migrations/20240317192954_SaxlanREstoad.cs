using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QrSystem.Migrations
{
    public partial class SaxlanREstoad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestorantId",
                table: "SaxlanilanS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResTorantId",
                table: "BasketİtemVM",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SaxlanilanS_RestorantId",
                table: "SaxlanilanS",
                column: "RestorantId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaxlanilanS_Restorant_RestorantId",
                table: "SaxlanilanS",
                column: "RestorantId",
                principalTable: "Restorant",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaxlanilanS_Restorant_RestorantId",
                table: "SaxlanilanS");

            migrationBuilder.DropIndex(
                name: "IX_SaxlanilanS_RestorantId",
                table: "SaxlanilanS");

            migrationBuilder.DropColumn(
                name: "RestorantId",
                table: "SaxlanilanS");

            migrationBuilder.DropColumn(
                name: "ResTorantId",
                table: "BasketİtemVM");
        }
    }
}
