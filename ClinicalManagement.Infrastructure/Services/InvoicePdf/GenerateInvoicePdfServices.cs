using ClinicalManagement.Application.Abstractions.GenerateInvoicePdf;
using ClinicalManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;

namespace ClinicalManagement.Infrastructure.Services.InvoicePdf
{
    public class GenerateInvoicePdfServices:IGenerateInvoicePdfServices
    {
        public Invoice CreateInvoice()
        {
            return new Invoice
            {
                Id = Guid.NewGuid(),
                InvoiceNumber = "INV-2025-001",
                Date = DateTime.Now,
                Discount = 50m,
                Tax = 100m,
                PaymentMethod = "Cash",
                ClinicName = "Happy Health Clinic",
                ClinicContact = "+20 100 123 4567",

                // الربط مع حجز (Appointment)
                appointmentId = Guid.NewGuid(), // أو id فعلي من قاعدة البيانات
                Appointment = new Appointment
                {
                    Id = Guid.NewGuid(),
                    AppointmentDate = DateTime.Now.AddDays(-1),
                    DoctorId = "Dr. Ahmed Salah",
                    Notes = "Follow-up visit"
                },

                // الربط مع مريض (Patient)
                PatientId = Guid.NewGuid().ToString(),
                patient = new Patient
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Walid Salah",
                    PhoneNumber = "+20 101 555 6666",
                    Email = "walid@example.com"
                },

                // عناصر الفاتورة
                Items = new List<InvoiceItem>
            {
                new InvoiceItem
                {
                    Id = Guid.NewGuid(),
                    ServiceName = "General Checkup",
                    DoctorName = "Dr. Ahmed Salah",
                    Date = DateTime.Now,
                    Price = 300m,
                },
                new InvoiceItem
                {
                    Id = Guid.NewGuid(),
                    ServiceName = "Blood Test",
                    DoctorName = "Dr. Mona Ali",
                    Date = DateTime.Now,
                    Price = 200m,
                }
            }
          };

       }

        public byte[] GenerateInvoice(string id)
        {
            var pdf = new InvoicePDF(CreateInvoice());
            return pdf.GeneratePdf();
        }
    }
}
