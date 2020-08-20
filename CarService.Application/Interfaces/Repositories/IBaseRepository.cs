using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.Application.Interfaces.Repositories
{
    public interface IBaseRepositoryAsync<T>where T : class
    {
        Task<T> GetByIdAsync(int id);
        //Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
