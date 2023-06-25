namespace EyecatcherPhotography.Services
{
    using Core.Entities;
    using Core.Interface.Services;
    using Infrastructure.Data.Repository;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class ProductCategoryService : IProductCategoryService
    {
        private readonly RepositoryWrapper repository;

        public ProductCategoryService(RepositoryWrapper repository)
        {
            this.repository = repository;
        }

        public async Task CreateProductCategory(ProductCategory category)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch(Exception ex)
            {
                throw new Exception("Error occured on Product Category service.", ex);
            }
        }
    }
}