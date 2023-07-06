using Core.Entities;
using Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EyecatcherPhotographyAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReservationRequestController : ControllerBase
    {
        private readonly IRepositoryWrapper repositoryWrapper;

        public ReservationRequestController(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public IActionResult GetAllBillingDetails() 
        {

            return Ok(repositoryWrapper.BillingDetails.FindByCondition(x => x.Customer.CustomerID == 1).DefaultIfEmpty());
        }
    }
}
