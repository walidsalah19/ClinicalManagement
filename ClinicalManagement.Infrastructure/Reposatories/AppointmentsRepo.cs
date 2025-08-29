using ClinicalManagement.Domain.Interfaces;
using ClinicalManagement.Domain.Models;
using ClinicalManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Reposatories
{
    public class AppointmentsRepo : BaseReposatory<Appointment> ,IAppoointmentsRepo
    {
        private readonly AppDbContext appDbContext;

        public AppointmentsRepo(AppDbContext appDbContext) : base(appDbContext)
        {
          this.appDbContext = appDbContext;
        }

        public async Task<bool> CheckIfAppointmentExist(Expression<Func<Appointment, bool>> expression)
        {
            return await appDbContext.Appointments.AnyAsync(expression);
        }
    }
}
