using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Domain.Dtos.Request;

namespace VctFantasy.Domain.Interfaces
{
    public interface IUserUseCase
    {
        string Register(UserDto userDto);
    }
}
