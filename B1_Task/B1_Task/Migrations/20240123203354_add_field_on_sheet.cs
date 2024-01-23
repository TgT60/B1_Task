using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B1_Task.Migrations
{
    /// <inheritdoc />
    public partial class add_field_on_sheet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SUMTurnoversCredit",
                table: "TblSheetClass",
                newName: "SumTurnoversCredit");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSumCloseActiveBalance",
                table: "TblSheets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSumClosePassiveBalance",
                table: "TblSheets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSumOpenActiveBalance",
                table: "TblSheets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSumOpenPassiveBalance",
                table: "TblSheets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSumTurnoversCredit",
                table: "TblSheets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSumTurnoversDebit",
                table: "TblSheets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalSumCloseActiveBalance",
                table: "TblSheets");

            migrationBuilder.DropColumn(
                name: "TotalSumClosePassiveBalance",
                table: "TblSheets");

            migrationBuilder.DropColumn(
                name: "TotalSumOpenActiveBalance",
                table: "TblSheets");

            migrationBuilder.DropColumn(
                name: "TotalSumOpenPassiveBalance",
                table: "TblSheets");

            migrationBuilder.DropColumn(
                name: "TotalSumTurnoversCredit",
                table: "TblSheets");

            migrationBuilder.DropColumn(
                name: "TotalSumTurnoversDebit",
                table: "TblSheets");

            migrationBuilder.RenameColumn(
                name: "SumTurnoversCredit",
                table: "TblSheetClass",
                newName: "SUMTurnoversCredit");
        }
    }
}
