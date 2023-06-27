using Core.Entities;
using Core.Interface.Services;
using Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EyecatcherPhotographyAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly RepositoryWrapper repository;

        public ProductController(RepositoryWrapper repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = repository.Product.GetAllProducts();

                return Ok(products);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                if(product == null)
                {
                    return BadRequest("Product entity is null");
                }

                // Check if the selected product category exists in db
                var productCategory = repository.ProductCategory.GetProductCategoryById(product.ProductCategoryID)

                if (productCategory == null)
                {
                    return NotFound("The selected Product Category does not exist");
                }

                // Check if there is existing product tag.. If yes, don't create
                return Ok("pass");

                
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
