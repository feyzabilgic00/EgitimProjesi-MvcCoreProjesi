using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreApp102.Core.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate);


        //db.product.firstordefault(s=>s.Id==id)

        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        T Update(T entity);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
