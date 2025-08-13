using ClinicalManagement.Application.Auth.Login;
using ClinicalManagement.Application.Auth.Logout;
using ClinicalManagement.Application.Auth.RefreshToken;
using ClinicalManagement.Extentions;
using ClinicalManagement.Infrastructure.Migrations;
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
        [HttpPost("login")]
        public async Task<IActionResult> Login(string nameOrEmail,string password)
        {
            var res =await mediator.Send(new LoginCommand { Password = password, UserName = nameOrEmail });
            return this.HandleResult(res);
        }
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
            var res = await mediator.Send(new RefreshTokenCommand { RefreshToken=refreshToken});
            return this.HandleResult(res);
        }
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(string userId)
        {
            var res = await mediator.Send(new LogoutCommand { userId = userId });
            return this.HandleResult(res);
        }
    }
}
