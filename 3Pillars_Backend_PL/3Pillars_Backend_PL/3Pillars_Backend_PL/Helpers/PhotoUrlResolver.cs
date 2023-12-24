using _3Pillars_Backend_DAL.Entities;
using _3Pillars_Backend_PL.DTOs;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3Pillars_Backend_PL.Helpers
{
    public class PhotoUrlResolver : IValueResolver<AddressBook, AddressBookDTO, string>
    {
        public IConfiguration Configuration { get; }

        public PhotoUrlResolver(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string Resolve(AddressBook source, AddressBookDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Photo))
                return $"{Configuration["ApiUrl"]}{source.Photo}";
            return null;
        }
    }
}
