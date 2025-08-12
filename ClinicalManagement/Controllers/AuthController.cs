using ClinicalManagement.Application.Auth.Login;
using ClinicalManagement.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("login")]
        public async Task<IActionResult> Login(string nameOrEmail,string password)
        {
            var res =await mediator.Send(new LoginCommand { Password = password, UserName = nameOrEmail });
            return this.HandleResult(res);
        }
    }
}
