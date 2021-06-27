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
        readonly BookStoreContext _dbContext;

        public Repository()
        {
            if(_dbContext == null)
            {
                _dbContext = new BookStoreContext();
                _dbContext.Database.EnsureCreatedAsync();

                EagerLoadNavgationProperties();
            }
        }

        #region Public Methods

        public async Task<T> AddAsync(T entity)
        {
            T result;

            using (var con = new BookStoreContext())
            {
                entity.CreateDate = DateTime.Now;

               result = _dbContext.Set<T>().Add(entity).Entity;

                await _dbContext.SaveChangesAsync();
            }
               

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

        #endregion


        #region Private Methods

        private void EagerLoadNavgationProperties()
        {
            //context remembers eager loads for future calls
            //There is a better approach, too late to refactor
            _dbContext.Users
                      .Include(s => s.Subscriptions)
                      .ThenInclude(b => b.Book)
                      .FirstOrDefault();

            _dbContext.Subscriptions
                      .Include(b => b.User)
                      .Include(u => u.Book)
                      .FirstOrDefault();

            _dbContext.Books
                      .Include(s => s.Subscriptions)
                      .ThenInclude(b => b.User)
                      .FirstOrDefault();
        }
        #endregion
    }
}
