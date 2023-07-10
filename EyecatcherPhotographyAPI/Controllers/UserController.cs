using Core.Entities;
using Core.Interface.Services;
using Core.WebModel.Request;
using Core.WebModel.Response;
using EyecatcherPhotography.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EyecatcherPhotographyAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IAuthenticationService authService;

        public UserController(UserManager<IdentityUser> userManager, IAuthenticationService authService)
        {
            this.userManager = userManager;
            this.authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserWebRequest user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            var result = await userManager.CreateAsync(
                new IdentityUser() {
                    UserName = user.UserName,
                    Email = user.Email
                },
                user.Password
            );

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            user.Password = null;
            return CreatedAtAction("GetUser", new { userName = user.UserName }, user);
        }

        [HttpGet("{username}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(string username)
        {
            var userDb = await userManager.FindByNameAsync(username);

            if (userDb == null)
            {
                return NotFound("This user does not exist.");
            }

            return Ok(new UserWebResponse()
            {
                UserName = userDb.UserName,
                Email = userDb.Email
            });
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticationResponse>> CreateBearerToken([FromBody] AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            var user = await userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return BadRequest("Username and/or password is null or empty");
            }

            var isPasswordValid = await userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Password is incorrect or invalid");
            }

            var token = authService.CreateToken(user);

            return Ok(token);
        }

    }
}
