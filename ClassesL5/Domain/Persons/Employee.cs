using System;
using System.Collections.Generic;
using Domain.CompanyAssets;
using Domain.Interfaces;

namespace Domain.Persons
{
    public class Employee : Contractor, IPrivileges
    {
        public Employee(string fName, string lName, string bdate, Dictionary<string, int> skillsDictionary,
            Address address, Company company, double workexp, double salary,
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

        public virtual string Department { get; protected set; }
        public virtual string Role { get; protected set; }

        public new virtual void AddPrivilege()
        {
            Console.WriteLine("Privileges:");
        }

        //public virtual double calcBonus(double salary)
        //{
        //    return salary + (salary*0.04);
        //}

        public virtual void DisplayAll()
        {
            Console.WriteLine("Employee:");
            DisplayPersonInfo();
            Console.WriteLine("Work Experience: {0}", WorkExp);
            //Console.WriteLine("Salary: {0}", Salary);
            //Console.WriteLine("Salary + Bonus: {0}", calcBonus(Salary));
            //Console.WriteLine("Department: {0}", Department);
            Console.WriteLine();
        }

        public virtual bool HasAcces()
        {
            return true;
        }
    }
}