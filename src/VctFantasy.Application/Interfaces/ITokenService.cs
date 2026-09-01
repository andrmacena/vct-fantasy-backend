using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using VctFantasy.Application.Dtos.Response;
using VctFantasy.Application.Services;
using VctFantasy.Domain.Models;

namespace VctFantasy.Application.Interfaces
{
    public interface ITokenService
    {
        BaseResponse<TokenDtoResponse> GenerateToken(User user);
    }
}
