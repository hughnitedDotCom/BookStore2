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

        public Repository(BookStoreContext dbContext)
        {
            _dbContext = dbContext ?? new BookStoreContext();

            EagerLoadNavgationProperties();
        }

        #region Public Methods

        public async Task<T> AddAsync(T entity)
        {
            entity.CreateDate = DateTime.Now;

            var result = _dbContext.Set<T>().Add(entity).Entity;

            await _dbContext.SaveChangesAsync();

            return result;
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
                             .AsQueryable();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> ids)
        {
            var result = await _dbContext.Set<T>()
                                         .Where(ids)
                                         .FirstOrDefaultAsync();

            return result;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            entity.UpdateDate = DateTime.Now;

            _dbContext.Set<T>().Update(entity);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            return await _dbContext.SaveChangesAsync();
        }

        #endregion


        #region Private Methods

        private void EagerLoadNavgationProperties()
        {
            //context remembers eager loads for future calls
            //There is a better approach, design needs to be looked at
            //Too late to refactor
            //Project is small enough for this solution for now
            _dbContext.Users
                      .Include(s => s.Subscriptions)
                      .ThenInclude(b => b.Book)
                      .FirstOrDefault();

            _dbContext.Subscriptions
                      .Include(b => b.Book)
                      .Include(u => u.User)
                      .FirstOrDefault();

            _dbContext.Books
                      .Include(s => s.Subscriptions)
                      .ThenInclude(b => b.User)
                      .FirstOrDefault();
        }
        #endregion
    }
}
