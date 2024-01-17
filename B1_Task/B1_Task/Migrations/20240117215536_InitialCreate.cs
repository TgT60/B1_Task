using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B1_Task.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StringEU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StringRU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositiveNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FolatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDocuments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblDocuments");
        }
    }
}
