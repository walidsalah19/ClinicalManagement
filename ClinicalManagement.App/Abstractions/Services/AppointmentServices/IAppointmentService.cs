using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.AppointmentDtos;
using ClinicalManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Abstractions.Services.AppointmentServices
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAppointmentsById(Expression<Func<Appointment, bool>> expression);
    }
}
