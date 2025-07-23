using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Domain.Interfaces
{
    public interface IBaseReposatory<T> where T:class
    {
        Task AddAsync(T entity);
        Task Remove(T entity);

        Task UpdateAsync(T entity);

        Task<T> GetEntityById(String id);
    }
}
