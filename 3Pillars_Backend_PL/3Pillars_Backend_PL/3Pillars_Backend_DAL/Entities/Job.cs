using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _3Pillars_Backend_DAL.Entities
{
    public class Job : BaseClass
    {
        public Job()
        {
            AddressBooks = new HashSet<AddressBook>();
        }
     

        [Required]
        public string Name { get; set; }

        // Navigation Property 
        public virtual ICollection<AddressBook> AddressBooks { get; set; }
    }
}
