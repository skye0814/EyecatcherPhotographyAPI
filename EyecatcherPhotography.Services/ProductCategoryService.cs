﻿namespace EyecatcherPhotography.Services
{
    using Core.Entities;
    using Core.Interface.Repository;
    using Core.Interface.Services;
    using Infrastructure.Data.Repository;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IRepositoryWrapper repository;

        public ProductCategoryService(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }
        
        public async Task DeleteProductCategory(ProductCategory category)
        {
            try
            {
                var dbProducts = repository.Product.GetProductsByProductCategoryId(category.ProductCategoryID);

                if (dbProducts != null)
                {
                    foreach (var dbProduct in dbProducts)
                    {
                        dbProduct.ProductCategoryID = null;
                    }

                    await repository.Product.UpdateProductRange(dbProducts);
                }

                await repository.ProductCategory.DeleteProductCategory(category);
            }
            catch(Exception ex)
            {
                throw new Exception($"Error occured on ProductCategory service: {ex.Message}");
            }
        }
    }
}