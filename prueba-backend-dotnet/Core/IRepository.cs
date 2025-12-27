using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalycapGlobalNet.Core
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}