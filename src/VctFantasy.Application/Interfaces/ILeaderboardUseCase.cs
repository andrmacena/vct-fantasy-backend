using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Application.Dtos.Response;

namespace VctFantasy.Application.Interfaces
{
    public interface ILeaderboardUseCase
    {
        public BaseResponse<LeaderboardDtoResponse> GeneralLeaderboard();
    }
}
