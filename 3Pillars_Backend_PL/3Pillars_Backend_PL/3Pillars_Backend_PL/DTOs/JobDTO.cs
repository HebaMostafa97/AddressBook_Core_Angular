using _3Pillars_Backend_DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _3Pillars_Backend_PL.DTOs
{
    public class JobDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
