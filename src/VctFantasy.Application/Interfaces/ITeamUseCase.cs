using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Application.Dtos.Request;
using VctFantasy.Application.Dtos.Response;

namespace VctFantasy.Application.Interfaces
{
    public interface ITeamUseCase
    {
        string Register(TeamDto teamDto, string email);
        Task<string> AddPlayerToTeam(int teamId, int playerId);
        TeamDtoResponse Get(string email);
    }
}
