using ClinicalManagement.Application.Abstractions.DbContext;
using ClinicalManagement.Application.Abstractions.GenerateInvoicePdf;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Reports.PdfReport
{
    public class PdfReportHandler : IRequestHandler<PdfReportQuery, byte[]>
    {

        private readonly IAppDbContext appDbContext;
        private readonly IGenerateInvoicePdfServices services;

        public PdfReportHandler(IAppDbContext appDbContext, IGenerateInvoicePdfServices services)
        {
            this.appDbContext = appDbContext;
            this.services = services;
        }

        Task<byte[]> IRequestHandler<PdfReportQuery, byte[]>.Handle(PdfReportQuery request, CancellationToken cancellationToken)
        {
            var query = appDbContext.Appointments.Include(x=>x.Doctor).Include(x=>x.Patient)
           .Where(a => a.AppointmentDate >= request.From && a.AppointmentDate <= request.To).ToList();
            var res = services.GenerateInvoice("124");
           
            return Task.FromResult(res);
        }
       
    }
}
