using System;
using System.Collections.Generic;
using System.Text;

namespace VctFantasy.Domain.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PathLogoTeam { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public User User { get; set; }
        public int UserID { get; set; }
        public List<Player> Players { get; set; }
    }
}
