using Core.Entities;
using Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public Customer? GetCustomerByAppUserId(string Id)
        {
            return Query().Where(x => x.Id == Id)
                .FirstOrDefault();
        }
    }
}
