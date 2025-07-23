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

        [HttpPost("Pationt")]
        public IActionResult CreatePatient([FromBody] CreateUserCommand user)
        {
           var res= mediator.Send(user);
            return Ok(res);
        }
    }
}
