using ClinicalManagement.Application.Reports.PdfReport;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClinicalManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ReportsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GeneratePdfReport([FromQuery] PdfReportQuery query)
        {
            var pdf = await mediator.Send(query);

            return File(pdf, "application/pdf", "AppointmentsReport.pdf");
        }
    }
}
