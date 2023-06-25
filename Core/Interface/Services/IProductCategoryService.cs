using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Services
{
    public interface IProductCategoryService
    {
        Task CreateProductCategory(ProductCategory category);
    }
}
