using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Dtos.Response;
using VctFantasy.Domain.Interfaces;

namespace VctFantasy.Domain.UseCases
{
    public class LeaderboardUseCase: ILeaderboard
    {
        private readonly VctFantasyContext _context;
        public LeaderboardUseCase(VctFantasyContext context)
        {
            _context = context;
        }
        public List<LeaderboardDtoResponse> GeneralLeaderboard()
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

            return leaderboard;
        }
    }
}
