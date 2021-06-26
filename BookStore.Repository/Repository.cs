using BookStore.Domain.Interfaces.Repository;
using BookStore.Services.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace BookStore.Repository
{
    /// <summary>
    /// Generic Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        readonly BookStoreContext _dbContext;

        public Repository()
        {
            if(_dbContext == null)
            {
                _dbContext = new BookStoreContext();
                _dbContext.Database.EnsureCreatedAsync();

                //context remembers eager loads for future calls
                _dbContext.Users
                          .Include(s => s.Subscriptions)
                          .ThenInclude(b => b.Book)
                          .ToList();
            }
        }           

        public async Task<T> AddAsync(T entity)
        {
            entity.CreateDate = DateTime.Now;

            var book = _dbContext.Set<T>().Add(entity);

            await _dbContext.SaveChangesAsync();

            return book.Entity;
        }

        public async Task<List<T>> AddRangeAsync(List<T> entities)
        {
            entities.ForEach(e => e.CreateDate = DateTime.Now);

            await _dbContext.Set<T>().AddRangeAsync(entities);

            var result = await _dbContext.SaveChangesAsync();

            return entities;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>()
                             .Where(e => e.IsDeleted == false)
                             .AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _dbContext.Set<T>()
                                         .FindAsync(id);

            var re = result != null ? (!result.IsDeleted ? result : null) : null;

            return re;
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
