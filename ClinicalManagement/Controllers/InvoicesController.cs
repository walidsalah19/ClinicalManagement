using ClinicalManagement.Application.Invoices.GetPatientInvoices;
using ClinicalManagement.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClinicalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("PatientInvoices")]
        public async Task<IActionResult> GetPatientInvoices([FromQuery] string patintId)
        {
            var res =await _mediator.Send(new GetPatientInvoicesQuery { patientId = patintId });

            return this.HandleResult(res);
        }
    }
}
