using System;
using System.Collections.Generic;
using System.Text;

namespace VctFantasy.Application.Interfaces
{
    public interface IPasswordHasherService
    {
        string GenerateHash(string password, string salt);
        string GenerateSalt();
    }
}
