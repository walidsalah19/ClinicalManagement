using ClinicalManagement.Application.Abstractions.Services;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.UserDtos.Commands;
using ClinicalManagement.Application.User.AllDoctors;
using ClinicalManagement.Application.User.AllPatients;
using ClinicalManagement.Application.User.CreateAdmin;
using ClinicalManagement.Application.User.CreateDoctor;
using ClinicalManagement.Application.User.CreatePatient;
using ClinicalManagement.Domain.EmailModel;
using ClinicalManagement.Domain.Enums;
using ClinicalManagement.Extentions;
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

        [HttpPost("admin")]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminDto admin)
        {
            var res = await mediator.Send(new CreateAdminCommand { adminDto = admin });
            return this.HandleResult(res);
        }
        [HttpPost("doctor")]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorDto doctor)
        {
            var res = await mediator.Send(new CreateDoctorCommand { CreateDoctor = doctor });
            return this.HandleResult(res);
        }
        [HttpGet("doctors")]
        public async Task<IActionResult> AllDoctors()
        {
            var res = await mediator.Send(new AllDoctorsQuery());
            return this.HandleResult(res);
        }

        [HttpPost("patient")]
        public async Task<IActionResult> CreatePatient([FromBody] CreatePatientDto user)
        {
           var res=await mediator.Send(new CreateUserCommand { userDto=user});
            return this.HandleResult(res);
        }
        [HttpGet("patients")]
        public async Task<IActionResult> AllPatients()
        {
            var res = await mediator.Send(new AllPatientQuery());
            return this.HandleResult(res);
        }
        











    }
}
