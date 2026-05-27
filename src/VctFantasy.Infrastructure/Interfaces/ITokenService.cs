using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using VctFantasy.Domain.Models;

namespace VctFantasy.Infrastructure.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
