using System;
using System.Collections.Generic;
using System.Text;

namespace VctFantasy.Application.Dtos.Response
{
    public class OrganizationDtoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string PathLogoOrg { get; set; }
    }
}
