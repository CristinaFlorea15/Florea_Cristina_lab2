using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Florea_Cristina_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class Borrowings3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Borrowing_BookID",
                table: "Borrowing");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_BookID",
                table: "Borrowing",
                column: "BookID",
                unique: true,
                filter: "[BookID] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Borrowing_BookID",
                table: "Borrowing");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_BookID",
                table: "Borrowing",
                column: "BookID");
        }
    }
}
