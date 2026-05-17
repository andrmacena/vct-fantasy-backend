using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using VctFantasy.Domain.Models;
using VctFantasy.Domain.UseCases;
using VctFantasy.Domain.Util;

namespace VctFantasy.Infrastructure.Services
{
    public class TokenService
    {
        private readonly AppSettings _appSettings;

        public TokenService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
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

            // TO DO: Verificar na base de dados se o usuário é admin ou user e adicionar a claim de acordo
            ci.AddClaim(new Claim(ClaimTypes.Role, user.RoleID == (int)Role.RoleType.User ? "user": "admin"));

            return ci;
        }
    }
}
