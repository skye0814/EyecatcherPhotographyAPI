﻿using Core.Entities;
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
                            x.ProductName!.Contains(request.Search) ||
                            x.ProductDescription!.Contains(request.Search) ||
                            x.ProductTag!.Contains(request.Search) ||
                            x.FreeText1!.Contains(request.Search) ||
                            x.FreeText2!.Contains(request.Search) ||
                            x.FreeText3!.Contains(request.Search) ||
                            x.FreeText4!.Contains(request.Search))
                        .Sort(request.isAscending, dictionary.GetValue(request.SortBy))
                        .Skip((request.PageNumber - 1) * request.PageSize)
                        .Take(request.PageSize);
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
