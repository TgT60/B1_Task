using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B1_Task.Migrations
{
    /// <inheritdoc />
    public partial class initial_sheetClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblSheetClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SheetId = table.Column<int>(type: "int", nullable: false),
                    TblSheetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSheetClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblSheetClass_TblSheets_TblSheetId",
                        column: x => x.TblSheetId,
                        principalTable: "TblSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblSheetClass_TblSheetId",
                table: "TblSheetClass",
                column: "TblSheetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblSheetClass");
        }
    }
}
