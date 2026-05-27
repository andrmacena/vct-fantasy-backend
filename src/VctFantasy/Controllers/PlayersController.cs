using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VctFantasy.Domain.Dtos.Request;
using VctFantasy.Domain.Interfaces;
using VctFantasy.Domain.UseCases;

namespace VctFantasy.Controllers
{
    [ApiController]
    [Route("v1/players")]
    public class PlayersController : Controller
    {
        private readonly IPlayerUseCase _playerUseCase;
        public PlayersController(IPlayerUseCase playerUseCase)
        {
            _playerUseCase = playerUseCase;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult RegisterPlayers([FromBody] List<PlayerDto> players)
        {
            _playerUseCase.Register(players);

            return Created();

        }

        [HttpGet]
        [Authorize(Roles = "user")]
        public IActionResult GetPlayers()
        {
            var players = _playerUseCase.GetAll();

            return Ok(players);
        }
    }
}
