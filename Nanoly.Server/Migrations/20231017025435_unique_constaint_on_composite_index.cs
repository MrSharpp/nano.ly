using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class unique_constaint_on_composite_index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_SpaceName_SpaceNameId",
                table: "Link");

            migrationBuilder.AlterColumn<int>(
                name: "SpaceNameId",
                table: "Link",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Link_name_SpaceNameId",
                table: "Link",
                columns: new[] { "name", "SpaceNameId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Link_SpaceName_SpaceNameId",
                table: "Link",
                column: "SpaceNameId",
                principalTable: "SpaceName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_SpaceName_SpaceNameId",
                table: "Link");

            migrationBuilder.DropIndex(
                name: "IX_Link_name_SpaceNameId",
                table: "Link");

            migrationBuilder.AlterColumn<int>(
                name: "SpaceNameId",
                table: "Link",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_SpaceName_SpaceNameId",
                table: "Link",
                column: "SpaceNameId",
                principalTable: "SpaceName",
                principalColumn: "Id");
        }
    }
}
