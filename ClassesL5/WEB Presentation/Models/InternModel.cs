using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Domain;
using Domain.Persons;
using Domain.Row;

namespace WEB_Presentation.Models
{
    public class InternModel : PersonModel
    {
        public InternModel(Intern pers)
        {
            PersonType = pers.PersonType;
            BirthDate = pers.DateOfBirth;
            Firstname = pers.FName;
            Id = pers.Id;
            Lastname = pers.LName;
            AverageMark = pers.AverageMark;
            City = pers.Address.City;
            Street = pers.Address.Street;
            CompanyName = pers.Company.CompanyName;
        }

        public InternModel(IList<SelectListItem> companies)
        {
            PersonType = PersonType.Intern;
            BirthDate = DateTime.Now.Date;
            Companies = companies;
        }

        public InternModel()
        {
        }


        [Display(Name = "Average mark")]
        [Required(ErrorMessage = "Average mark is required")]
        [Range(1, 100, ErrorMessage = "Average mark must be between $1 and $100")]
        public double AverageMark { get; set; }

        internal void ConvertToDto(InternDetailsDto newinterndto)
        {
            newinterndto.Id = Id;
            newinterndto.PersonType = PersonType;
            newinterndto.Firstname = Firstname;
            newinterndto.Lastname = Firstname;
            newinterndto.BirthDate = BirthDate;
            newinterndto.City = City;
            newinterndto.Street = Street;
            newinterndto.AverageMark = AverageMark;
            newinterndto.CompanyId = CompanyId;
        }
    }
}