using Core.Entities;
using Core.WebModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Repository
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task CreateProduct(Product product);
        Task DeleteProduct(Product product);
        Task UpdateProduct(Product dbProduct, Product product);
        Task UpdateProductRange(IEnumerable<Product> dbProducts, IEnumerable<Product> products);
        Product? GetProductById(long id);
        IQueryable<Product> GetProductsByProductCategoryId(long? productCategoryId);
        Product? GetProductByProductTag(string productTag);
        Task UpdateProductRange(IEnumerable<Product> dbProducts);
        IQueryable<Product> GetAllProducts();
        IQueryable<Product> GetProductsWithFilter(PaginationFilterRequest request);
        int GetProductsWithFilterForCount(PaginationFilterRequest request);
    }
}
