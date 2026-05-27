using Microsoft.AspNetCore.Mvc;
using VctFantasy.Domain.Dtos.Request;
using VctFantasy.Domain.Interfaces;
using VctFantasy.Domain.UseCases;
using VctFantasy.Infrastructure.Services;

namespace VctFantasy.Controllers
{
    [ApiController]
    [Route("v1/authentication")]
    public class AuthenticationController : Controller
    {
        private readonly TokenService _tokenService;
        private readonly IAuthenticationUseCase _authenticationUseCase;

        public AuthenticationController(TokenService tokenService, IAuthenticationUseCase authenticationUseCase)
        {
            _tokenService = tokenService;
            _authenticationUseCase = authenticationUseCase;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserDto user)
        {

            var loginResult = await _authenticationUseCase.Login(user);

            if (loginResult == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            var token = _tokenService.GenerateToken(loginResult);

            return Ok(token);
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            // Implementation for logout if needed
            return Ok();
        }
    }
}
