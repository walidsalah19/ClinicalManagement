using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Abstractions.GenerateInvoicePdf
{
    public interface IGenerateInvoicePdfServices
    {
        public byte[] GenerateInvoice(string id);
    }
}
