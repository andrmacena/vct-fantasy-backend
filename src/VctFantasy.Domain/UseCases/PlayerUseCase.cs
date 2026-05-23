using VctFantasy.Domain.Context;
using VctFantasy.Domain.Dtos.Request;
using VctFantasy.Domain.Dtos.Response;
using VctFantasy.Domain.Models;

namespace VctFantasy.Domain.UseCases
{
    public class PlayerUseCase
    {
        private readonly VctFantasyContext _context;
        public PlayerUseCase(VctFantasyContext context)
        {
            _context = context;
        }

        public string RegisterPlayer(List<PlayerDto> players)
        {
            try
            {
                foreach (var player in players)
                {
                    var playerEntity = new Player
                    {
                        Nickname = player.Nickname,
                        OrganizationId = player.OrganizationId,
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

        public List<PlayerDtoResponse> GetPlayers()
        {
            var players = _context.Players.ToList();

            var playerResponse = new List<PlayerDtoResponse>();
            
            foreach (var player in players) {
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

    }
}
