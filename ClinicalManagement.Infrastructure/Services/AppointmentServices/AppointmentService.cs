using ClinicalManagement.Application.Abstractions.Services.AppointmentServices;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.AppointmentDtos;
using ClinicalManagement.Domain.Models;
using ClinicalManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Services.AppointmentServices
{
   public  class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext appDbContext;

        public AppointmentService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public  Task<List<Appointment>> GetAppointmentsById(Expression<Func<Appointment, bool>> expression)
        {
            var res =  appDbContext.Appointments.Where(expression).ToList();

            return Task.FromResult(res);
        }
    }
}
