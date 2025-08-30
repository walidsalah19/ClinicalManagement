using ClinicalManagement.Domain.Interfaces;
using ClinicalManagement.Domain.Models;
using ClinicalManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Reposatories
{
    public class NotificationRepo : BaseReposatory<Notification>, INotificationRepo
    {
        public NotificationRepo(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
