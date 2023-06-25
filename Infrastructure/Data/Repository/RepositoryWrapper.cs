using Core.Entities;
using Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext repositoryContext;

        private IBillingDetailsRepository billingDetails;
        private IProductCategoryRepository productCategoryRepository;
        private IProductRepository productRepository;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public IProductRepository Product
        {
            get
            {
                if (this.productRepository == null)
                {
                    productRepository = new ProductRepository(repositoryContext);
                }

                return this.productRepository;
            }
        }

        public IBillingDetailsRepository BillingDetails
        {
            get
            {
                if(this.billingDetails == null)
                {
                    billingDetails = new BillingDetailsRepository(repositoryContext);
                }

                return this.billingDetails;
            }
        }

        public IProductCategoryRepository ProductCategory
        {
            get
            {
                if(this.productCategoryRepository == null)
                {
                    productCategoryRepository = new ProductCategoryRepository(repositoryContext);
                }

                return this.productCategoryRepository;
            }
        }

        public void Save()
        {
            repositoryContext.SaveChanges();
        }
    }
}
