using Microsoft.EntityFrameworkCore;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Dtos.Request;
using VctFantasy.Domain.Dtos.Response;
using VctFantasy.Domain.Interfaces;
using VctFantasy.Domain.Models;

namespace VctFantasy.Domain.UseCases
{
    public class PlayerUseCase : IPlayerUseCase
    {
        private readonly VctFantasyContext _context;
        public PlayerUseCase(VctFantasyContext context)
        {
            _context = context;
        }

        public string Register(List<PlayerDto> players)
        {
            try
            {
                foreach (var player in players)
                {
                    var playerEntity = new Player
                    {
                        Nickname = player.Nickname,
                        OrganizationId = (int)player.OrganizationId,
                        PathProfile = player.PathProfile,
                    };
                    _context.Players.Add(playerEntity);
                }

                _context.SaveChanges();

                return "Player registered successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<PlayerDtoResponse>> GetAll()
        {
            var players = await _context.Players.ToListAsync();

            var playerResponse = new List<PlayerDtoResponse>();

            foreach (var player in players)
            {
                playerResponse.Add(new PlayerDtoResponse
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

            return playerResponse;
        }

        public async Task<PlayerDtoResponse> GetById(int id)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.Id == id);

            if (player == null)
                return null;

            var result = new PlayerDtoResponse
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
            };

            return result;
        }

        public string Update(int id, PlayerDto dto)
        {
            var player = _context.Players.Where(p => p.Id == id).ExecuteUpdate(p => p
                .SetProperty(p => p.Rating, dto.Rating)
                .SetProperty(p => p.Acs, dto.Acs)
                .SetProperty(p => p.Kills, dto.Kills)
                .SetProperty(p => p.Deaths, dto.Deaths)
                .SetProperty(p => p.Assists, dto.Assists)
                .SetProperty(p => p.Kast, dto.Kast)
                .SetProperty(p => p.Adr, dto.Adr)
                .SetProperty(p => p.Fb, dto.Fb)
                .SetProperty(p => p.Fd, dto.Fd)
                .SetProperty(p => p.Score, CalculateScore(dto)));

            if (player == 0)
                return "Player not found";

            return "Player updated successfully";
        }

        private decimal CalculateScore(PlayerDto dto)
        {
            decimal score = 0m;

            score += dto.Kills * 2.0m;
            score += dto.Assists * 1.2m;
            score += dto.Acs * 0.02m;
            score += dto.Adr * 0.01m;
            score += dto.Rating * 5m;
            score += dto.Kast * 0.05m;
            score += dto.Fb * 2.5m;
            score += dto.Fd * -2.0m;
            score += dto.Deaths * -1.0m;

            return score;
        }
    }
}
