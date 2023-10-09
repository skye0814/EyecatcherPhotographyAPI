using Core.Entities;
using Core.Interface.Services;
using Core.WebModel.Response;
using EyecatcherPhotography.Services.Exceptions;
using Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyecatcherPhotography.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly RepositoryWrapper repository;
        private readonly ILogger<CustomerService> logger;
        private readonly UserManager<IdentityUser> userManager;

        public CustomerService(
            RepositoryWrapper repository, 
            ILogger<CustomerService> logger, 
            UserManager<IdentityUser> userManager)
        {
            this.repository = repository;
            this.logger = logger;
            this.userManager = userManager;
        }

        public async Task InsertCustomer(Customer customer)
        {
            var appUser = await userManager.FindByIdAsync(customer.Id);
            if (appUser == null)
            {
                throw new BadRequestException("Cannot add customer because the ID provided does not exist in App Users");
            }

            await repository.Customer.CreateCustomer(customer);
        }

        public async Task<CustomerResponse> GetCustomerAppUserInfoByAppUserId(string appUserId)
        {
            var result = new CustomerResponse();
            var userInfo = await userManager.FindByIdAsync(appUserId);
            if (userInfo == null)
            {
                throw new NotFoundException("User does not exist");
            }
            var customer = repository.Customer.GetCustomerByAppUserId(appUserId);
            if (customer == null)
            {
                throw new NotFoundException("User does not have customer information");
            }
            if (userInfo != null && customer != null)
            {
                result = new CustomerResponse()
                {
                    CustomerID = customer.CustomerID,
                    FirstName = customer.FirstName,
                    MiddleName = customer.MiddleName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    ContactNumber = customer.ContactNumber,
                    ApplicationUser = new UserWebResponse()
                    {
                        Id = appUserId,
                        Email = userInfo.Email,
                        UserName = userInfo.UserName,
                        Role = userManager.GetRolesAsync(userInfo).Result.DefaultIfEmpty("").First(),
                    }
                };
            }
            
            return result;
        }
    }
}
