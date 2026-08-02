using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VctFantasy.Domain.Dtos.Request;
using VctFantasy.Domain.Dtos.Response;
using VctFantasy.Domain.Interfaces;
using VctFantasy.Domain.Models;
using VctFantasy.Domain.UseCases;

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
        [Route("{id}")]
        public ActionResult<TeamDtoResponse> GetTeams([FromRoute] int id)
        {
            var teams = _teamUseCase.GetById(id);

            return Ok(teams);
        }
    }
}
