namespace Assignment2.Migrations
{
    using Assignment2.Models;
    using Assignment2.Models.Enums;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment2.MyContext.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Assignment2.MyContext.ApplicationContext context)
        {

        }
    }
}
