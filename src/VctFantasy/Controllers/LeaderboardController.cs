using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VctFantasy.Application.Interfaces;

namespace VctFantasy.Controllers
{
    [Route("v1/leaderboard")]
    public class LeaderboardController : Controller
    {
        private readonly ILeaderboardUseCase _registerLeaderboardUseCase;
        public LeaderboardController(ILeaderboardUseCase registerLeaderboardUseCase)
        {
            _registerLeaderboardUseCase = registerLeaderboardUseCase;
        }

        [HttpGet]
        [Authorize(Roles = "user")]
        public IActionResult Leaderboard()
        {
            var retorno = _registerLeaderboardUseCase.GeneralLeaderboard();

            return Ok(retorno);
        }
    }
}
