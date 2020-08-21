using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarService.Application.Interfaces.Repositories
{
    public interface IBaseRepositoryAsync<TEntity>where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        //Task<IReadOnlyList<T>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetPagedReponseAsync(int pageNumber, int pageSize);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task SaveAsync();
    }
}
