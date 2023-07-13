using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Repository
{
    public interface IProductCategoryRepository : IRepositoryBase<ProductCategory>
    {
        ProductCategory? GetProductCategoryById(long? id);
        IQueryable<ProductCategory> GetAllProductCategories(string sort, int pageNumber, int pageSize);
        int GetAllProductCategoriesCount();
        Task CreateProductCategory(ProductCategory category);
        Task DeleteProductCategory(ProductCategory category);
        void UpdateProductCategory(ProductCategory dbCategory, ProductCategory category);
        ProductCategory? GetProductCategoryByName(string categoryName);
    }
}
