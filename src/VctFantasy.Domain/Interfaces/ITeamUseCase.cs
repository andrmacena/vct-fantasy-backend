using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Domain.Dtos.Request;
using VctFantasy.Domain.Dtos.Response;

namespace VctFantasy.Domain.Interfaces
{
    public interface ITeamUseCase
    {
        string Register(TeamDto teamDto, string email);
        Task<string> AddPlayerToTeam(int teamId, int playerId);
        TeamDtoResponse GetById(int id);
    }
}
