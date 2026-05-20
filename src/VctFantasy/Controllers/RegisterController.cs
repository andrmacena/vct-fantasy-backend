using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Dtos;
using VctFantasy.Domain.UseCases;
using VctFantasy.Domain.Util;

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
        private readonly AppSettings _appSettings;
        public RegisterController(UserUseCase registerUserUseCase, TeamUseCase registerTeamUseCase, OrganizationUseCase organizationUseCase, PlayerUseCase playerUseCase, IOptions<AppSettings> appSettings)
        {
            _registerUserUseCase = registerUserUseCase;
            _registerTeamUseCase = registerTeamUseCase;
            _organizationUseCase = organizationUseCase;
            _playerUseCase = playerUseCase;
            _appSettings = appSettings.Value;
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

        [HttpGet]
        [Route("health")]
        public IActionResult Conexao()
        {

            var cmd = new SqlCommand();
            var cs = _appSettings.DefaultConnection;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(cs);
                conn.Open();
                cmd = new SqlCommand("SELECT @@VERSION", conn);
                return Ok(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
                throw;
            }
            finally
            {
                conn?.Close();
                conn?.Dispose();
            }
            
        }
    }
}

