using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_SpaceName_SpaceNameId",
                table: "Link");

            migrationBuilder.DropColumn(
                name: "segmentId",
                table: "SpaceName");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "SpaceName",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SpaceNameId",
                table: "Link",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceName_UserId",
                table: "SpaceName",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_SpaceName_SpaceNameId",
                table: "Link",
                column: "SpaceNameId",
                principalTable: "SpaceName",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceName_User_UserId",
                table: "SpaceName",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_SpaceName_SpaceNameId",
                table: "Link");

            migrationBuilder.DropForeignKey(
                name: "FK_SpaceName_User_UserId",
                table: "SpaceName");

            migrationBuilder.DropIndex(
                name: "IX_SpaceName_UserId",
                table: "SpaceName");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SpaceName");

            migrationBuilder.AddColumn<int>(
                name: "segmentId",
                table: "SpaceName",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SpaceNameId",
                table: "Link",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Link_SpaceName_SpaceNameId",
                table: "Link",
                column: "SpaceNameId",
                principalTable: "SpaceName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
