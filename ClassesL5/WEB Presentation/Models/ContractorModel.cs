using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Domain;
using Domain.Persons;
using Domain.Row;

namespace WEB_Presentation.Models
{
    public class ContractorModel : PersonModel
    {
        public ContractorModel(Contractor cont) : base(cont)
        {
            PersonType = cont.PersonType;
            City = cont.Address.City;
            Street = cont.Address.Street;
            CompanyName = cont.Company.CompanyName;
            Salary = cont.Salary.Amount;
            WorkExp = cont.WorkExp;
        }

        public ContractorModel()
        {
        }


        public ContractorModel(IList<SelectListItem> companies)
        {
            PersonType = PersonType.Contractor;
            BirthDate = DateTime.Now.Date;
            Companies = companies;
        }

        [Required(ErrorMessage = "Salary is required")]
        public virtual double Salary { get; set; }

        [Display(Name = "Work experience")]
        [Range(1, 100, ErrorMessage = "Work experience must be between $1 and $100")]
        [Required(ErrorMessage = "Work experience is required")]
        public virtual double WorkExp { get; set; }

        internal void ConvertToDto(ContractorDetailsDto newContractor)
        {
            newContractor.Id = Id;
            newContractor.PersonType = PersonType;
            newContractor.Firstname = Firstname;
            newContractor.Lastname = Firstname;
            newContractor.BirthDate = BirthDate;
            newContractor.City = City;
            newContractor.Street = Street;
            newContractor.Salary = Salary;
            newContractor.WorkExp = WorkExp;
            newContractor.CompanyId = CompanyId;
        }
    }
}