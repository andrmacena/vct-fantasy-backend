using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VctFantasy.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddPropToPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathProfile",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathProfile",
                table: "Players");
        }
    }
}
