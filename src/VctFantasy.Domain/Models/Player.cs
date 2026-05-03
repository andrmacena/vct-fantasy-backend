using System;
using System.Collections.Generic;
using System.Text;

namespace VctFantasy.Domain.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public decimal Rating { get; set; }
        public int Acs { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public int Kast { get; set; }
        public int Adr { get; set; }
        public int Fb { get; set; }
        public int Fd { get; set; }
        public decimal Score { get; set; } = 0;
        public int OrgID { get; set; }
        public Organization Organization { get; set; }
    }
}
