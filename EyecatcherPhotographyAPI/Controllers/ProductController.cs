using AutoMapper;
using Core.Entities;
using Core.Interface.Repository;
using Core.Interface.Services;
using Core.WebModel.Request;
using Core.WebModel.Response;
using Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EyecatcherPhotographyAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;
        private readonly IMapper mapper;

        public ProductController(IRepositoryWrapper repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetProductById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetProductById(long id)
        {
            try
            {
                var product = repository.Product.GetProductById(id);

                if (product == null)
                {
                    return NotFound("Product does not exist.");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetAllProducts_Filtered(PaginationFilterRequest pagedRequest){
            
            try
            {
                var products = repository.Product.GetAllProducts_Filtered(pagedRequest);

                var result = new PaginationFilterResponse<Product>(
                    pagedRequest.PageNumber,
                    pagedRequest.PageSize,
                    products,
                    pagedRequest.Search != "" ? products.Count() : repository.Product.AllProductsCount());

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
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

                var productCategory = repository.ProductCategory.GetProductCategoryById(product.ProductCategoryID);

                if (productCategory == null)
                {
                    return NotFound("The selected Product Category does not exist");
                }

                var existingProduct = repository.Product.GetProductByProductTag(product.ProductTag);

                if(existingProduct != null)
                {
                    return BadRequest("There is already an existing Product Tag");
                }

                await repository.Product.CreateProduct(product);

                return CreatedAtAction("GetProductById", new { id = product.ProductID }, product);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
