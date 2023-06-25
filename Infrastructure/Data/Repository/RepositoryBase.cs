using Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext repositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }
  
        public void Create(T entity)
        {
            repositoryContext.Set<T>().Add(entity);
        }

        public async Task CreateAsync(T entity)
        {
            await repositoryContext.Set<T>().AddAsync(entity);
        }

        public void CreateMultiple(IEnumerable<T> entity)
        {
            repositoryContext.Set<T>().AddRange(entity);
        }

        public async Task CreateMultipleAsync(IEnumerable<T> entity)
        {
            await repositoryContext.Set<T>().AddRangeAsync(entity);
        }

        public void Delete(T entity)
        {
            repositoryContext.Set<T>().Remove(entity);
        }

        public void DeleteMultiple(IEnumerable<T> entity)
        {
            repositoryContext.Set<T>().RemoveRange(entity);
        }

        public IEnumerable<T> FindAll()
        {
            return repositoryContext.Set<T>();
        }

        public IQueryable<T> FindAllQuery()
        {
            return repositoryContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return repositoryContext.Set<T>().Where(expression);
        }

        public IQueryable<T> FindByConditionQuery(Expression<Func<T, bool>> expression)
        {
            return repositoryContext.Set<T>().Where(expression);
        }

        public IQueryable<T> Query()
        {
            return repositoryContext.Set<T>();
        }

        public void Save()
        {
            repositoryContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await repositoryContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            repositoryContext.Set<T>().Update(entity);
        }

        public void UpdateMultiple(IEnumerable<T> entity)
        {
            repositoryContext.Set<T>().UpdateRange(entity);
        }

    }
}
