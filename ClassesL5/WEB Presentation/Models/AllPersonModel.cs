using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain;

namespace WEB_Presentation.Models
{
    public class AllPersonModel
    {
        public long Id { get; set; }

        [Display(Name = "Person Type")]
        public PersonType PersonType { get; set; }

        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Average Mark")]
        public double AverageMark { get; set; }

        public virtual double Salary { get; set; }

        [Display(Name = "Work Experience")]
        public virtual double WorkExp { get; set; }

        public string Department { get; set; }

        [Display(Name = "Function")]
        public string Role { get; set; }

        //public string JS { get; set; }
    }
}