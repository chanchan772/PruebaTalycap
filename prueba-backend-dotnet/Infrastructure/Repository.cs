using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalycapGlobalNet.Core;

namespace TalycapGlobalNet.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TalycapGlobalNetDbContext _context;
        protected readonly DbSet<T> _entities;

        public Repository(TalycapGlobalNetDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }
    }
}