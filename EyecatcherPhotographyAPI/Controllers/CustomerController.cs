using Core.Interface.Repository;
using Core.Interface.Services;
using EyecatcherPhotography.Services.Exceptions;
using Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EyecatcherPhotographyAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;
        private readonly ICustomerService customerService;

        public CustomerController(
            IRepositoryWrapper repository,
            ICustomerService customerService)
        {
            this.repository = repository;
            this.customerService = customerService;
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCustomer(string id)
        {
            try
            {
                var customer = await customerService.GetCustomerAppUserInfoByAppUserId(id);
                if (customer == null)
                {
                    return NotFound("Customer does not exist");
                }

                return Ok(customer);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
