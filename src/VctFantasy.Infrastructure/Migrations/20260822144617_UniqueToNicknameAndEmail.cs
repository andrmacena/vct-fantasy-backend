using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VctFantasy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UniqueToNicknameAndEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_Email_Nickname",
                table: "Users",
                columns: new[] { "Email", "Nickname" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email_Nickname",
                table: "Users");
        }
    }
}
