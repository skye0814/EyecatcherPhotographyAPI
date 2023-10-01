using Core.Interface.Services;
using Core.WebModel.Response;
using Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EyecatcherPhotography.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        public UserService(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        public async Task<UserWebResponse> GetUserFromToken(string token)
        {
            try
            {
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

                return new UserWebResponse()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = userManager.GetRolesAsync(user).Result.DefaultIfEmpty("").First()
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occured in User Service: {ex.Message}");
            }
        }

        public async Task<IdentityResult> AssignRole(string id, string roleName)
        {
            IdentityResult? result = null;
            var errors = new List<IdentityError>();
            try
            {
                var userDb = await userManager.FindByIdAsync(id);
                var role = await roleManager.RoleExistsAsync(roleName);

                if (userDb == null)
                {
                    errors.Add(new IdentityError()
                    {
                        Code = "400",
                        Description = "User not found"
                    });
                    result = IdentityResult.Failed(errors.ToArray());
                    return result;
                }
                if (!role)
                {
                    errors.Add(new IdentityError()
                    {
                        Code = "400",
                        Description = $"The role {roleName} does not exist"
                    });
                    result = IdentityResult.Failed(errors.ToArray());
                    return result;
                }

                var userRole = await userManager.GetRolesAsync(userDb);

                if (userRole.Count != 0)
                {
                    await userManager.RemoveFromRolesAsync(userDb, userRole);
                }

                result = await userManager.AddToRoleAsync(userDb, roleName);

                if (!result.Succeeded)
                {
                    throw new Exception($"There was an error occured in UserService: {result.Errors}");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error occured in UserService: {ex.Message}");
            }
        }
    }
}
