using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B1_Task.Migrations
{
    /// <inheritdoc />
    public partial class change_database_structure_base_on_sheetClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblAccount_TblSheets_TblSheetId",
                table: "TblAccount");

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

            migrationBuilder.RenameColumn(
                name: "TblAccountId",
                table: "TblTurnovers",
                newName: "TblSheetClassId");

            migrationBuilder.RenameIndex(
                name: "IX_TblTurnovers_TblAccountId",
                table: "TblTurnovers",
                newName: "IX_TblTurnovers_TblSheetClassId");

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
                newName: "TblSheetClassId");

            migrationBuilder.RenameIndex(
                name: "IX_TblOpeningBalances_TblAccountId",
                table: "TblOpeningBalances",
                newName: "IX_TblOpeningBalances_TblSheetClassId");

            migrationBuilder.RenameColumn(
                name: "TblAccountId",
                table: "TblClosedBalance",
                newName: "TblSheetClassId");

            migrationBuilder.RenameIndex(
                name: "IX_TblClosedBalance_TblAccountId",
                table: "TblClosedBalance",
                newName: "IX_TblClosedBalance_TblSheetClassId");

            migrationBuilder.RenameColumn(
                name: "TblSheetId",
                table: "TblAccount",
                newName: "TblSheetClassId");

            migrationBuilder.RenameIndex(
                name: "IX_TblAccount_TblSheetId",
                table: "TblAccount",
                newName: "IX_TblAccount_TblSheetClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblAccount_TblSheetClass_TblSheetClassId",
                table: "TblAccount",
                column: "TblSheetClassId",
                principalTable: "TblSheetClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblClosedBalance_TblSheetClass_TblSheetClassId",
                table: "TblClosedBalance",
                column: "TblSheetClassId",
                principalTable: "TblSheetClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblOpeningBalances_TblSheetClass_TblSheetClassId",
                table: "TblOpeningBalances",
                column: "TblSheetClassId",
                principalTable: "TblSheetClass",
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
                name: "FK_TblTurnovers_TblSheetClass_TblSheetClassId",
                table: "TblTurnovers",
                column: "TblSheetClassId",
                principalTable: "TblSheetClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblAccount_TblSheetClass_TblSheetClassId",
                table: "TblAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_TblClosedBalance_TblSheetClass_TblSheetClassId",
                table: "TblClosedBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_TblOpeningBalances_TblSheetClass_TblSheetClassId",
                table: "TblOpeningBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSheetClass_TblSheets_TblSheetId",
                table: "TblSheetClass");

            migrationBuilder.DropForeignKey(
                name: "FK_TblTurnovers_TblSheetClass_TblSheetClassId",
                table: "TblTurnovers");

            migrationBuilder.RenameColumn(
                name: "TblSheetClassId",
                table: "TblTurnovers",
                newName: "TblAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_TblTurnovers_TblSheetClassId",
                table: "TblTurnovers",
                newName: "IX_TblTurnovers_TblAccountId");

            migrationBuilder.RenameColumn(
                name: "TblSheetId",
                table: "TblSheetClass",
                newName: "TblAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_TblSheetClass_TblSheetId",
                table: "TblSheetClass",
                newName: "IX_TblSheetClass_TblAccountId");

            migrationBuilder.RenameColumn(
                name: "TblSheetClassId",
                table: "TblOpeningBalances",
                newName: "TblAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_TblOpeningBalances_TblSheetClassId",
                table: "TblOpeningBalances",
                newName: "IX_TblOpeningBalances_TblAccountId");

            migrationBuilder.RenameColumn(
                name: "TblSheetClassId",
                table: "TblClosedBalance",
                newName: "TblAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_TblClosedBalance_TblSheetClassId",
                table: "TblClosedBalance",
                newName: "IX_TblClosedBalance_TblAccountId");

            migrationBuilder.RenameColumn(
                name: "TblSheetClassId",
                table: "TblAccount",
                newName: "TblSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_TblAccount_TblSheetClassId",
                table: "TblAccount",
                newName: "IX_TblAccount_TblSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblAccount_TblSheets_TblSheetId",
                table: "TblAccount",
                column: "TblSheetId",
                principalTable: "TblSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
