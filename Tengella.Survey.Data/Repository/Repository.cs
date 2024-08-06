using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly SurveyDbContext _surveyDbContext;
        internal DbSet<T> dbSet;

        public Repository(SurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
            dbSet = surveyDbContext.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }
        
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, bool includeProperties = false, bool tracked = false)
        {
            IQueryable<T> query = tracked ? dbSet : dbSet.AsNoTracking();

            if (!includeProperties)
                query = query.IgnoreAutoIncludes();

            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync();
        }
       
        public async Task<T?> GetAsync(Expression<Func<T, bool>> filter, bool includeProperties = true, bool tracked = false)
        {
            IQueryable<T> query = tracked ? dbSet : dbSet.AsNoTracking();

            if (!includeProperties)
            {
                query = query.IgnoreAutoIncludes();
            }
            
            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
        }

        public async Task SaveAsync()
        {
            await _surveyDbContext.SaveChangesAsync();
        }


    }
}
