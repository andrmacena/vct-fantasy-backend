using System;
using System.Collections.Generic;
using System.Text;

namespace VctFantasy.Domain.Dtos.Request
{
    public class PlayerDto
    {
        public string Nickname { get; set; }
        public int OrganizationId { get; set; }
        public string PathProfile { get; set; }
    }
}
