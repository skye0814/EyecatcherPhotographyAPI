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
    public class ProductCategoryController : ControllerBase
    {
        private readonly RepositoryWrapper repository;
        private readonly IProductCategoryService service;

        public ProductCategoryController(RepositoryWrapper repository, IProductCategoryService service)
        {
            this.repository = repository;
            this.service = service;
        }

        [HttpGet("{id}", Name = "GetProductCategoryById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public IActionResult GetProductCategoryById(long id)
        {
            try
            {
                var category = repository.ProductCategory.GetProductCategoryById(id);

                if (category == null || category.ProductCategoryID.Equals(0))
                {
                    return NotFound();
                }

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetAllProductCategory()
        {
            try
            {
                var categories = repository.ProductCategory.GetAllProductCategories();

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProductCategory), 201)]
        [ProducesResponseType(500)]
        public IActionResult UpdateProductCategory([FromBody] ProductCategory category)
        {
            try
            {
                if (category == null)
                {
                    return BadRequest("Product Category is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var dbCategory = repository.ProductCategory.GetProductCategoryById(category.ProductCategoryID);

                if (dbCategory == null || dbCategory.ProductCategoryID.Equals(0))
                {
                    return NotFound("Product category does not exist.");
                }

                repository.ProductCategory.UpdateProductCategory(dbCategory, category);

                return CreatedAtAction("GetProductCategoryById", new { id = category.ProductCategoryID }, category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductCategory), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateProductCategory([FromBody] ProductCategory category)
        {
            try
            {
                if (category == null || string.IsNullOrEmpty(category.CategoryName))
                {
                    return BadRequest("Product Category is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var existingCategory = repository.ProductCategory.GetProductCategoryByName(category.CategoryName);

                if (existingCategory != null)
                {
                    return BadRequest("Product Category name already exists.");
                }

                await repository.ProductCategory.CreateProductCategory(category);

                return CreatedAtAction("GetProductCategoryById", new { id = category.ProductCategoryID }, category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteProductCategory(long id)
        {
            try
            {
                var category = repository.ProductCategory.GetProductCategoryById(id);

                if (category == null || category.ProductCategoryID.Equals(0))
                {
                    return NotFound();
                }

                await repository.ProductCategory.DeleteProductCategory(category);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(long id) 
        {
            try
            {
                var product = repository.Product.GetProductById(id);

                if (product == null)
                {
                    return NotFound("Product does not exists.");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
