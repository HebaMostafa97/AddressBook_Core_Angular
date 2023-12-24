using _3Pillars_Backend_DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _3Pillars_Backend_PL.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^(?=.*[^a-zA-Z0-9])(?=.*[A-Z]).{6,}$",ErrorMessage = "Invalid Password ,it must be at least 6 characters ,have at least one non alphanumeric character and one uppercase ('A'-'Z') ")]
        public string Password { get; set; }

        [Required]
        [RegularExpression("^01[0125][0-9]{8}$", ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }
    }
}
