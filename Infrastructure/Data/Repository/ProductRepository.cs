using Core.Entities;
using Core.Interface;
using Core.Interface.Repository;
using Core.WebModel.Request;
using Infrastructure.Extensions;
using Infrastructure.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
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

        public IQueryable<Product> GetAllProducts_Filtered(PaginationFilterRequest request)
        {
            var dictionary = new ProductExpressionsDictionary();

            return Query()
                        .Where(x =>
                            x.ProductName!.ToLower().Contains(request.Search!.ToLower()) ||
                            x.ProductDescription!.ToLower().Contains(request.Search.ToLower()) ||
                            x.ProductTag!.ToLower().Contains(request.Search.ToLower()) ||
                            x.FreeText1!.ToLower().Contains(request.Search.ToLower()) ||
                            x.FreeText2!.ToLower().Contains(request.Search.ToLower()) ||
                            x.FreeText3!.ToLower().Contains(request.Search.ToLower()) ||
                            x.FreeText4!.ToLower().Contains(request.Search.ToLower()))
                        .Sort(request.isAscending, dictionary.GetValue(request.SortBy))
                        .Skip((request.PageNumber - 1) * request.PageSize)
                        .Take(request.PageSize);
        }

        public int AllProductsCount()
        {
            return FindAll().Count();
        }

        public IQueryable<Product> GetAllProducts()
        {
            return FindAllQuery();
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
