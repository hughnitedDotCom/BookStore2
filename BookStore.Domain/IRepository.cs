using BookStore.Services.Entities.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces.Repository
{
    public interface IRepository <T> where T: BaseEntity
    {
        Task<int> AddAsync(T entity);

        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task<int> UpdateAsync(T entity);

        Task<int> DeleteAsync(T entity);
    }
}
