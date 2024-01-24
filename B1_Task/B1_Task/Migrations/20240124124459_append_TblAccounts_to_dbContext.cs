using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B1_Task.Migrations
{
    /// <inheritdoc />
    public partial class append_TblAccounts_to_dbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblAccount_TblSheetClasses_TblSheetClassId",
                table: "TblAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblAccount",
                table: "TblAccount");

            migrationBuilder.RenameTable(
                name: "TblAccount",
                newName: "TblAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_TblAccount_TblSheetClassId",
                table: "TblAccounts",
                newName: "IX_TblAccounts_TblSheetClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblAccounts",
                table: "TblAccounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblAccounts_TblSheetClasses_TblSheetClassId",
                table: "TblAccounts",
                column: "TblSheetClassId",
                principalTable: "TblSheetClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblAccounts_TblSheetClasses_TblSheetClassId",
                table: "TblAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblAccounts",
                table: "TblAccounts");

            migrationBuilder.RenameTable(
                name: "TblAccounts",
                newName: "TblAccount");

            migrationBuilder.RenameIndex(
                name: "IX_TblAccounts_TblSheetClassId",
                table: "TblAccount",
                newName: "IX_TblAccount_TblSheetClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblAccount",
                table: "TblAccount",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblAccount_TblSheetClasses_TblSheetClassId",
                table: "TblAccount",
                column: "TblSheetClassId",
                principalTable: "TblSheetClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
