using ClinicalManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Abstractions.Caching
{
    public interface ICachingServices
    {
        Task<bool> AcquireLockAsync(Appointment appointment,string key);
        Task ReleaseLockAsync(string key);
        DateTime NormalizeToSlot(DateTime utcDateTime, int minutes = 15);

    }
}
