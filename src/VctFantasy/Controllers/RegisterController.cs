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
        private readonly RegisterUserUseCase _registerUserUseCase;
        private readonly RegisterTeamUseCase _registerTeamUseCase;
        public RegisterController(RegisterUserUseCase registerUserUseCase, RegisterTeamUseCase registerTeamUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
            _registerTeamUseCase = registerTeamUseCase;
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

    }
}
