using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Dtos.Request;
using VctFantasy.Domain.Interfaces;
using VctFantasy.Domain.Models;

namespace VctFantasy.Domain.UseCases
{
    public class AuthenticationUseCase: IAuthenticationUseCase
    {
        private readonly VctFantasyContext _context;
        public AuthenticationUseCase(VctFantasyContext vctFantasyContext)
        {
            _context = vctFantasyContext;
        }

        public async Task<User> Login(UserDto userDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);

            if (existingUser == null)
            {
                return existingUser;
            }

            var passwordHash = Rfc2898DeriveBytes.Pbkdf2(userDto.Password,
                                Encoding.UTF8.GetBytes(existingUser.PasswordSalt),
                                350000, // Iterations
                                HashAlgorithmName.SHA512,  // Algorithm
                                64); // keysize

            bool compareResult = CryptographicOperations.FixedTimeEquals(passwordHash, Convert.FromBase64String(existingUser.PasswordHash));

            if (!compareResult)
            {
                return null;
            }

            return existingUser;
        }

    }
}
