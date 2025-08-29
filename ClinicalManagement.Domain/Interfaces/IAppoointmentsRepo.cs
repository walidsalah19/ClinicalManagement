using ClinicalManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Domain.Interfaces
{
    public interface IAppoointmentsRepo : IBaseReposatory<Appointment>
    {
        public Task<bool> CheckIfAppointmentExist(Expression<Func<Appointment, bool>> expression);
    }
}
