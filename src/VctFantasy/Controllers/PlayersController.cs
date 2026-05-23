using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VctFantasy.Domain.Dtos.Request;
using VctFantasy.Domain.UseCases;

namespace VctFantasy.Controllers
{
    [ApiController]
    [Route("v1/players")]
    public class PlayersController : Controller
    {
        private readonly PlayerUseCase _playerUseCase;
        public PlayersController(PlayerUseCase playerUseCase)
        {
            _playerUseCase = playerUseCase;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult RegisterPlayers([FromBody] List<PlayerDto> players)
        {
            _playerUseCase.RegisterPlayer(players);

            return Created();

        }

        [HttpGet]
        [Authorize(Roles = "user")]
        public IActionResult GetPlayers()
        {
            var players = _playerUseCase.GetPlayers();

            return Ok(players);
        }
    }
}
