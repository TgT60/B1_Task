using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B1_Task.Migrations
{
    /// <inheritdoc />
    public partial class change_database_structure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblClosedBalance_TblSheets_TblSheetId",
                table: "TblClosedBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_TblOpeningBalances_TblSheets_TblSheetId",
                table: "TblOpeningBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSheetClass_TblSheets_TblSheetId",
                table: "TblSheetClass");

            migrationBuilder.DropForeignKey(
                name: "FK_TblTurnovers_TblSheets_TblSheetId",
                table: "TblTurnovers");

            migrationBuilder.DropColumn(
                name: "SheetId",
                table: "TblSheetClass");

            migrationBuilder.DropColumn(
                name: "LastDate",
                table: "TblBanks");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "TblBanks");

            migrationBuilder.RenameColumn(
                name: "TblSheetId",
                table: "TblTurnovers",
                newName: "TblAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_TblTurnovers_TblSheetId",
                table: "TblTurnovers",
                newName: "IX_TblTurnovers_TblAccountId");

            migrationBuilder.RenameColumn(
                name: "Account",
                table: "TblSheets",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "TblSheetId",
                table: "TblSheetClass",
                newName: "TblAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_TblSheetClass_TblSheetId",
                table: "TblSheetClass",
                newName: "IX_TblSheetClass_TblAccountId");

            migrationBuilder.RenameColumn(
                name: "TblSheetId",
                table: "TblOpeningBalances",
                newName: "TblAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_TblOpeningBalances_TblSheetId",
                table: "TblOpeningBalances",
                newName: "IX_TblOpeningBalances_TblAccountId");

            migrationBuilder.RenameColumn(
                name: "TblSheetId",
                table: "TblClosedBalance",
                newName: "TblAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_TblClosedBalance_TblSheetId",
                table: "TblClosedBalance",
                newName: "IX_TblClosedBalance_TblAccountId");

            migrationBuilder.AddColumn<string>(
                name: "EndDate",
                table: "TblSheets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TblAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TblSheetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblAccount_TblSheets_TblSheetId",
                        column: x => x.TblSheetId,
                        principalTable: "TblSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblAccount_TblSheetId",
                table: "TblAccount",
                column: "TblSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblClosedBalance_TblAccount_TblAccountId",
                table: "TblClosedBalance",
                column: "TblAccountId",
                principalTable: "TblAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblOpeningBalances_TblAccount_TblAccountId",
                table: "TblOpeningBalances",
                column: "TblAccountId",
                principalTable: "TblAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSheetClass_TblAccount_TblAccountId",
                table: "TblSheetClass",
                column: "TblAccountId",
                principalTable: "TblAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblTurnovers_TblAccount_TblAccountId",
                table: "TblTurnovers",
                column: "TblAccountId",
                principalTable: "TblAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblClosedBalance_TblAccount_TblAccountId",
                table: "TblClosedBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_TblOpeningBalances_TblAccount_TblAccountId",
                table: "TblOpeningBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSheetClass_TblAccount_TblAccountId",
                table: "TblSheetClass");

            migrationBuilder.DropForeignKey(
                name: "FK_TblTurnovers_TblAccount_TblAccountId",
                table: "TblTurnovers");

            migrationBuilder.DropTable(
                name: "TblAccount");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "TblSheets");

            migrationBuilder.RenameColumn(
                name: "TblAccountId",
                table: "TblTurnovers",
                newName: "TblSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_TblTurnovers_TblAccountId",
                table: "TblTurnovers",
                newName: "IX_TblTurnovers_TblSheetId");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "TblSheets",
                newName: "Account");

            migrationBuilder.RenameColumn(
                name: "TblAccountId",
                table: "TblSheetClass",
                newName: "TblSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_TblSheetClass_TblAccountId",
                table: "TblSheetClass",
                newName: "IX_TblSheetClass_TblSheetId");

            migrationBuilder.RenameColumn(
                name: "TblAccountId",
                table: "TblOpeningBalances",
                newName: "TblSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_TblOpeningBalances_TblAccountId",
                table: "TblOpeningBalances",
                newName: "IX_TblOpeningBalances_TblSheetId");

            migrationBuilder.RenameColumn(
                name: "TblAccountId",
                table: "TblClosedBalance",
                newName: "TblSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_TblClosedBalance_TblAccountId",
                table: "TblClosedBalance",
                newName: "IX_TblClosedBalance_TblSheetId");

            migrationBuilder.AddColumn<int>(
                name: "SheetId",
                table: "TblSheetClass",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastDate",
                table: "TblBanks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartDate",
                table: "TblBanks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_TblClosedBalance_TblSheets_TblSheetId",
                table: "TblClosedBalance",
                column: "TblSheetId",
                principalTable: "TblSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblOpeningBalances_TblSheets_TblSheetId",
                table: "TblOpeningBalances",
                column: "TblSheetId",
                principalTable: "TblSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSheetClass_TblSheets_TblSheetId",
                table: "TblSheetClass",
                column: "TblSheetId",
                principalTable: "TblSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblTurnovers_TblSheets_TblSheetId",
                table: "TblTurnovers",
                column: "TblSheetId",
                principalTable: "TblSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
