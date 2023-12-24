using AutoMapper;
using _3Pillars_Backend_DAL.Entities;
using _3Pillars_Backend_PL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3Pillars_Backend_PL.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Mapprer with AddessBook and AddressBookDTO 
            CreateMap<AddressBook, AddressBookDTO>()
               .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.Department.Name)) // DepartmentName
               .ForMember(d => d.JobName, o => o.MapFrom(s => s.Job.Name))              // JobName
               .ForMember(d => d.PhotoUrl, o => o.MapFrom<PhotoUrlResolver>());        // Photo

            CreateMap<AddressBookDTO, AddressBook>();                                 // Mapper With AddressBook and AddressBookDTO 
            CreateMap<Department, DepartmentDTO>().ReverseMap();                     // Mapper With Department and DepartmentDTO 
            CreateMap<Job, JobDTO>().ReverseMap();                                  // Mapper With Job and JobDTO 
        }


    }
}
