using ClinicalManagement.Domain.Entities;
using ClinicalManagement.Domain.Interfaces;
using ClinicalManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Reposatories
{
    class BaseReposatory<T> : IBaseReposatory<T> where T : class
    {
        private readonly AppDbContext dbContext;

        public BaseReposatory(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
        }

        public async Task<T> GetEntityById(string id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public  Task Remove(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public  Task UpdateAsync(T entity)
        {
             dbContext.Set<T>().Update(entity);
             return Task.CompletedTask;
        }
    }
}
