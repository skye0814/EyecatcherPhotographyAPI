using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Repository
{
    public interface ICustomerRepository
    {
        Customer? GetCustomerByAppUserId(string Id);
        Task CreateCustomer(Customer customer);
    }
}
