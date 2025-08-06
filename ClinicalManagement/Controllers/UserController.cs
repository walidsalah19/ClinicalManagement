using ClinicalManagement.Application.Dtos.UserDtos;
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

        [HttpPost("Patient")]
        public async Task<IActionResult> CreatePatient([FromBody] CreateUserDto user)
        {
           var res=await mediator.Send(new CreateUserCommand { userDto=user});
            return  Ok(res);
        }

       /* [HttpPost("Admin")]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateUserCommand user)
        {
            var res = await mediator.Send(user);
            return Ok(res);
        }*/
    }
}
