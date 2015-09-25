using System;
using System.Collections.Generic;
using Domain.CompanyAssets;
using Domain.Interfaces;
using Domain.Row;

namespace Domain.Persons
{
    public class Employee : Contractor, IPrivileges
    {
        public Employee(string fName, string lName, DateTime bdate, Dictionary<string, int> skillsDictionary,
            Address address, Company company, double workexp, Salary salary,
            string department, string role)
            : base(fName, lName, bdate, skillsDictionary,  address, company, workexp, salary)
        {
            if (string.IsNullOrWhiteSpace(department))
                throw new ArgumentException("department is required.");
            Department = department;
            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("department is required.");
            Role = role;
        }

        [Obsolete]
        protected Employee()
        {
        }

        public override PersonType PersonType
        {
            get { return PersonType.Employee; }
        }

        public virtual string Department { get; protected set; }
        public virtual string Role { get; protected set; }

        public new virtual void AddPrivilege()
        {
            Console.WriteLine("Privileges:");
        }

        public virtual void DisplayAll()
        {
            Console.WriteLine("Employee:");
            DisplayPersonInfo();
            Console.WriteLine("Work Experience: {0}", WorkExp);
            Console.WriteLine();
        }

        public virtual bool HasAcces()
        {
            return true;
        }

        public virtual void UpdateDataEmp(EmployeeDetailsDto newEmployee, Company newcompany)
        {
            //PersonType = newintern.PersonType;
            FName = newEmployee.Firstname;
            LName = newEmployee.Lastname;
            DateOfBirth = newEmployee.BirthDate;
            Company = newcompany;
            //Salary.Amount = newcontractor.Salary;
            WorkExp = newEmployee.WorkExp;
            Role = newEmployee.Role;
            Department = newEmployee.Department;

        }
    }
}