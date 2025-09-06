using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Dtos.Invoices
{
    public class InvoiceDto
    {
        public string Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public string PaymentMethod { get; set; }
        public string ClinicName { get; set; }
        public string ClinicContact { get; set; }
    }
}
