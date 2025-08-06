using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeucBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Items",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Items");
        }
    }
}
