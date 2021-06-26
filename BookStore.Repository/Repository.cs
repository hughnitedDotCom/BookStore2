using BookStore.Domain.Interfaces.Repository;
using BookStore.Services.Entities.Base;
using Microsoft.EntityFrameworkCore;
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
        //const string dbName = "BookStore.db";

        private BookStoreContext _dbContext;

        public Repository()
        {
            if(_dbContext == null)
            {
                _dbContext = new BookStoreContext();
                _dbContext.Database.EnsureCreatedAsync();
            }
        }           

        public async Task<int> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _dbContext.Set<T>().FindAsync(id);

            return result;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            return await _dbContext.SaveChangesAsync();
        }
    }
}
