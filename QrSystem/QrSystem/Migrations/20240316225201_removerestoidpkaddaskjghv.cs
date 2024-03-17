using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QrSystem.Migrations
{
    public partial class removerestoidpkaddaskjghv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestorantId",
                table: "QrCodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QrCodes_RestorantId",
                table: "QrCodes",
                column: "RestorantId");

            migrationBuilder.AddForeignKey(
                name: "FK_QrCodes_Restorant_RestorantId",
                table: "QrCodes",
                column: "RestorantId",
                principalTable: "Restorant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QrCodes_Restorant_RestorantId",
                table: "QrCodes");

            migrationBuilder.DropIndex(
                name: "IX_QrCodes_RestorantId",
                table: "QrCodes");

            migrationBuilder.DropColumn(
                name: "RestorantId",
                table: "QrCodes");
        }
    }
}
