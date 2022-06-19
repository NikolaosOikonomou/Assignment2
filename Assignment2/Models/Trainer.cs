using Assignment2.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        [DisplayName("Firstname")]
        [Required(ErrorMessage ="Firstname Is Required")]
        public string FirstName { get; set; }


        [DisplayName("Lastname")]
        [Required(ErrorMessage = "Lastname Is Required")]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public Subject? Subject { get; set; }

    }
}