using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Npgsql;
using VctFantasy.Application.Dtos.Request;
using VctFantasy.Application.Interfaces;
using VctFantasy.Domain.Util;

namespace VctFantasy.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : Controller
    {
        private readonly IUserUseCase _registerUserUseCase;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;
        public UserController(IUserUseCase registerUserUseCase, IOptions<AppSettings> appSettings, IEmailService emailService)
        {
            _registerUserUseCase = registerUserUseCase;
            _appSettings = appSettings.Value;
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] UserDto user)
        {
            _registerUserUseCase.Register(user);

            _emailService.SendEmail(user.Email, "Welcome to VctFantasy", "Thank you for registering!");

            return Created();
        }


        [HttpGet]
        [Route("health")]
        public IActionResult Conexao()
        {

            var cmd = new NpgsqlCommand();
            var cs = _appSettings.DefaultConnection;
            NpgsqlConnection conn = null;
            try
            {
                conn = new NpgsqlConnection(cs);
                conn.Open();
                cmd = new NpgsqlCommand("SELECT version()", conn);
                return Ok(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
                return BadRequest(ex.Message);
            }
            finally
            {
                conn?.Close();
                conn?.Dispose();
            }

        }
    }
}

