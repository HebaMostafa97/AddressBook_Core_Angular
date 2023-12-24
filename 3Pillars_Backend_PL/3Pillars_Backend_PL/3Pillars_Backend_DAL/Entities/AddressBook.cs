using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _3Pillars_Backend_DAL.Entities
{
    public class AddressBook : BaseClass
    {
      
        [Required]
        public string FullName { get; set; }
        [Required]
        public int? JobTitleId { get; set; } // FK DropDownList From Department Table
        [Required]
        public int? DepartmentId { get; set; } // FK DropDownList From Job Table 
        [Required]
        public string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }

        public int Age { get; set; }

        // Navigation Property 
        public virtual Department Department { get; set; }
        public virtual Job Job { get; set; }

    }
}
