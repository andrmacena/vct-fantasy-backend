using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Domain.Dtos.Request;
using VctFantasy.Domain.Models;

namespace VctFantasy.Domain.Interfaces
{
    public interface IAuthenticationUseCase
    {
        Task<User> Login(UserDto userDto);
    }
}
