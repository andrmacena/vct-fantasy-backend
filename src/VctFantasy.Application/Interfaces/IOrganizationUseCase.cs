using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Application.Dtos.Request;
using VctFantasy.Application.Dtos.Response;

namespace VctFantasy.Application.Interfaces
{
    public interface IOrganizationUseCase
    {
        string Register(List<OrganizationDto> dto);
        string Register(OrganizationDto dto);
        string Update(int id);
        BaseResponse<OrganizationDtoResponse> GetAll();
        void Delete(int id);
    }
}
