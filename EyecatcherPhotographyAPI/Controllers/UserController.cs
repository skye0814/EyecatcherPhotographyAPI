using Core.Entities;
using Core.Interface.Services;
using Core.WebModel.Request;
using Core.WebModel.Response;
using EyecatcherPhotography.Services;
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
        private readonly IConfiguration configuration;

        public UserController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IAuthenticationService authService,
            IUserService userService,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.authService = authService;
            this.userService = userService;
            this.configuration = configuration;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var key = hmac.Key;
                var handler = new JwtSecurityTokenHandler();
                var validations = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                var claims = handler.ValidateToken(token, validations, out var tokenSecure);

                // The user ID is stored in 3rd index of the claim array. The position might change
                // if we change the creation of token in AuthenticationService.cs, always debug
                // if we want to look for the user ID claim
                var nameIdentifier = claims.Claims.ToArray()[3].Value;

                var user = await userManager.FindByIdAsync(nameIdentifier);

                if (user == null)
                {
                    return NotFound("User not found");
                }

                return Ok(new UserWebResponse()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = userManager.GetRolesAsync(user).Result.DefaultIfEmpty("").First()
                });

            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
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
        public async Task<IActionResult> Register([FromBody] UserWebRequest user)
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

                user.Password = null;
                return CreatedAtAction("GetUser", new { userName = user.UserName }, user);
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

            return Ok(new UserWebResponse()
            {
                Id = userDb.Id,
                UserName = userDb.UserName,
                Email = userDb.Email
            });
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] AuthenticationRequest request)
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

            return Ok(token);
        }

    }
}
