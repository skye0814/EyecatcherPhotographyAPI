using Core.Entities;
using Core.Interface.Services;
using Core.WebModel.Request;
using Core.WebModel.Response;
using EyecatcherPhotography.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EyecatcherPhotographyAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
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

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserWebRequest user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid model object");

            var existingUsername = await userManager.FindByNameAsync(user.UserName);

            if (existingUsername != null)
                return BadRequest("Username already exists");

            var result = await userManager.CreateAsync(
                new IdentityUser() {
                    UserName = user.UserName,
                    Email = user.Email
                },
                user.Password
            );

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            var createdUser = await userManager.FindByNameAsync(user.UserName);

            await AssignRole(new UserWebRequest { Id = createdUser.Id, RoleName = "Customer" });

            user.Password = null;
            return CreatedAtAction("GetUser", new { userName = user.UserName }, user);
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
        public async Task<ActionResult<AuthenticationResponse>> CreateBearerToken([FromBody] AuthenticationRequest request)
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
