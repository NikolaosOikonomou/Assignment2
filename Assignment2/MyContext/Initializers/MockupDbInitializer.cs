using Assignment2.Models;
using Assignment2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Assignment2.MyContext.Initializers
{
    public class MockupDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            #region Trainers Seeding
            Trainer t1 = new Trainer() { FirstName = "Hector", LastName = "Mpompas", Age =36, Subject = Subject.JavaScript };
            Trainer t2 = new Trainer() { FirstName = "Paulos", LastName = "Soumelas", Age = 41, Subject = Subject.Java };
            Trainer t3 = new Trainer() { FirstName = "Nikos", LastName = "Fousekis", Age = 46, Subject = Subject.Css };
            Trainer t4 = new Trainer() { FirstName = "Panos", LastName = "Mpozas", Age = 34, Subject = Subject.Html };
            Trainer t5 = new Trainer() { FirstName = "Aliki", LastName = "Koukouza", Age = 33, Subject = Subject.Python };

            context.Trainers.AddOrUpdate(x => x.FirstName, t1, t2, t3, t4, t5);
            context.SaveChanges();

            #endregion

            base.Seed(context);
        }
    }
}