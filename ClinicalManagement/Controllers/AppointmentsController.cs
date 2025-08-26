using ClinicalManagement.Application.Appointments.AddAppointment;
using ClinicalManagement.Application.Dtos.AppointmentDtos;
using ClinicalManagement.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClinicalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AppointmentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointment appointment)
        {
            var res = await mediator.Send(new CreateAppointmentComand { appointment=appointment});

            return this.HandleResult(res);
        }
    }
}
