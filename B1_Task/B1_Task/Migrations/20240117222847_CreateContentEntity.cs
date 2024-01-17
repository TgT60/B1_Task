using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B1_Task.Migrations
{
    /// <inheritdoc />
    public partial class CreateContentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "TblDocuments");

            migrationBuilder.DropColumn(
                name: "FolatNumber",
                table: "TblDocuments");

            migrationBuilder.DropColumn(
                name: "PositiveNumber",
                table: "TblDocuments");

            migrationBuilder.DropColumn(
                name: "StringEU",
                table: "TblDocuments");

            migrationBuilder.DropColumn(
                name: "StringRU",
                table: "TblDocuments");

            migrationBuilder.CreateTable(
                name: "TblContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StringEU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StringRU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositiveNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FolatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TblDocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblContents_TblDocuments_TblDocumentId",
                        column: x => x.TblDocumentId,
                        principalTable: "TblDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblContents_TblDocumentId",
                table: "TblContents",
                column: "TblDocumentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblContents");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "TblDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FolatNumber",
                table: "TblDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PositiveNumber",
                table: "TblDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StringEU",
                table: "TblDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StringRU",
                table: "TblDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
