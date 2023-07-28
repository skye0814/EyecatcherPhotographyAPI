namespace EyecatcherPhotography.Services
{
    using Core.Entities;
    using Core.Interface.Repository;
    using Core.Interface.Services;
    using Core.WebModel.Request;
    using Core.WebModel.Response;
    using Infrastructure.Data.Repository;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        public PaginationFilterResponse<Product> GetProductByProductCategoryID_Filtered(PaginationFilterRequest pagedRequest)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch(Exception ex)
            {
                throw new Exception($"Error occured on Product service: {ex.Message}");
            }
        }
    }
}