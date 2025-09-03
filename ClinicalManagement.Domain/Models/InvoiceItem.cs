using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Domain.Models
{
   public class InvoiceItem
    {
        public Guid Id { get; set; } 

        public string ServiceName { get; set; }
        public string DoctorName { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }

        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; }  
    }
}
