using BookStore.Domain.Interfaces.Repository;
using BookStore.Services.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BookStore.Repository
{
    /// <summary>
    /// Generic Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private BookStoreContext _dbContext;

        public Repository()
        {
            if(_dbContext == null)
            {
                _dbContext = new BookStoreContext();
                _dbContext.Database.EnsureCreatedAsync();
            }
        }           

        public async Task<T> AddAsync(T entity)
        {
            entity.CreateDate = DateTime.Now;

            var book = _dbContext.Set<T>().Add(entity);

            await _dbContext.SaveChangesAsync();

            return book.Entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>()
                                   .Where(e => e.IsDeleted == false)
                                   .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _dbContext.Set<T>()
                                         .FindAsync(id);

            return !result.IsDeleted ? result : null;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            entity.UpdateDate = DateTime.Now;

            _dbContext.Set<T>().Update(entity);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            entity.IsDeleted = true;

            return await UpdateAsync(entity);
        }
    }
}
