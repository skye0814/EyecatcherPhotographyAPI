using Core.WebModel.Response;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Services
{
    public interface IAuthenticationService
    {
        AuthenticationResponse CreateToken(IdentityUser user);
    }
}
