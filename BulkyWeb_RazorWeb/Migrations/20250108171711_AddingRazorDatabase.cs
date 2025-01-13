using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BulkyWeb_RazorWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddingRazorDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "ID", "DisplayOrder", "Name1" },
                values: new object[,]
                {
                    { 1, 1, "Action" },
                    { 2, 2, "Sc-fi" },
                    { 3, 3, "History" },
                    { 4, 4, "Horrer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
