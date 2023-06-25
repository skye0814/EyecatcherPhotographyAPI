using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Repository
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> Query();
        IQueryable<T> FindAllQuery();
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindByConditionQuery(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void CreateMultiple(IEnumerable<T> entity);
        void Update(T entity);
        void UpdateMultiple(IEnumerable<T> entity);
        void Delete(T entity);
        void DeleteMultiple(IEnumerable<T> entity);
        void Save();

        // Asynchronous methods
        Task CreateAsync(T entity);
        Task CreateMultipleAsync(IEnumerable<T> entity);
        Task SaveAsync();
    }
}
