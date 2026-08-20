using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace VctFantasy.Domain.Dtos.Request
{
    public class UserDto
    {
        public string Email { get; set; }
        public string? Nickname { get; set; }
        public string Password { get; set; }
    }
}
