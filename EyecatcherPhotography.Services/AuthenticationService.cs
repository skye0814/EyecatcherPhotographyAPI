using Core.Interface.Services;
using Core.WebModel.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EyecatcherPhotography.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private const int EXPIRATION_MINUTES = 144000;
        private readonly IConfiguration configuration;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AuthenticationService(IConfiguration configuration, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<AuthenticationResponse> CreateTokenAsync(IdentityUser user)
        {
            var expiration = DateTime.UtcNow.AddMinutes(EXPIRATION_MINUTES);

            var token = CreateJwtToken(
                await CreateClaims(user),
                CreateSigningCredentials(),
                expiration
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return new AuthenticationResponse
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = expiration
            };
        }

        private async Task<Claim[]> CreateClaims(IdentityUser user) 
        {
            var userRoles = await userManager.GetRolesAsync(user);

            var userRolesClaims = userRoles.Select(x => new Claim(ClaimTypes.Role, x));

            return new[] {
                new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            }
            .Union(userRolesClaims)
            .ToArray();
        }

        private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration)
        {
            return new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: expiration,
                signingCredentials: credentials
            );
        }

        private SigningCredentials CreateSigningCredentials()
        {
            return new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["Jwt:Key"])
                ),
                SecurityAlgorithms.HmacSha256
            );
        }
    }
}
