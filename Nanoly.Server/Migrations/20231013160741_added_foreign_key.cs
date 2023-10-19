using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class added_foreign_key : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpaceName_User_UserId",
                table: "SpaceName");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SpaceName",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceName_User_UserId",
                table: "SpaceName",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpaceName_User_UserId",
                table: "SpaceName");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SpaceName",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceName_User_UserId",
                table: "SpaceName",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
