using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Domain.Models
{
   public class Invoice
    {
        public Guid Id { get; set; }  
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public string PaymentMethod { get; set; }
        public string ClinicName { get; set; }
        public string ClinicContact { get; set; }
       

        public Guid appointmentId { get; set; }  
        public Appointment Appointment { get; set; }

        public string PatientId { get; set; }
        public Patient patient { get; set; }
        public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    }
}
