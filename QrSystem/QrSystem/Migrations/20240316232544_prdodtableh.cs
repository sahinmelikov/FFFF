using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QrSystem.Migrations
{
    public partial class prdodtableh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QrCodes_Restorant_RestorantId",
                table: "QrCodes");

            migrationBuilder.AddColumn<int>(
                name: "RestorantId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RestorantId",
                table: "QrCodes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RestorantId",
                table: "Products",
                column: "RestorantId");

            migrationBuilder.AddForeignKey(
                name: "FK_QrCodes_Restorant_RestorantId",
                table: "QrCodes",
                column: "RestorantId",
                principalTable: "Restorant",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Restorant_RestorantId",
                table: "Products",
                column: "RestorantId",
                principalTable: "Restorant",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QrCodes_Restorant_RestorantId",
                table: "QrCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Restorant_RestorantId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_RestorantId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RestorantId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "RestorantId",
                table: "QrCodes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QrCodes_Restorant_RestorantId",
                table: "QrCodes",
                column: "RestorantId",
                principalTable: "Restorant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
