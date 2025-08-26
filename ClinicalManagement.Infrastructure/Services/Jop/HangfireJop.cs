using ClinicalManagement.Application.Abstractions.Jop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Services.Jop
{
    class HangfireJop : IhangfireJop
    {
        public Task CreateScheduleJop()
        {
            return null;
        }
    }
}
