using _3Pillars_Backend_DAL.Entities;
using _3Pillars_Backend_DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace _3Pillars_Backend_DAL.Data
{
    public class AddressBookContext : IdentityDbContext<User, IdentityRole,string>
    {
        public AddressBookContext(DbContextOptions<AddressBookContext> options) :base(options)
        {
            
        }
        public DbSet<AddressBook> addressBooks { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Job> jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
