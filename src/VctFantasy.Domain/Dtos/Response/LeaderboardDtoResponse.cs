using System;
using System.Collections.Generic;
using System.Text;

namespace VctFantasy.Domain.Dtos.Response
{
    public class LeaderboardDtoResponse
    {
        public string Nickname { get; set; }
        public decimal TotalScore { get; set; }
        public string TeamName { get; set; }
    }
}
