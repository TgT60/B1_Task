using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B1_Task.Migrations
{
    /// <inheritdoc />
    public partial class Initial_ProcdureEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblProcedureResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalSumPositive = table.Column<long>(type: "bigint", nullable: false),
                    MedianValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProcedureResults", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblProcedureResults");
        }
    }
}
