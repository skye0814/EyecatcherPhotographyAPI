using Core.Entities;
using Core.WebModel.Request;
using Core.WebModel.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Services
{
    public interface IProductService
    {
        PaginationFilterResponse<Product> GetProductByProductCategoryID_Filtered(PaginationFilterRequest pagedRequest);
    }
}