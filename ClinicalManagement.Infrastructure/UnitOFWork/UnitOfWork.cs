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
        private readonly Dictionary<Type, object> _repositories;

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            _repositories = new Dictionary<Type, object>();

        }
        public IBaseReposatory<T> Repository<T>() where T : class
        {
            var type = typeof(T);

            if (!_repositories.ContainsKey(type))
            {
                var repositoryInstance = new BaseReposatory<T>(appDbContext);
                _repositories.Add(type, repositoryInstance);
            }

            return (IBaseReposatory<T>)_repositories[type];
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
