using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VctFantasy.Domain.Dtos.Request;
using VctFantasy.Domain.UseCases;

namespace VctFantasy.Controllers
{
    [ApiController]
    [Route("v1/organizations")]
    public class OrganizationsController : Controller
    {
        private readonly OrganizationUseCase _organizationUseCase;
        public OrganizationsController(OrganizationUseCase organizationUseCase)
        {
            _organizationUseCase = organizationUseCase;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult RegisterOrganization([FromBody] List<OrganizationDto> organization)
        {
            _organizationUseCase.RegisterOrganization(organization);

            return Created();

        }
    }
}
