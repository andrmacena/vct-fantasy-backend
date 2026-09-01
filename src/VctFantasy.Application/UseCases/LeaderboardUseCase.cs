using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Infrastructure.Context;
using VctFantasy.Application.Dtos.Response;
using VctFantasy.Application.Interfaces;

namespace VctFantasy.Application.UseCases
{
    public class LeaderboardUseCase : ILeaderboardUseCase
    {
        private readonly VctFantasyContext _context;
        public LeaderboardUseCase(VctFantasyContext context)
        {
            _context = context;
        }
        public BaseResponse<LeaderboardDtoResponse> GeneralLeaderboard()
        {

            var result = _context.Users.Join(_context.Teams, u => u.Id, t => t.UserID, (u, t) => new { User = u, Team = t })
                .Join(_context.PlayerTeams, ut => ut.Team.Id, pt => pt.TeamId, (ut, pt) => new { UserTeam = ut, PlayerTeam = pt })
                .Join(_context.Players, ut => ut.PlayerTeam.PlayerId, p => p.Id, (ut, p) => new { PlayerTeam = ut, Player = p })
                .GroupBy(up => up.PlayerTeam.UserTeam.User.Id)
                .Select(g => new
                {
                    UserId = g.Key,
                    Nickname = g.Select(u => u.PlayerTeam.UserTeam.User.Nickname).FirstOrDefault(),
                    TotalScore = g.Sum(up => up.Player.Score),
                    TeamName = g.Select(u => u.PlayerTeam.UserTeam.Team.Name).FirstOrDefault()
                })
                .OrderByDescending(x => x.TotalScore)
                .ToList();

            var leaderboard = new List<LeaderboardDtoResponse>();

            foreach (var item in result)
            {
                leaderboard.Add(new LeaderboardDtoResponse
                {
                    Nickname = item.Nickname,
                    TotalScore = item.TotalScore,
                    TeamName = item.TeamName
                });

            }

            var ok = BaseResponse<LeaderboardDtoResponse>.OkList(leaderboard, "Leaderboard retrieved successfully");

            return ok;
        }
    }
}
