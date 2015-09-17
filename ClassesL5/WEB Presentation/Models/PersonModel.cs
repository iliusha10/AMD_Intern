using System;
using System.ComponentModel.DataAnnotations;
using Domain.Persons;

namespace WEB_Presentation.Models
{
    public abstract class PersonModel
    {
        //public PersonModel(PersonModel pers)
        //{
        //    Id = pers.Id;
        //    Firstname = pers.Firstname;
        //    Lastname = pers.Lastname;
        //    BirthDate = pers.BirthDate;
        //}

        public PersonModel(Person pers)
        {
            Id = pers.Id;
            Firstname = pers.FName;
            Lastname = pers.LName;
            BirthDate = pers.DateOfBirth;
        }

        public PersonModel()
        {
            
        }
        public long Id { get; set; }

        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
    }
}