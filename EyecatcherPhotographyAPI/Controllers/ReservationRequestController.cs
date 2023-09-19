using Core.Entities;
using Core.Interface.Repository;
using Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EyecatcherPhotographyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
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

            return NotFound();
        }
    }
}
