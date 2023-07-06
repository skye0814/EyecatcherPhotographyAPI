using Core.Entities;
using Core.Interface.Repository;
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
        private readonly IRepositoryWrapper repository;

        public ProductController(IRepositoryWrapper repository)
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

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            try
            {
                var product = repository.Product.GetProductById(id);

                if(product == null)
                {
                    return NotFound("Product you are trying to delete does not exist");
                }

                await repository.Product.DeleteProduct(product);

                return NoContent();
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
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
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
                var productCategory = repository.ProductCategory.GetProductCategoryById(product.ProductCategoryID);

                if (productCategory == null)
                {
                    return NotFound("The selected Product Category does not exist");
                }

                // Check if there is existing product tag.. If yes, don't create
                var existingProduct = repository.Product.GetProductByProductTag(product.ProductTag);

                if(product != null)
                {
                    return BadRequest("There is already an existing Product Tag");
                }

                await repository.Product.CreateProduct(product);

                return CreatedAtAction("GetProductCategoryById", new { id = product.ProductID }, product);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
