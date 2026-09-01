using System;
using System.Collections.Generic;
using System.Text;

namespace VctFantasy.Application.Dtos.Response
{
    public class TokenDtoResponse
    {
        public string? Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
