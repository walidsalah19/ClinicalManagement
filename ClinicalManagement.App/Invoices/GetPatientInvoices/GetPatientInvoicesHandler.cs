using AutoMapper;
using ClinicalManagement.Application.Abstractions.DbContext;
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
    public class GetPatientInvoicesHandler :IRequestHandler<GetPatientInvoicesQuery,Result<List<InvoiceDto>>>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        public GetPatientInvoicesHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        Task<Result<List<InvoiceDto>>> IRequestHandler<GetPatientInvoicesQuery, Result<List<InvoiceDto>>>.Handle(GetPatientInvoicesQuery request, CancellationToken cancellationToken)
        {
            var invoices = appDbContext.Invoices.Where(x => x.PatientId.Equals(request.patientId)).ToList();
            var dto = mapper.Map<List<InvoiceDto>>(invoices);

            return Task.FromResult(Result<List<InvoiceDto>>.Success(dto));
        }
    }
}
