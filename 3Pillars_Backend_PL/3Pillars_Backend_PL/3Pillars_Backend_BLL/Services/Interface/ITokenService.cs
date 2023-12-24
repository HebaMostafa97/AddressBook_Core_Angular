using _3Pillars_Backend_DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _3Pillars_Backend_BLL.Services.Interface
{
    public interface ITokenService
    {
        // This Prototype Function CreateToken Take User and UserManager as a parameter 
        Task<string> CreateToken(User user, UserManager<User> userManager);
    }
}
