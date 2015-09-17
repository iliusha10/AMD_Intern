using System;
using System.ComponentModel.DataAnnotations;

namespace WEB_Presentation.Models
{
    public class PersonModel
    {
        public long Id { get; set; }

        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
    }
}