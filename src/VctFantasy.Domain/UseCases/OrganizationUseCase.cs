using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Dtos.Request;
using VctFantasy.Domain.Interfaces;
using VctFantasy.Domain.Models;

namespace VctFantasy.Domain.UseCases
{
    public class OrganizationUseCase: IOrganizationUseCase

    {
        private readonly VctFantasyContext _context;
        public OrganizationUseCase(VctFantasyContext context)
        {
            _context = context;
        }

        public string Consult(OrganizationDto dto)
        {
            throw new NotImplementedException();
        }

        public void Delete(OrganizationDto dto)
        {
            throw new NotImplementedException();
        }

        public string Register(List<OrganizationDto> organization)
        {
            try
            {
                foreach (var org in organization)
                {
                    var organizationEntity = new Organization
                    {
                        Name = org.Name,
                        Abbreviation = org.Abbreviation,
                        PathLogoOrg = org.PathLogoOrg
                    };

                    _context.Organizations.Add(organizationEntity);
                }
                _context.SaveChanges();

                return "Organizações registradas com sucesso!";
            }
            catch (Exception ex)
            {

                return "An error occurred while registering organizations: " + ex.Message;
            }
        }

        public string Register(OrganizationDto dto)
        {
            throw new NotImplementedException();
        }

        public string Update(OrganizationDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
