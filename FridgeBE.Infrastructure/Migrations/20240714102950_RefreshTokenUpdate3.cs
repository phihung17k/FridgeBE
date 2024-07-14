using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeBE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefreshTokenUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpireTime",
                table: "userlogin",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshTokenExpireTime",
                table: "userlogin");
        }
    }
}
