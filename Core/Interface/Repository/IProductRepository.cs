using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Repository
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task UpdateProductRange(IEnumerable<Product> dbProducts, IEnumerable<Product> products);
        Product? GetProductById(long id);
        IQueryable<Product> GetProductsByProductCategoryId(long? productCategoryId);
        Task UpdateProductRange(IEnumerable<Product> dbProducts);
        IEnumerable<Product> GetAllProducts();
    }
}
