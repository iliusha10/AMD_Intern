using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Domain;
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

        [Display(Name = "Person type")]
        public PersonType PersonType { get; set; }

        [Display(Name = "First name")]
        public string Firstname { get; set; }

        [Display(Name = "Last name")]
        public string Lastname { get; set; }

        [Display(Name = "Birth date")]
        public DateTime BirthDate { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        [Display(Name = "Company name")]
        public string CompanyName { get; set; }
        public long CompanyId { get; set; }
        public IList<SelectListItem> Companies { get; set; }
    }
}