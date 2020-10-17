using ArticleManager.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ArticleManager.Core.Interfaces.Repositories.Base
{
    public interface IRepository<T, TKey> where T : EntityBase<TKey>
    {
        Task<T> GetByIdAsync(TKey id);
        Task<T> GetByIdAsync(TKey id, string[] includes);
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> ListAllAsync();
        IQueryable<T> GetFiltered(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> ListFiltered(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<T> DeleteAsync(TKey id);
    }
}
