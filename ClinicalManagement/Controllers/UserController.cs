using ClinicalManagement.Application.Dtos.UserDtos.Commands;
using ClinicalManagement.Application.User.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace ClinicalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("patient")]
        public async Task<IActionResult> CreatePatient([FromBody] CreatePatient user)
        {
           var res=await mediator.Send(new CreateUserCommand { userDto=user});
            return  Ok(res);
        }

        [HttpPost("admin")]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateAdmin admin)
        {
            var res = await mediator.Send(new CreateAdminCommand { adminDto=admin});
            return Ok(res);
        }
        [HttpPost("doctor")]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctor doctor)
        {
            var res = await mediator.Send(new CreateDoctorCommand { CreateDoctor = doctor });
            return Ok(res);
        }
    }
}
