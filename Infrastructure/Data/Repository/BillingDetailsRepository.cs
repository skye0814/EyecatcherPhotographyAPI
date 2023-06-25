using Core.Entities;
using Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class BillingDetailsRepository : RepositoryBase<BillingDetails>, IBillingDetailsRepository
    {
        public BillingDetailsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<BillingDetails> GetAllBillingDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public BillingDetails GetBillingDetailsByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
