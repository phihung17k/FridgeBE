using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeBE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIngredientProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "ingredient",
                newName: "ImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "ingredient",
                newName: "Image");
        }
    }
}
