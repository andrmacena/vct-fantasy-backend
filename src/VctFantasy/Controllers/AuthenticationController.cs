using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VctFantasy.Domain.Models;
using VctFantasy.Domain.UseCases;
using VctFantasy.Infrastructure.Services;

namespace VctFantasy.Controllers
{
    [ApiController]
    [Route("v1/authentication")]
    public class AuthenticationController : Controller
    {
        private readonly TokenService _tokenService;
        private readonly AuthenticationUseCase _authenticationUseCase;

        public AuthenticationController(TokenService tokenService, AuthenticationUseCase authenticationUseCase)
        {
            _tokenService = tokenService;
            _authenticationUseCase = authenticationUseCase;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {

            var loginResult = await _authenticationUseCase.Login(user);

            if (loginResult != "Login Successful")
            {
                return Unauthorized("Invalid email or password.");
            }

            var token = _tokenService.GenerateToken(user);

            return Ok(token);
        }
    }
}
