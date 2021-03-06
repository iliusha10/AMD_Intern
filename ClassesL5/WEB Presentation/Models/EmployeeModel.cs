﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Domain;
using Domain.Persons;
using Domain.Row;

namespace WEB_Presentation.Models
{
    public class EmployeeModel : ContractorModel
    {
        public EmployeeModel(Employee emp) : base(emp)
        {
            Department = emp.Department;
            Role = emp.Role;
        }

        public EmployeeModel()
        {
        }

        public EmployeeModel(IList<SelectListItem> companies)
        {
            PersonType = PersonType.Employee;
            BirthDate = DateTime.Now.Date;
            Companies = companies;
        }


        [Required(ErrorMessage = "Department is required")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$",
            ErrorMessage = "First letter should be uppercase and only letters accepted")]
        public string Department { get; set; }

        [Display(Name = "Function")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$",
            ErrorMessage = "First letter should be uppercase and only letters accepted")]
        [Required(ErrorMessage = "Function is required")]
        public string Role { get; set; }


        internal void ConvertToDto(EmployeeDetailsDto newEmployee)
        {
            newEmployee.Id = Id;
            newEmployee.PersonType = PersonType;
            newEmployee.Firstname = Firstname;
            newEmployee.Lastname = Firstname;
            newEmployee.BirthDate = BirthDate;
            newEmployee.City = City;
            newEmployee.Street = Street;
            newEmployee.Salary = Salary;
            newEmployee.WorkExp = WorkExp;
            newEmployee.CompanyId = CompanyId;
            newEmployee.Department = Department;
            newEmployee.Role = Role;
        }
    }
}