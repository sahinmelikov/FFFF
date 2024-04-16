using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QrSystem.Migrations
{
    public partial class bigparentrestorant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestorantId",
                table: "ParentsCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestorantId",
                table: "BigParentCategory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParentsCategories_RestorantId",
                table: "ParentsCategories",
                column: "RestorantId");

            migrationBuilder.CreateIndex(
                name: "IX_BigParentCategory_RestorantId",
                table: "BigParentCategory",
                column: "RestorantId");

            migrationBuilder.AddForeignKey(
                name: "FK_BigParentCategory_Restorant_RestorantId",
                table: "BigParentCategory",
                column: "RestorantId",
                principalTable: "Restorant",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentsCategories_Restorant_RestorantId",
                table: "ParentsCategories",
                column: "RestorantId",
                principalTable: "Restorant",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BigParentCategory_Restorant_RestorantId",
                table: "BigParentCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentsCategories_Restorant_RestorantId",
                table: "ParentsCategories");

            migrationBuilder.DropIndex(
                name: "IX_ParentsCategories_RestorantId",
                table: "ParentsCategories");

            migrationBuilder.DropIndex(
                name: "IX_BigParentCategory_RestorantId",
                table: "BigParentCategory");

            migrationBuilder.DropColumn(
                name: "RestorantId",
                table: "ParentsCategories");

            migrationBuilder.DropColumn(
                name: "RestorantId",
                table: "BigParentCategory");
        }
    }
}
