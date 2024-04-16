using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QrSystem.Migrations
{
    public partial class bigparentrestorantOfisant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ofisant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestorantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofisant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ofisant_Restorant_RestorantId",
                        column: x => x.RestorantId,
                        principalTable: "Restorant",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ofisant_RestorantId",
                table: "Ofisant",
                column: "RestorantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ofisant");
        }
    }
}
