using AutoMapper;
using Core.Entities;
using Core.Interface.Repository;
using Core.Interface.Services;
using Core.WebModel;
using Core.WebModel.Response;
using EyecatcherPhotographyAPI.Helper;
using Infrastructure.Data.Repository;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EyecatcherPhotographyAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;
        private readonly IProductCategoryService productCategoryService;
        private readonly IMapper mapper;

        public ProductCategoryController(IRepositoryWrapper repository, IProductCategoryService productCategoryService, IMapper mapper)
        {
            this.repository = repository;
            this.productCategoryService = productCategoryService;
            this.mapper = mapper;
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

                if (category == null)
                {
                    return NotFound();
                }

                //return Ok(mapper.Map<ProductCategoryResponse>(category));
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
        public IActionResult GetAllProductCategory(string? sort = "", int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var categories = repository.ProductCategory.GetAllProductCategories(sort, pageNumber, pageSize);
                int categoriesTotalCount = repository.ProductCategory.GetAllProductCategoriesCount();
                return Ok(new PaginationFilterResponse<ProductCategory>
                    (pageNumber, pageSize, categories, categoriesTotalCount){});
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProductCategory), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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

                if (dbCategory == null)
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
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteProductCategory(long id)
        {
            try
            {
                var category = repository.ProductCategory.GetProductCategoryById(id);

                if (category == null)
                {
                    return NotFound();
                }
                await this.productCategoryService.DeleteProductCategory(category);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
