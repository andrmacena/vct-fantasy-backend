using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Domain.Dtos.Response;

namespace VctFantasy.Domain.Interfaces
{
    public interface ILeaderboard
    {
        public List<LeaderboardDtoResponse> GeneralLeaderboard();
    }
}
