using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VctFantasy.Domain.Models;
using VctFantasy.Infrastructure.Services;

namespace VctFantasy.Controllers
{
    [ApiController]
    [Route("v1/authentication")]
    public class AuthenticationController : Controller
    {
        private readonly TokenService _tokenService;

        public AuthenticationController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] User user)
        {

            var token = _tokenService.GenerateToken(user);

            return Ok(token);
        }
    }
}
