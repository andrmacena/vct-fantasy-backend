using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VctFantasy.Application.Dtos.Request;
using VctFantasy.Application.Interfaces;

namespace VctFantasy.Controllers
{
    [ApiController]
    [Route("v1/organizations")]
    public class OrganizationsController : Controller
    {
        private readonly IOrganizationUseCase _organizationUseCase;
        public OrganizationsController(IOrganizationUseCase organizationUseCase)
        {
            _organizationUseCase = organizationUseCase;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult RegisterOrganization([FromBody] List<OrganizationDto> organization)
        {
            _organizationUseCase.Register(organization);

            return Created();

        }
        [HttpGet]
        public IActionResult GetOrganizations()
        {
            // Implementation for getting organizations
            return Ok();
        }
    }
}
