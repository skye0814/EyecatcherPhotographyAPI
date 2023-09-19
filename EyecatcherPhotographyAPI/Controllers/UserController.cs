using Core.Entities;
using Core.Interface.Services;
using Core.WebModel.Request;
using Core.WebModel.Response;
using EyecatcherPhotography.Services;
using Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EyecatcherPhotographyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IAuthenticationService authService;

        public UserController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IAuthenticationService authService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.authService = authService;
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
                var userDb = await userManager.FindByIdAsync(user.Id);
                var role = await roleManager.RoleExistsAsync(user.RoleName);

                if (userDb == null && !role)
                {
                    return NotFound("User or role not found");
                }

                var result = await userManager.AddToRoleAsync(userDb, user.RoleName);

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

        private async Task<IdentityResult> AssignRole(string id, string roleName)
        {
            try
            {
                var userDb = await userManager.FindByIdAsync(id);
                var role = await roleManager.RoleExistsAsync(roleName);

                if (userDb == null && !role)
                {
                    throw new Exception("User or role does not exist"); 
                }

                var result = await userManager.AddToRoleAsync(userDb, roleName);

                if (!result.Succeeded)
                {
                    throw new Exception($"Adding role not succeeded: {result.Errors}");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error occured on assigning role: {ex.Message}");
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

                var isRoleAssigned = await AssignRole(createdUser.Id, "Customer");

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
                        Email = x.Email
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
