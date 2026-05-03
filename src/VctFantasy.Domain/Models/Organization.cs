using System;
using System.Collections.Generic;
using System.Text;

namespace VctFantasy.Domain.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string PathLogoOrg{ get; set; }
        public List<Player> Players { get; set; }
    }
}
