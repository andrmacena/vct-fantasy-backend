using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VctFantasy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConstraintToNicknameAndAnotherToEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email_Nickname",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Nickname",
                table: "Users",
                column: "Nickname",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Nickname",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email_Nickname",
                table: "Users",
                columns: new[] { "Email", "Nickname" },
                unique: true);
        }
    }
}
