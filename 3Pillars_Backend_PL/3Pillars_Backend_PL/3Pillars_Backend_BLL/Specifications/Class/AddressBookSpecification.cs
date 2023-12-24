using _3Pillars_Backend_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3Pillars_Backend_BLL.Specifications.Class
{
    public class AddressBookSpecification : BaseSpecification<AddressBook>
    {
        // Default Constructor 
        public AddressBookSpecification()
        {
            AddInclude(P => P.Department);
            AddInclude(P => P.Job);
        }
        // Parameter Constructor With AddressBookId To include its Department and Jobs 
        public AddressBookSpecification(int id) : base(P => P.Id == id)
        {
            AddInclude(P => P.Department);
            AddInclude(P => P.Job);
        }

    }
}
