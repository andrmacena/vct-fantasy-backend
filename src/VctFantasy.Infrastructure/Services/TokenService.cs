using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VctFantasy.Domain.Models;
using VctFantasy.Domain.UseCases;

namespace VctFantasy.Infrastructure.Services
{
    public class TokenService
    {
        private const string SecretKey = "secretkey";
        private readonly AuthenticationUseCase _authenticationUseCase;

        public TokenService(AuthenticationUseCase authenticationUseCase)
        {
            _authenticationUseCase = authenticationUseCase;
        }

        public string GenerateToken(User user)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(SecretKey);

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

            ci.AddClaim(new Claim(ClaimTypes.Role, user.RoleID == 2 ? "user": ""));

            return ci;
        }
    }
}
