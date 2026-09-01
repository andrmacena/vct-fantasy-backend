using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VctFantasy.Application.Dtos.Request;
using VctFantasy.Application.Dtos.Response;
using VctFantasy.Application.Interfaces;

namespace VctFantasy.Controllers
{
    [ApiController]
    [Route("v1/teams")]
    public class TeamsController : Controller
    {
        private readonly ITeamUseCase _teamUseCase;
        public TeamsController(ITeamUseCase teamUseCase)
        {
            _teamUseCase = teamUseCase;
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        public IActionResult RegisterTeam([FromBody] TeamDto team)
        {
            string email = string.Empty;

            foreach (var claim in User.Claims)
            {
                if (claim.Type.Contains("email"))
                {
                    email = claim.Value;
                }
            }

            _teamUseCase.Register(team, email);

            return Created();
        }

        [HttpPost]
        [Route("{teamId}/players/{playerId}")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> AddPlayerTeam([FromRoute] int teamId, [FromRoute] int playerId)
        {

            var result = await _teamUseCase.AddPlayerToTeam(teamId, playerId);

            return Created();
        }

        [HttpGet]
        [Authorize(Roles = "user")]
        public IActionResult GetTeam()
        {
            string email = string.Empty;

            foreach (var claim in User.Claims)
            {
                if (claim.Type.Contains("email"))
                {
                    email = claim.Value;
                }
            }

            var response = _teamUseCase.Get(email);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }

    }
}
