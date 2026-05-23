using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Dtos.Request;
using VctFantasy.Domain.UseCases;
using VctFantasy.Domain.Util;

namespace VctFantasy.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : Controller
    {
        private readonly UserUseCase _registerUserUseCase;
        private readonly AppSettings _appSettings;
        public UserController(UserUseCase registerUserUseCase, IOptions<AppSettings> appSettings)
        {
            _registerUserUseCase = registerUserUseCase;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] UserDto user)
        {
            _registerUserUseCase.RegisterUser(user);

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

