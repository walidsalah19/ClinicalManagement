using ClinicalManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Abstractions.GenerateReport
{
    public  interface IGenerateReport
    {
         byte[] GenerateAppointmentsPdf(List<Appointment> data, DateTime from, DateTime to, string? doctor = null);
    }
}
