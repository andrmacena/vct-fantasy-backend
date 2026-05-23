using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VctFantasy.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddReferenceJoinTableTeamPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeam_Players_PlayersId",
                table: "PlayerTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeam_Teams_TeamsId",
                table: "PlayerTeam");

            migrationBuilder.RenameColumn(
                name: "TeamsId",
                table: "PlayerTeam",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "PlayersId",
                table: "PlayerTeam",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTeam_TeamsId",
                table: "PlayerTeam",
                newName: "IX_PlayerTeam_TeamId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeam_Players_PlayerId",
                table: "PlayerTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeam_Teams_TeamId",
                table: "PlayerTeam");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "PlayerTeam",
                newName: "TeamsId");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "PlayerTeam",
                newName: "PlayersId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTeam_TeamId",
                table: "PlayerTeam",
                newName: "IX_PlayerTeam_TeamsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeam_Players_PlayersId",
                table: "PlayerTeam",
                column: "PlayersId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeam_Teams_TeamsId",
                table: "PlayerTeam",
                column: "TeamsId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
