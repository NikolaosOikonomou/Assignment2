using Assignment2.Models;
using Assignment2.MyContext.Initializers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment2.MyContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("Sindesmos")
        {
            Database.SetInitializer<ApplicationContext>(new MockupDbInitializer());
            Database.Initialize(false);
        }

        public DbSet<Trainer> Trainers { get; set; }
    }
}