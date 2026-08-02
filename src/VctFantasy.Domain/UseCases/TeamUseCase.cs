using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Dtos.Request;
using VctFantasy.Domain.Dtos.Response;
using VctFantasy.Domain.Interfaces;
using VctFantasy.Domain.Models;

namespace VctFantasy.Domain.UseCases
{
    public class TeamUseCase: ITeamUseCase
    {
        private readonly VctFantasyContext _context;
        public TeamUseCase(VctFantasyContext context)
        {
            _context = context;
        }

        public string Register(TeamDto teamDto, string email)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == email);

                var team = new Team
                {
                    Name = teamDto.Name,
                    PathLogoTeam = teamDto.PathLogoTeam
                };

                team.UserID = user.Id;

                _context.Teams.Add(team);
                _context.SaveChanges();

                return "Time registrado com sucesso!";

            }
            catch (NpgsqlException ex)
            {
                return ex.Message;
            }

        }

        public async Task<string> AddPlayerToTeam(int teamId, int playerId)
        {
            try
            {
                var playerTeam = new PlayerTeam
                {
                    PlayerId = playerId,
                    TeamId = teamId
                };
                _context.PlayerTeams.Add(playerTeam);
                await _context.SaveChangesAsync();

                return "Player added to team successfully";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public TeamDtoResponse Get(string email)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == email);

                var team = _context.Teams.Include(t => t.Players)
                    .Where(t => t.UserID == user.Id)
                    .FirstOrDefault();

                if (team == null)
                {
                    throw new Exception("Team not found");
                }

                var teamResponse = new TeamDtoResponse()
                {
                    Id = team.Id,
                    Name = team.Name,
                    PathLogoTeam = team.PathLogoTeam,
                    Players = new List<PlayerDtoResponse>()
                };

                foreach (var player in team.Players)
                {
                    teamResponse.Players.Add(new PlayerDtoResponse
                    {
                        Id = player.Id,
                        Nickname = player.Nickname,
                        PathProfile = player.PathProfile,
                        Rating = player.Rating,
                        Acs = player.Acs,
                        Kills = player.Kills,
                        Deaths = player.Deaths,
                        Assists = player.Assists,
                        Kast = player.Kast,
                        Adr = player.Adr,
                        Fb = player.Fb,
                        Fd = player.Fd,
                        Score = player.Score,
                        OrganizationId = player.OrganizationId
                    });
                }

                return teamResponse;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
