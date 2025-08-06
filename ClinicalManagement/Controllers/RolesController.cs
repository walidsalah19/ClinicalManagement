using ClinicalManagement.Application.Common.Result;
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
        [HttpGet("Roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles =await mediator.Send(new GetAllRoles());
            return HandleResult(roles);

        }
        [HttpPost("Role")]
        public async Task<IActionResult> CreateRole(CreateRoleCommand createRole)
        {
            var res = await mediator.Send(createRole);
         return HandleResult(res);

        }
        [HttpDelete("Role")]
        public async Task<IActionResult> DeleteRole(DeleteRoleCommand role)
        {
            var res = await mediator.Send(role);
            return HandleResult(res);
        }
        [HttpPut("Role")]
        public async Task<IActionResult> UpdateRole(UpdateRoleCommand role)
        {
            var res = await mediator.Send(role);
            return HandleResult(res);
        }




        public IActionResult HandleResult<T>(Result<T> result)
        {
            

            if (!result.isSuccessed)
                return BadRequest(result);
            else if (result ==null)
                return NotFound();
            return Ok(result);
        } 
    }
}
