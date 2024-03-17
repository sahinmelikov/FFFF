using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QrSystem.Migrations
{
    public partial class Adminpanel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Restorant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Restorant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RestorantId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RestorantId",
                table: "AspNetUsers",
                column: "RestorantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Restorant_RestorantId",
                table: "AspNetUsers",
                column: "RestorantId",
                principalTable: "Restorant",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Restorant_RestorantId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RestorantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Restorant");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Restorant");

            migrationBuilder.DropColumn(
                name: "RestorantId",
                table: "AspNetUsers");
        }
    }
}
