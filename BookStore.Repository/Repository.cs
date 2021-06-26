using BookStore.Domain.Interfaces.Repository;
using BookStore.Services.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    /// <summary>
    /// Generic Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        public Repository()
        {

        }

        public async Task<T> AddAsync(T entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
