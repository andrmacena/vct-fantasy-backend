using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Domain.Models;

namespace VctFantasy.Domain.Dtos.Response
{
    public class TeamDtoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PathLogoTeam { get; set; }
        public List<PlayerDtoResponse> Players { get; set; }
    }
}
