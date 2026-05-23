using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Domain.Models;

namespace VctFantasy.Domain.Dtos.Response
{
    public class PlayerDtoResponse
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string PathProfile { get; set; }
        public decimal Rating { get; set; } = 0;
        public int Acs { get; set; } = 0;
        public int Kills { get; set; } = 0;
        public int Deaths { get; set; } = 0;
        public int Assists { get; set; } = 0;
        public int Kast { get; set; } = 0;
        public int Adr { get; set; } = 0;
        public int Fb { get; set; } = 0;
        public int Fd { get; set; } = 0;
        public decimal Score { get; set; } = 0;
        public int OrganizationId { get; set; }
    }
}
