using Core.Entities;
using Core.Interface.Repository;
using Infrastructure.Extensions;
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
        
        public async Task UpdateProduct(Product dbProduct, Product product)
        {
            dbProduct.Map(product);
            Update(dbProduct);
            await SaveAsync();
        }

        public async Task CreateProduct(Product product)
        {
            await CreateAsync(product);
            await SaveAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            Delete(product);
            await SaveAsync();
        }

        public IQueryable<Product> GetAllProducts(string sort, int pageNumber, int pageSize, string search)
        {
            switch(sort)
            {
                case "asc":
                    return Query()
                        .OrderBy(x => x.Price)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize);
                case "desc":
                    return Query()
                        .OrderByDescending(x => x.Price)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize);
                default: 
                    goto case "asc";
            }
        }

        public Product? GetProductByProductTag(string productTag)
        {
            return FindByConditionQuery(x => x.ProductTag == productTag)
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
            return FindByConditionQuery(x => x.ProductCategoryID == productCategoryId)
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
