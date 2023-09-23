using Core.Interface.Services;
using Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyecatcherPhotography.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserService(
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
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
