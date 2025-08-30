using ClinicalManagement.Domain.Interfaces;
using ClinicalManagement.Infrastructure.Data;
using ClinicalManagement.Infrastructure.Reposatories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.UnitOFWork
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;
        public IAppoointmentsRepo appoointmentsRepo { get; set; }
        public INotificationRepo notificationRepo { get; set; }

        public UnitOfWork(AppDbContext appDbContext, IAppoointmentsRepo appoointmentsRepo, INotificationRepo notificationRepo)
        {
            this.appDbContext = appDbContext;
            this.appoointmentsRepo = appoointmentsRepo;
            this.notificationRepo = notificationRepo;
        }

        public async Task<int> Complete()
        {
            return await appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            appDbContext.Dispose();
        }
    }
}
