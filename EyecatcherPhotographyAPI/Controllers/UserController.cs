using Core.Entities;
using EyecatcherPhotographyAPI.WebModel.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EyecatcherPhotographyAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
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

    }
}
