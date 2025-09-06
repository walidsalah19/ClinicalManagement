using ClinicalManagement.Application.Appointments.AddAppointment;
using ClinicalManagement.Application.Appointments.GetAppointments;
using ClinicalManagement.Application.Appointments.GetAppointmentsByDate;
using ClinicalManagement.Application.Appointments.UpAppointmentStatus;
using ClinicalManagement.Application.Dtos.AppointmentDtos;
using ClinicalManagement.Domain.Models;
using ClinicalManagement.Extentions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles ="Patient")]
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointment appointment)
        {
            var res = await mediator.Send(new CreateAppointmentComand { appointment=appointment});

            return this.HandleResult(res);
        }
        [Authorize(Roles = "Patient")]

        [HttpGet()]
        public async Task<IActionResult> GetPatientAppointment([FromQuery] GetApplointmentsQuery data)
        {
            var res = await mediator.Send(data);

            return this.HandleResult(res);
        }
        [Authorize(Roles = "Patient,Doctor")]
        [HttpGet("ByDate")]
        public async Task<IActionResult> GetByDateAppointment([FromQuery] GetAppointmentsByDateQuery data)
        {
            var res = await mediator.Send(data);

            return this.HandleResult(res);
        }
        [Authorize(Roles = "Patient,Doctor")]
        [HttpPut("Status")]
        public async Task<IActionResult> UpdateAppointmentStatus( UpdateAppointmentStatus data)
        {
            var res = await mediator.Send(new UpdateAppointmentStatusCommand { status = data });

            return this.HandleResult(res);
        }
    }
}
