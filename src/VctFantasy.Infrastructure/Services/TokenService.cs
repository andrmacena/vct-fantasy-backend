using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VctFantasy.Domain.Models;

namespace VctFantasy.Infrastructure.Services
{
    public class TokenService
    {
        private const string SecretKey = "secretkey";

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

            foreach (var role in user.Roles)
                ci.AddClaim(new Claim(ClaimTypes.Role, role.Name));

            return ci;
        }
    }
}
