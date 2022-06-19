using Assignment2.Models;
using Assignment2.MyContext;
using Assignment2.Repositotries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    public class TrainerController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        private TrainerRepository trainerRepository;

        public TrainerController()
        {
            trainerRepository = new TrainerRepository(db);
        }

        /// <summary>
        /// Action Method to Display all the Trainers in the Index View
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var trainers = trainerRepository.GetAll();
            return View(trainers);
        }

        /// <summary>
        /// Action Method to Display Trainer Details in Details View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var trainer = trainerRepository.GetById(id);
            if (trainer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }


            return View(trainer);
        }


        /// <summary>
        /// ActionResult HttpGet Method to display the Create form View 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        /// <summary>
        /// ActionResult HttpPost Method to add a new Trainer in the Database
        /// </summary>
        /// <param name="trainer"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                trainerRepository.Add(trainer);
                AlertMessage("Trainer was successfully Created!");
                return RedirectToAction("Index");
                
            }

            return View(trainer);
        }

        /// <summary>
        /// ActionRestult HttpGet Method to display the Delete view with the details of the selected Trainer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            var trainer = trainerRepository.GetById(id);

            return View(trainer);
        }

        /// <summary>
        ///ActionRestult HttpPost Method to Delete the selected Trainer for the Database 
        /// </summary>
        /// <param name="trainer"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Trainer trainer)
        {
            trainerRepository.Delete(trainer);
            AlertMessage("Trainer was successfuly Deleted.");
            return RedirectToAction("Index");
        }

        /// <summary>
        /// ActionResult HttpGet Method to display the selected Trainer in the Edit form View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var trainer = trainerRepository.GetById(id);
            if(trainer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(trainer);
        }

        /// <summary>
        /// ActionResult HttPost Method to update the Trainer's new Information in Database
        /// </summary>
        /// <param name="trainer"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                trainerRepository.Edit(trainer);
                AlertMessage("Trainer was successcfully Updated!");
                return RedirectToAction("index");
            }

            return View();
            
        }

        /// <summary>
        /// NonAction Method to display massages 
        /// </summary>
        /// <param name="message"></param>
        [NonAction]
        public void AlertMessage(string message)
        {
            TempData["message"] = message;

        }


    }
}