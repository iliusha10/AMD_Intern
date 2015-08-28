﻿using System;
using Domain.Interfaces;

namespace Domain.Domain
{
    public class Employee : Contractor, IPrivileges
    {
        
        public Employee(string fname, string lname, string bdate, Company company, double workexp,
            double salary, string department)
            : base(fname, lname, bdate, company, workexp, salary)
        {
            if (string.IsNullOrWhiteSpace(department))
                throw new ArgumentException("department is required.");
            Department = department;
        }

        public string Department { get; protected set; }

        public override double calcBonus(double salary)
        {
            return salary + (salary*0.04);
        }

        public override void DisplayAll()
        {
            Console.WriteLine("Employee:");
            DisplayPersonInfo();
            Console.WriteLine("Work Experience: {0}", WorkExp);
            Console.WriteLine("Salary: {0}", Salary);
            Console.WriteLine("Salary + Bonus: {0}", calcBonus(Salary));
            //Console.WriteLine("Department: {0}", Department);
            Console.WriteLine();
        }

        public new void AddPrivilege()
        {
            Console.WriteLine("Privileges:");
        }

        public override bool HasAcces()
        {
            return true;
        }
    }
}