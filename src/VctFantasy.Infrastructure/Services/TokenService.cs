
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VctFantasy.Domain.Interfaces;
using VctFantasy.Domain.Models;
using VctFantasy.Domain.UseCases;
using VctFantasy.Domain.Util;
using VctFantasy.Infrastructure.Interfaces;

namespace VctFantasy.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserUseCase _userUseCase;

        public TokenService(IOptions<AppSettings> appSettings, IUserUseCase userUseCase)
        {
            _appSettings = appSettings.Value;
            _userUseCase = userUseCase;
        }

        public string GenerateToken(User user)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = credentials,
                Subject = GenerateClaims(user)
            };

            // Gera um Token
            var token = handler.CreateToken(tokenDescriptor);

            // Gera uma string do Token
            var strToken = handler.WriteToken(token);

            return strToken;
        }

        private ClaimsIdentity GenerateClaims(User user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Email, user.Email));


            var userRole = _userUseCase.GetUserRole(user.Id);

            ci.AddClaim(new Claim(ClaimTypes.Role, userRole));

            ci.AddClaim(new Claim(ClaimTypes.Name, user.Nickname));

            return ci;
        }

    }
}
