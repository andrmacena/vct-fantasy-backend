using Microsoft.AspNetCore.Mvc;
using VctFantasy.Application.Dtos.Request;
using VctFantasy.Application.Interfaces;

namespace VctFantasy.Controllers
{
    [ApiController]
    [Route("v1/authentication")]
    public class AuthenticationController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly IAuthenticationUseCase _authenticationUseCase;

        public AuthenticationController(ITokenService tokenService, IAuthenticationUseCase authenticationUseCase)
        {
            _tokenService = tokenService;
            _authenticationUseCase = authenticationUseCase;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {

            var user = await _authenticationUseCase.Login(userDto);

            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            var token = _tokenService.GenerateToken(user);

            return Ok(new { token });
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
