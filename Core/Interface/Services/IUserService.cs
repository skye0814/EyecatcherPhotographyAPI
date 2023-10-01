using Core.WebModel.Response;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Services
{
    public interface IUserService
    {
        Task<IdentityResult> AssignRole(string userId, string roleName);
        Task<UserWebResponse> GetUserFromToken(string token);
    }
}
