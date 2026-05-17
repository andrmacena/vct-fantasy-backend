using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Dtos;
using VctFantasy.Domain.UseCases;

namespace VctFantasy.Controllers
{
    [ApiController]
    [Route("v1/register")]
    public class RegisterController : Controller
    {
        private readonly UserUseCase _registerUserUseCase;
        private readonly TeamUseCase _registerTeamUseCase;
        private readonly OrganizationUseCase _organizationUseCase;
        private readonly PlayerUseCase _playerUseCase;
        public RegisterController(UserUseCase registerUserUseCase, TeamUseCase registerTeamUseCase, OrganizationUseCase organizationUseCase, PlayerUseCase playerUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
            _registerTeamUseCase = registerTeamUseCase;
            _organizationUseCase = organizationUseCase;
            _playerUseCase = playerUseCase;
        }

        [HttpPost]
        [Route("users")]
        public IActionResult RegisterUser([FromBody] UserDto user)
        {

            _registerUserUseCase.RegisterUser(user);

            return Created();
        }

        [HttpPost]
        [Route("teams")]
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

            _registerTeamUseCase.RegisterTeam(team, email);

            return Created();
        }

        [HttpPost]
        [Route("orgs")]
        [Authorize(Roles = "admin")]
        public IActionResult RegisterOrganization([FromBody] List<OrganizationDto> organization)
        {
            _organizationUseCase.RegisterOrganization(organization);
            
            return Created();

        }

        [HttpPost]
        [Route("players")]
        [Authorize(Roles = "admin")]
        public IActionResult RegisterPlayers([FromBody] List<PlayerDto> players)
        {
            _playerUseCase.RegisterPlayer(players);

            return Created();

        }
    }
}

