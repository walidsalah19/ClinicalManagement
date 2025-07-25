using ClinicalManagement.Application.Roles.Commands;
using ClinicalManagement.Application.Roles.Quires;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClinicalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly IMediator mediator;

        public RolesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("AllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles =await mediator.Send(new GetAllRoles());
            return Ok(roles);
        }
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleCommand createRole)
        {
            var res = await mediator.Send(createRole);
            return Ok(res);
        }
    }
}
