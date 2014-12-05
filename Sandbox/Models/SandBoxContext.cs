using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sandbox.Models
{
    public class SandBoxContext : DbContext
    {
        public SandBoxContext() : base("name=DefaultConnection")
        { 
        
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }    

    }
}