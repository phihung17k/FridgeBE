using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeBE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_useraccount_UserAccountId",
                table: "UserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "userlogin");

            migrationBuilder.RenameIndex(
                name: "IX_UserLogins_UserAccountId",
                table: "userlogin",
                newName: "IX_userlogin_UserAccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userlogin",
                table: "userlogin",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userlogin_useraccount_UserAccountId",
                table: "userlogin",
                column: "UserAccountId",
                principalTable: "useraccount",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userlogin_useraccount_UserAccountId",
                table: "userlogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userlogin",
                table: "userlogin");

            migrationBuilder.RenameTable(
                name: "userlogin",
                newName: "UserLogins");

            migrationBuilder.RenameIndex(
                name: "IX_userlogin_UserAccountId",
                table: "UserLogins",
                newName: "IX_UserLogins_UserAccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_useraccount_UserAccountId",
                table: "UserLogins",
                column: "UserAccountId",
                principalTable: "useraccount",
                principalColumn: "Id");
        }
    }
}
