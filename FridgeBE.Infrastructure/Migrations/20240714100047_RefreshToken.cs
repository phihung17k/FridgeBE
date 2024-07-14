using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeBE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "userlogin");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "userlogin",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "userlogin");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "userlogin",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
