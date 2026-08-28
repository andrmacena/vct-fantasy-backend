using Microsoft.AspNetCore.Mvc;
using VctFantasy.Application.Interfaces;

namespace VctFantasy.Controllers
{
    [Route("v1/leaderboard")]
    public class LeaderboardController : Controller
    {
        private readonly ILeaderboard _registerLeaderboardUseCase;
        public LeaderboardController(ILeaderboard registerLeaderboardUseCase)
        {
            _registerLeaderboardUseCase = registerLeaderboardUseCase;
        }

        [HttpGet]
        public IActionResult Leaderboard()
        {
            var retorno = _registerLeaderboardUseCase.GeneralLeaderboard();

            return Ok(new { data = retorno });
        }
    }
}
