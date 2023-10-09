using Core.Entities;
using Core.Interface.Services;
using Core.WebModel.Request;
using Core.WebModel.Response;
using EyecatcherPhotography.Services;
using EyecatcherPhotography.Services.Exceptions;
using Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace EyecatcherPhotographyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IAuthenticationService authService;
        private readonly IUserService userService;
        private readonly ICustomerService customerService;
        private readonly IConfiguration configuration;

        public UserController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IAuthenticationService authService,
            IUserService userService,
            ICustomerService customerService,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.authService = authService;
            this.userService = userService;
            this.customerService = customerService;
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            try
            {
                var user = await userService.GetUserFromToken(Request.Headers["Authorization"].ToString().Replace("Bearer ", ""));

                if (user == null)
                {
                    return Unauthorized("User not found");
                }

                return Ok(user);
            }
            catch(Exception)
            {
                return Unauthorized("Token is invalid");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var userDb = await userManager.FindByIdAsync(id);

                if (userDb == null)
                {
                    return NotFound("User does not exist");
                }

                await userManager.DeleteAsync(userDb);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserRole (string username)
        {
            try
            {
                var userDb = await userManager.FindByNameAsync(username);
                var claims = userManager.GetClaimsAsync(userDb);

                if (userDb == null)
                {
                    return NotFound("User not found");
                }

                var role = await userManager.GetRolesAsync(userDb);

                return Ok(role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> AssignRole([FromBody] UserWebRequest user)
        {
            try
            {
                var result = await userService.AssignRole(user.Id, user.RoleName);

                if(!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                return Ok("Role assigned to user successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object");

                var existingUsername = await userManager.FindByNameAsync(user.UserName);

                if (existingUsername != null)
                    return BadRequest("Username already exists");

                var result = await userManager.CreateAsync(
                    new IdentityUser()
                    {
                        UserName = user.UserName,
                        Email = user.Email
                    },
                    user.Password
                );

                if (!result.Succeeded)
                    return BadRequest(result.Errors);

                var createdUser = await userManager.FindByNameAsync(user.UserName);
                var isRoleAssigned = await userService.AssignRole(createdUser.Id, "Customer"); 

                if (!isRoleAssigned.Succeeded)
                    return BadRequest(isRoleAssigned.Errors);

                var customer = new Customer()
                {
                    Id = createdUser.Id,
                    FirstName = user.FirstName,
                    MiddleName = user.MiddleName,
                    LastName = user.LastName
                };

                await customerService.InsertCustomer(customer);

                user.Password = null;
                return CreatedAtAction("GetUser", new { userName = user.UserName }, user);
            }
            catch(BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var userDb = await userManager.Users
                    .Select(x => new UserWebResponse
                    {
                        Id = x.Id,
                        UserName = x.UserName,
                        Email = x.Email,
                        Role = userManager.GetRolesAsync(x).Result.DefaultIfEmpty("").First(),
                    })
                    .ToListAsync();

                return Ok(userDb);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{username}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(string username)
        {
            var userDb = await userManager.FindByNameAsync(username);

            if (userDb == null)
                return NotFound("This user does not exist.");


            // Add here CustomerResponse instead
            return Ok(new UserWebResponse()
            {
                Id = userDb.Id,
                UserName = userDb.UserName,
                Email = userDb.Email,
                Role = userManager.GetRolesAsync(userDb).Result.DefaultIfEmpty("").First()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthenticationRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object");

                var user = await userManager.FindByNameAsync(request.UserName);

                if (user == null)
                    return BadRequest("Username does not exist");

                var isPasswordValid = await userManager.CheckPasswordAsync(user, request.Password);

                if (!isPasswordValid)
                    return BadRequest("Password is incorrect or invalid");

                var token = await authService.CreateTokenAsync(user);
                var userFromToken = await userService.GetUserFromToken(token.Token);

                if (userFromToken == null)
                    return NotFound("User not found from the provided token");

                return Ok(new {
                    user = userFromToken,
                    token = token.Token
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Internal server error: {ex.Message}");
            }
        }
    }
}
