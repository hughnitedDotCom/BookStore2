using BookStore.Domain.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces.Repository
{
    public interface IRepository <T> where T: EntityBase
    {
        Task<T> AddAsync(T entity);

        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(int id);
    }
}
