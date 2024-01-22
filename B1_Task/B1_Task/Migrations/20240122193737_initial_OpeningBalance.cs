using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B1_Task.Migrations
{
    /// <inheritdoc />
    public partial class initial_OpeningBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Account",
                table: "TblSheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TblOpeningBalances",
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
                    table.PrimaryKey("PK_TblOpeningBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblOpeningBalances_TblSheets_TblSheetId",
                        column: x => x.TblSheetId,
                        principalTable: "TblSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblOpeningBalances_TblSheetId",
                table: "TblOpeningBalances",
                column: "TblSheetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblOpeningBalances");

            migrationBuilder.DropColumn(
                name: "Account",
                table: "TblSheets");
        }
    }
}
