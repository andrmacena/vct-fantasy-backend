using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Models;
using VctFantasy.Domain.UseCases;

namespace VctFantasy.Controllers
{
    [ApiController]
    [Route("v1/register")]
    public class RegisterController : Controller
    {
        private readonly RegisterUserUseCase _registerUserUseCase;
        public RegisterController(RegisterUserUseCase registerUserUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
        }

        [HttpPost]
        [Route("users")]
        public IActionResult RegisterUser([FromBody] User user)
        {
            
            _registerUserUseCase.RegisterUser(user);

            return Created();
        }

        [HttpGet]
        [Route("teams")]
        [Authorize(Roles = "user")]
        public IActionResult AllUsers()
        {

            return Ok(new User() { Id = 1, Email = "teste@gmail", CreatedAt = DateTime.UtcNow, Roles = new List<Role> { new Role { Id = 1, Name = "admin" } } });
        }
    }
}
