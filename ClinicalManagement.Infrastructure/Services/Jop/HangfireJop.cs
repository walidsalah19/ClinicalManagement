using ClinicalManagement.Application.Abstractions.Jop;
using ClinicalManagement.Application.Abstractions.SignalR;
using ClinicalManagement.Domain.Models;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Services.Jop
{
    class HangfireJop : IhangfireJop
    {
        private readonly ISignalrServices signalrServices;

        public HangfireJop(ISignalrServices signalrServices)
        {
            this.signalrServices = signalrServices;
        }

        public void CreateScheduleJop(string userId,DateTime date)
        {
            var scheduleTime =date.AddDays(-1);
            var jopTime = new DateTimeOffset(date);
            var res = BackgroundJob.Schedule(() =>signalrServices.SendMessageToUserAsync(userId, "Your reservation is scheduled for 24 hours from now."), jopTime);
        }
    }
}
