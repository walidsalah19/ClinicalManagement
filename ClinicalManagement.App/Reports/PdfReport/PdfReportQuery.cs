using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Reports.PdfReport
{
   public class PdfReportQuery :IRequest<byte[]>
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; } = DateTime.UtcNow;
        public int? DoctorId { get; set; }
    }
}
