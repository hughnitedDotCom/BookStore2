using BookStore.Services.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces.Repository
{
    public interface IRepository <T> where T: BaseEntity
    {
        Task<T> AddAsync(T entity);

        Task<List<T>> AddRangeAsync(List<T> entities);

        Task<T> GetByIdAsync(Expression<Func<T, bool>> ids);

        IQueryable<T> GetAll();

        Task<int> UpdateAsync(T entity);

        Task<int> DeleteAsync(T entity);
    }
}
