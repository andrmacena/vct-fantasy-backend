using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Domain.Dtos.Request;
using VctFantasy.Domain.Dtos.Response;

namespace VctFantasy.Domain.Interfaces
{
    public interface IOrganizationUseCase
    {
        string Register(List<OrganizationDto> dto);
        string Register(OrganizationDto dto);
        string Update(int id);
        List<OrganizationDtoResponse> GetAll();
        void Delete(int id);
    }
}
