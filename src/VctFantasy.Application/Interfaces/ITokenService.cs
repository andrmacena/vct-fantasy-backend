using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using VctFantasy.Domain.Models;

namespace VctFantasy.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
