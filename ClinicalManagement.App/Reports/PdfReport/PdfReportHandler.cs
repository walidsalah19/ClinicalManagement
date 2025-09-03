using ClinicalManagement.Application.Abstractions.DbContext;
using ClinicalManagement.Application.Abstractions.GenerateReport;
using ClinicalManagement.Application.Common.Result;
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
        private readonly IGenerateReport generateReport;

        public PdfReportHandler(IAppDbContext appDbContext, IGenerateReport generateReport)
        {
            this.appDbContext = appDbContext;
            this.generateReport = generateReport;
        }

        Task<byte[]> IRequestHandler<PdfReportQuery, byte[]>.Handle(PdfReportQuery request, CancellationToken cancellationToken)
        {
            var query = appDbContext.Appointments.Include(x=>x.Doctor).Include(x=>x.Patient)
           .Where(a => a.AppointmentDate >= request.From && a.AppointmentDate <= request.To).ToList();


            return Task.FromResult (generateReport.GenerateAppointmentsPdf(query, request.From, request.To));
        }
    }
}
