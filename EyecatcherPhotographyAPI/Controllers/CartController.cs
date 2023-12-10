using Core.Entities;
using Core.Interface.Repository;
using Core.Interface.Services;
using EyecatcherPhotography.Services;
using EyecatcherPhotography.Services.Exceptions;
using Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EyecatcherPhotographyAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CartController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;
        private readonly IUserService userService;

        public CartController(IRepositoryWrapper repository, IUserService userService)
        {
            this.repository = repository;
            this.userService = userService;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCartByUID()
        {
            try
            {
                var user = await userService.GetUserFromToken(Request.Headers["Authorization"].ToString().Replace("Bearer ", ""));

                var result = repository.Cart.GetCartListByUID(user.Id);

                return Ok(result);  
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetCartById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetCartById(long id)
        {
            try
            {
                var cartItem = repository.Cart.GetCart(id);

                if (cartItem == null)
                {
                    return NotFound("Product does not exist in the cart.");
                }

                return Ok(cartItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        public async Task<IActionResult> AddToCart(Cart cart)
        {
            try
            {
                var user = await userService.GetUserFromToken(Request.Headers["Authorization"].ToString().Replace("Bearer ", ""));
                cart.ApplicationUser.Id = user.Id;

                await repository.Cart.CreateAsync(cart);

                return CreatedAtAction("GetCartById", new { id = cart.CartID }, cart);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
