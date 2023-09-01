using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Ineterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories
{
    public class GenaricRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly ILogger logger;
        protected ApplicationDbContext context;
        internal DbSet<T> _dbSet;

        public GenaricRepository(ILogger logger, ApplicationDbContext context)
        {
            this.logger = logger;
            this.context = context;
            this._dbSet=context.Set<T>();
        }

        public async Task<bool> AddAsync(T entity)
        {
            await this._dbSet.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual  Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }

}
