using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Application.Dtos.Request;
using VctFantasy.Domain.Models;

namespace VctFantasy.Application.Interfaces
{
    public interface IAuthenticationUseCase
    {
        Task<User> Login(UserDto userDto);
    }
}
