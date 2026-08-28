using System.Security.Cryptography;
using System.Text;
using VctFantasy.Application.Interfaces;

namespace VctFantasy.Application.Services
{
    public class PasswordHasherService: IPasswordHasherService
    {
        public string GenerateHash(string password, string salt)
        {
            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password),
                            Encoding.UTF8.GetBytes(salt),
                            350000, 
                            HashAlgorithmName.SHA512,
                            64); 

            var hashedStr = Convert.ToBase64String(hash);

            return hashedStr;
        }

        public string GenerateSalt()
        {
            var rng = RandomNumberGenerator.Create();

            byte[] salt = new byte[64];

            rng.GetBytes(salt);

            string cryptSalt = Convert.ToBase64String(salt);

            return cryptSalt;
        }
    }
}
