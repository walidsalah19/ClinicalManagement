using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Domain.Interfaces
{
    public interface IUnitOfWork :  IDisposable
    {
        IBaseReposatory<T> Repository<T>() where T : class;
        Task<int> Complete();
    }
}
