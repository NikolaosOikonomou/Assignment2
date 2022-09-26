using Assignment2.Models;
using Assignment2.MyContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment2.Repositotries
{
    /// <summary>
    ///All the methods which interacts with the database
    /// </summary>
    public class TrainerRepository
    {
        private ApplicationContext db;

        public TrainerRepository(ApplicationContext context)
        {
            db = context;
        }

        public List<Trainer> GetAll()
        {
            var trainers = db.Trainers.ToList();
            return trainers;
        }

        public Trainer GetById(int? id)
        {
            var trainer = db.Trainers.Find(id);
            return trainer;
        }

        public void Add(Trainer trainer)
        {
            db.Entry(trainer).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(Trainer trainer)
        {
            db.Entry(trainer).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Trainer trainer)
        {
            db.Entry(trainer).State = EntityState.Deleted;
            db.SaveChanges();
        }

    }
}