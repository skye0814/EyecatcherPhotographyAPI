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
        private ICustomerRepository customerRepository;
        private ICartRepository cartRepository;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public ICartRepository Cart
        {
            get
            {
                if (this.cartRepository == null)
                {
                    cartRepository = new CartRepository(repositoryContext);
                }

                return this.cartRepository;
            }
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

        public ICustomerRepository Customer
        {
            get 
            {
                if(this.customerRepository == null)
                {
                    customerRepository = new CustomerRepository(repositoryContext);
                }
                
                return this.customerRepository;
            } 
        }

        public void Save()
        {
            repositoryContext.SaveChanges();
        }
    }
}
