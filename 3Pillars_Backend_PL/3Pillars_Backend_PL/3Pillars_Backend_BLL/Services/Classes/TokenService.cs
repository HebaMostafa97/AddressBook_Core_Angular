using _3Pillars_Backend_BLL.Services.Interface;
using _3Pillars_Backend_DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _3Pillars_Backend_BLL.Services.Classes
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        // Promots Dependency Injection sith Inject Configuration in Constructor
        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<string> CreateToken(User user, UserManager<User> userManager)
        {
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.DisplayName),
            };
            // Function GetRolesAsync To Get User(Email,DisplayName) Roles
            var userRoles = await userManager.GetRolesAsync(user);

            // Add UserRole In List of Claim 'authClaims'
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }
            
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));

            // Get Token from JWTSecurityToken with Its Components (Issuer,audience,expires,claims,SignInCredentials)
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"], // Configure key : ValidIssuer with Value in appsettings.json
                audience: configuration["JWT:ValidAudience"],// Configure key : ValidAudience with Value in appsettings.json
                expires: DateTime.Now.AddDays(double.Parse(configuration["JWT:DurationInDays"])),// Configure key : DurationInDays with Value in appsettings.json
                claims: authClaims,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
