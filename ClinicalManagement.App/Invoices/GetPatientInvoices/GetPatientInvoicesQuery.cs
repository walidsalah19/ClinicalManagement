using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.Invoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Invoices.GetPatientInvoices
{
   public class GetPatientInvoicesQuery : IRequest<Result<List<InvoiceDto>>>
    {
        public string patientId { get; set; }
    }
}
