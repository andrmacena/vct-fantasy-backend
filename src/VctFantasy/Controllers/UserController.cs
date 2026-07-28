using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Npgsql;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Dtos.Request;
using VctFantasy.Domain.Interfaces;
using VctFantasy.Domain.UseCases;
using VctFantasy.Domain.Util;

namespace VctFantasy.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : Controller
    {
        private readonly IUserUseCase _registerUserUseCase;
        private readonly AppSettings _appSettings;
        public UserController(IUserUseCase registerUserUseCase, IOptions<AppSettings> appSettings)
        {
            _registerUserUseCase = registerUserUseCase;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] UserDto user)
        {
            _registerUserUseCase.Register(user);

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

