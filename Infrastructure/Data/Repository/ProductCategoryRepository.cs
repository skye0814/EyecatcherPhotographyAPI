using Core.Entities;
using Core.Interface.Repository;
using Infrastructure.Extensions;
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

        public IEnumerable<ProductCategory> GetAllProductCategories()
        {
            return FindAll()
                .OrderBy(x => x.CategoryName);
        }

        public ProductCategory? GetProductCategoryById(long? id)
        {
            return FindByCondition(x => x.ProductCategoryID == id)
                .FirstOrDefault();
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
