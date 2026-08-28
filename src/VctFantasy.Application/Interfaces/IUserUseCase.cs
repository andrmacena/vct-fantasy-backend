using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Application.Dtos.Request;

namespace VctFantasy.Application.Interfaces
{
    public interface IUserUseCase
    {
        string Register(UserDto userDto);
        string GetUserRole(int userId);
    }
}
