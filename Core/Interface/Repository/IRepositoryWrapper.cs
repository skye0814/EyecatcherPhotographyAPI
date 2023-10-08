using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Repository
{
    public interface IRepositoryWrapper
    {
        IBillingDetailsRepository BillingDetails { get; }
        IProductCategoryRepository ProductCategory { get; }
        IProductRepository Product { get; }
        ICustomerRepository Customer { get; }
        void Save();
    }
}
