using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B1_Task.Migrations
{
    /// <inheritdoc />
    public partial class add_filds_on_sheetClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "TblSheetClass");

            migrationBuilder.AddColumn<decimal>(
                name: "SUMTurnoversCredit",
                table: "TblSheetClass",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SumCloseActiveBalance",
                table: "TblSheetClass",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SumClosePassiveBalance",
                table: "TblSheetClass",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SumOpenActiveBalance",
                table: "TblSheetClass",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SumOpenPassiveBalance",
                table: "TblSheetClass",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SumTurnoversDebit",
                table: "TblSheetClass",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SUMTurnoversCredit",
                table: "TblSheetClass");

            migrationBuilder.DropColumn(
                name: "SumCloseActiveBalance",
                table: "TblSheetClass");

            migrationBuilder.DropColumn(
                name: "SumClosePassiveBalance",
                table: "TblSheetClass");

            migrationBuilder.DropColumn(
                name: "SumOpenActiveBalance",
                table: "TblSheetClass");

            migrationBuilder.DropColumn(
                name: "SumOpenPassiveBalance",
                table: "TblSheetClass");

            migrationBuilder.DropColumn(
                name: "SumTurnoversDebit",
                table: "TblSheetClass");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TblSheetClass",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
