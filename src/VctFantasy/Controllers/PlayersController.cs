using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VctFantasy.Application.Dtos.Request;
using VctFantasy.Application.Interfaces;

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
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _playerUseCase.GetAll();

            return Ok(players);
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdatePlayer(int id, [FromBody] PlayerDto model)
        {
            var result = _playerUseCase.Update(id, model);


            if (result == "Player not found")
                return NotFound();

            return Ok(result);
        }
    }
}
