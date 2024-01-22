using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B1_Task.Migrations
{
    /// <inheritdoc />
    public partial class initial_field_for_Sheet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblClosedBalance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PassiveBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TblSheetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblClosedBalance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblClosedBalance_TblSheets_TblSheetId",
                        column: x => x.TblSheetId,
                        principalTable: "TblSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblTurnovers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TblSheetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTurnovers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblTurnovers_TblSheets_TblSheetId",
                        column: x => x.TblSheetId,
                        principalTable: "TblSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblClosedBalance_TblSheetId",
                table: "TblClosedBalance",
                column: "TblSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_TblTurnovers_TblSheetId",
                table: "TblTurnovers",
                column: "TblSheetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblClosedBalance");

            migrationBuilder.DropTable(
                name: "TblTurnovers");
        }
    }
}
