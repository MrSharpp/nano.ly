using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Refresh_Token_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "User",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "User",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "User",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "User",
                newName: "email");
        }
    }
}
