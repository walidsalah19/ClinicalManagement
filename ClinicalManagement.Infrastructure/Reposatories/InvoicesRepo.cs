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
    public class InvoicesRepo : BaseReposatory<Invoice>, IInvicesRepo
    {
        public InvoicesRepo(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
