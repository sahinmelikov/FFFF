using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QrSystem.Migrations
{
    public partial class Add123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTimeExpired",
                table: "SaxlanilanS",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "BasketİtemVM",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTimeExpired",
                table: "BasketİtemVM",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTimeExpired",
                table: "SaxlanilanS");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "BasketİtemVM");

            migrationBuilder.DropColumn(
                name: "IsTimeExpired",
                table: "BasketİtemVM");
        }
    }
}
