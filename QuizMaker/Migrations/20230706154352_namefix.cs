using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizMaker.Migrations
{
    /// <inheritdoc />
    public partial class namefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Answear",
                table: "QuizQuestion",
                newName: "Answer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "QuizQuestion",
                newName: "Answear");
        }
    }
}
