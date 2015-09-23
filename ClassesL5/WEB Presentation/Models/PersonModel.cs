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
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "First letter should be uppercase and only letters accepted")]
        [Required(ErrorMessage = "First Name is required")]
        public string Firstname { get; set; }

        [Display(Name = "Last name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "First letter should be uppercase and only letters accepted")]
        [Required(ErrorMessage = "Last Name is required")]
        public string Lastname { get; set; }

        [Display(Name = "Birth date")]
        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Street is required")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City is required")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "First letter should be uppercase and only letters accepted")]
        public string City { get; set; }

        [Display(Name = "Company name")]
        public string CompanyName { get; set; }
        public long CompanyId { get; set; }
        public IList<SelectListItem> Companies { get; set; }
    }
}