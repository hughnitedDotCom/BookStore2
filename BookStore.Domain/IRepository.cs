using BookStore.Services.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces.Repository
{
    public interface IRepository <T> where T: BaseEntity
    {
        Task<T> AddAsync(T entity);

        Task<List<T>> AddRangeAsync(List<T> entities);

        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task<int> UpdateAsync(T entity);

        Task<int> DeleteAsync(T entity);
    }
}
