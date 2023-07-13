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
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateProductCategory(ProductCategory category)
        {
            Create(category);
            await SaveAsync();
        }

        public async Task DeleteProductCategory(ProductCategory category)
        {
            Delete(category);
            await SaveAsync();
        }
    
        public IQueryable<ProductCategory> GetAllProductCategories(string sort, int pageNumber, int pageSize)
        {
            switch (sort)
            {
                case "asc":
                    return Query()
                        .OrderBy(x => x.CategoryName)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize);
                case "desc":
                    return Query()
                        .OrderByDescending(x => x.CategoryName)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize);
                default:
                    goto case "asc";
            }
        }

        public int GetAllProductCategoriesCount()
        {
            return FindAll().Count();
        }

        public ProductCategory? GetProductCategoryById(long? id)
        {
            return Query().Where(x => x.ProductCategoryID == id)
                .Include(p => p.Products)
                .FirstOrDefault();
            //return FindByCondition(x => x.ProductCategoryID == id)
            //    .FirstOrDefault();
        }

        public ProductCategory? GetProductCategoryByName(string categoryName)
        {
            return FindByCondition(x => x.CategoryName == categoryName)
                .FirstOrDefault();
        }

        public void UpdateProductCategory(ProductCategory dbCategory, ProductCategory category)
        {
            dbCategory.Map(category);
            Update(dbCategory);
            Save();
        }
    }
}
