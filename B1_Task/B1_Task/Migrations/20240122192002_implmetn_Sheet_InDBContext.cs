using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B1_Task.Migrations
{
    /// <inheritdoc />
    public partial class implmetn_Sheet_InDBContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblSheet_Banks_TblBankId",
                table: "TblSheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblSheet",
                table: "TblSheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Banks",
                table: "Banks");

            migrationBuilder.RenameTable(
                name: "TblSheet",
                newName: "TblSheets");

            migrationBuilder.RenameTable(
                name: "Banks",
                newName: "TblBanks");

            migrationBuilder.RenameIndex(
                name: "IX_TblSheet_TblBankId",
                table: "TblSheets",
                newName: "IX_TblSheets_TblBankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblSheets",
                table: "TblSheets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblBanks",
                table: "TblBanks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblSheets_TblBanks_TblBankId",
                table: "TblSheets",
                column: "TblBankId",
                principalTable: "TblBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblSheets_TblBanks_TblBankId",
                table: "TblSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblSheets",
                table: "TblSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblBanks",
                table: "TblBanks");

            migrationBuilder.RenameTable(
                name: "TblSheets",
                newName: "TblSheet");

            migrationBuilder.RenameTable(
                name: "TblBanks",
                newName: "Banks");

            migrationBuilder.RenameIndex(
                name: "IX_TblSheets_TblBankId",
                table: "TblSheet",
                newName: "IX_TblSheet_TblBankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblSheet",
                table: "TblSheet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Banks",
                table: "Banks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblSheet_Banks_TblBankId",
                table: "TblSheet",
                column: "TblBankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
