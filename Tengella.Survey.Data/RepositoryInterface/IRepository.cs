using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, bool includeProperties = false, bool tracked = false);
        Task<T?> GetAsync(Expression<Func<T, bool>> filter, bool includeProperties = true, bool tracked = false);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task SaveAsync();

    }
}
