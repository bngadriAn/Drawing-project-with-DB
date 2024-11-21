using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrawingProject.Migrations
{
    /// <inheritdoc />
    public partial class Drawing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drawings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CharPosX = table.Column<int>(type: "int", nullable: false),
                    CharPosY = table.Column<int>(type: "int", nullable: false),
                    GetCharNum = table.Column<int>(type: "int", nullable: false),
                    GetColorNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drawings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drawings");
        }
    }
}
