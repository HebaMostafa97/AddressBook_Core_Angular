
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3Pillars_Backend_DAL.Entities.Identity
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
