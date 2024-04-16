using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QrSystem.Migrations
{
    public partial class bigparent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bigParentCategoryId",
                table: "ParentsCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BigParentCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BigParentCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParentsCategories_bigParentCategoryId",
                table: "ParentsCategories",
                column: "bigParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentsCategories_BigParentCategory_bigParentCategoryId",
                table: "ParentsCategories",
                column: "bigParentCategoryId",
                principalTable: "BigParentCategory",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParentsCategories_BigParentCategory_bigParentCategoryId",
                table: "ParentsCategories");

            migrationBuilder.DropTable(
                name: "BigParentCategory");

            migrationBuilder.DropIndex(
                name: "IX_ParentsCategories_bigParentCategoryId",
                table: "ParentsCategories");

            migrationBuilder.DropColumn(
                name: "bigParentCategoryId",
                table: "ParentsCategories");
        }
    }
}
