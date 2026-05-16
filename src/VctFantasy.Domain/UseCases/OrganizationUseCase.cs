using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Domain.Context;
using VctFantasy.Domain.Dtos;
using VctFantasy.Domain.Models;

namespace VctFantasy.Domain.UseCases
{
    public class OrganizationUseCase
    {
        private readonly VctFantasyContext _context;
        public OrganizationUseCase(VctFantasyContext context)
        {
            _context = context;
        }

        public string RegisterOrganization(List<OrganizationDto> organization)
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
    }
}
