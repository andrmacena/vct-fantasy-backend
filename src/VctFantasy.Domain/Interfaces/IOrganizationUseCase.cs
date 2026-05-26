using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Domain.Dtos.Request;

namespace VctFantasy.Domain.Interfaces
{
    public interface IOrganizationUseCase
    {
        public string Register(List<OrganizationDto> dto);
        public string Register(OrganizationDto dto);
        public string Update(OrganizationDto dto);
        public string Consult(OrganizationDto dto);
        public void Delete(OrganizationDto  dto);
    }
}
