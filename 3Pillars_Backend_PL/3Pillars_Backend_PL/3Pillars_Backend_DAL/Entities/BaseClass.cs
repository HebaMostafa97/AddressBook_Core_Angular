using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _3Pillars_Backend_DAL.Entities
{
    public class BaseClass
    {
        public BaseClass()
        {
            this.Active = "A";
        }
        [Key]
        public int Id { get; set; }
        public string Active { get; set; }
        public string AddedBy { get; set; }
        public string AddedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedOn { get; set; }

    }
}
