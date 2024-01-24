using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B1_Task.Migrations
{
    /// <inheritdoc />
    public partial class append_TblClosedBalance_to_dbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblClosedBalance_TblSheetClasses_TblSheetClassId",
                table: "TblClosedBalance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblClosedBalance",
                table: "TblClosedBalance");

            migrationBuilder.RenameTable(
                name: "TblClosedBalance",
                newName: "TblClosedBalances");

            migrationBuilder.RenameIndex(
                name: "IX_TblClosedBalance_TblSheetClassId",
                table: "TblClosedBalances",
                newName: "IX_TblClosedBalances_TblSheetClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblClosedBalances",
                table: "TblClosedBalances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblClosedBalances_TblSheetClasses_TblSheetClassId",
                table: "TblClosedBalances",
                column: "TblSheetClassId",
                principalTable: "TblSheetClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblClosedBalances_TblSheetClasses_TblSheetClassId",
                table: "TblClosedBalances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblClosedBalances",
                table: "TblClosedBalances");

            migrationBuilder.RenameTable(
                name: "TblClosedBalances",
                newName: "TblClosedBalance");

            migrationBuilder.RenameIndex(
                name: "IX_TblClosedBalances_TblSheetClassId",
                table: "TblClosedBalance",
                newName: "IX_TblClosedBalance_TblSheetClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblClosedBalance",
                table: "TblClosedBalance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblClosedBalance_TblSheetClasses_TblSheetClassId",
                table: "TblClosedBalance",
                column: "TblSheetClassId",
                principalTable: "TblSheetClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
