using Core.Entities;
using Core.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return FindAll()
                .OrderBy(x => x.ProductName);
        }

        public Product? GetProductByProductTag(string productTag)
        {
            return Query().Where(x => x.ProductTag == productTag)
                .Include(pc => pc.ProductCategory)
                .FirstOrDefault();
        }

        public Product? GetProductById(long id)
        {
            return Query().Where(x => x.ProductID == id)
                .Include(pc => pc.ProductCategory)
                .FirstOrDefault();
        }

        public IQueryable<Product> GetProductsByProductCategoryId(long? productCategoryId)
        {
            return FindByConditionQuery(x => x.ProductCategory.ProductCategoryID == productCategoryId)
                .AsQueryable();
        }

        public Task UpdateProductRange(IEnumerable<Product> dbProducts, IEnumerable<Product> products)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProductRange(IEnumerable<Product> dbProducts)
        {
            UpdateMultiple(dbProducts);
            await SaveAsync();
        }
    }
}
