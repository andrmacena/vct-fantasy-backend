using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VctFantasy.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSetTeamPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeam_Players_PlayerId",
                table: "PlayerTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeam_Teams_TeamId",
                table: "PlayerTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerTeam",
                table: "PlayerTeam");

            migrationBuilder.RenameTable(
                name: "PlayerTeam",
                newName: "PlayerTeams");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTeam_TeamId",
                table: "PlayerTeams",
                newName: "IX_PlayerTeams_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerTeams",
                table: "PlayerTeams",
                columns: new[] { "PlayerId", "TeamId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeams_Players_PlayerId",
                table: "PlayerTeams",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeams_Teams_TeamId",
                table: "PlayerTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeams_Players_PlayerId",
                table: "PlayerTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeams_Teams_TeamId",
                table: "PlayerTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerTeams",
                table: "PlayerTeams");

            migrationBuilder.RenameTable(
                name: "PlayerTeams",
                newName: "PlayerTeam");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTeams_TeamId",
                table: "PlayerTeam",
                newName: "IX_PlayerTeam_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerTeam",
                table: "PlayerTeam",
                columns: new[] { "PlayerId", "TeamId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeam_Players_PlayerId",
                table: "PlayerTeam",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeam_Teams_TeamId",
                table: "PlayerTeam",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
