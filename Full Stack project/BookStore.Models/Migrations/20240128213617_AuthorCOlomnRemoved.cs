using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Models.Migrations
{
    /// <inheritdoc />
    public partial class AuthorCOlomnRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
