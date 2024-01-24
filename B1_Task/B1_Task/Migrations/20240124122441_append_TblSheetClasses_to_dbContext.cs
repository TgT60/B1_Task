using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B1_Task.Migrations
{
    /// <inheritdoc />
    public partial class append_TblSheetClasses_to_dbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblSheetClass",
                table: "TblSheetClass");

            migrationBuilder.RenameTable(
                name: "TblSheetClass",
                newName: "TblSheetClasses");

            migrationBuilder.RenameIndex(
                name: "IX_TblSheetClass_TblSheetId",
                table: "TblSheetClasses",
                newName: "IX_TblSheetClasses_TblSheetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblSheetClasses",
                table: "TblSheetClasses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblAccount_TblSheetClasses_TblSheetClassId",
                table: "TblAccount",
                column: "TblSheetClassId",
                principalTable: "TblSheetClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblClosedBalance_TblSheetClasses_TblSheetClassId",
                table: "TblClosedBalance",
                column: "TblSheetClassId",
                principalTable: "TblSheetClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblOpeningBalances_TblSheetClasses_TblSheetClassId",
                table: "TblOpeningBalances",
                column: "TblSheetClassId",
                principalTable: "TblSheetClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSheetClasses_TblSheets_TblSheetId",
                table: "TblSheetClasses",
                column: "TblSheetId",
                principalTable: "TblSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblTurnovers_TblSheetClasses_TblSheetClassId",
                table: "TblTurnovers",
                column: "TblSheetClassId",
                principalTable: "TblSheetClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblAccount_TblSheetClasses_TblSheetClassId",
                table: "TblAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_TblClosedBalance_TblSheetClasses_TblSheetClassId",
                table: "TblClosedBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_TblOpeningBalances_TblSheetClasses_TblSheetClassId",
                table: "TblOpeningBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSheetClasses_TblSheets_TblSheetId",
                table: "TblSheetClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_TblTurnovers_TblSheetClasses_TblSheetClassId",
                table: "TblTurnovers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblSheetClasses",
                table: "TblSheetClasses");

            migrationBuilder.RenameTable(
                name: "TblSheetClasses",
                newName: "TblSheetClass");

            migrationBuilder.RenameIndex(
                name: "IX_TblSheetClasses_TblSheetId",
                table: "TblSheetClass",
                newName: "IX_TblSheetClass_TblSheetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblSheetClass",
                table: "TblSheetClass",
                column: "Id");

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
    }
}
