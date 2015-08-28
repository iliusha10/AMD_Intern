using System;
using Domain.Interfaces;

namespace Domain.Domain
{
    public class Employee : Contractor, IPrivileges
    {
        public string Department { get; set; }

        public Employee(string fname, string lname, int bdate, int bmonth, int byear, double salary, Company company, double workexp,
            string department)
            : base(fname, lname, bdate, bmonth, byear, salary, company, workexp)
        {
            if (string.IsNullOrWhiteSpace(department))
                throw new ArgumentException("department is required.");
            Department = department;
        }


        //public override double calcBonus(double salary)
        //{
        //    return salary + (salary*0.04);
        //}

        public override void DisplayAll()
        {
            Console.WriteLine();
            Console.WriteLine("Employee:");
            DisplayPersonInfo();
            Console.WriteLine("Work Experience: {0}", WorkExp);
            Console.WriteLine("Salary: {0}", Salary);
            //Console.WriteLine("Salary + Bonus: {0}", calcBonus(Salary));
            Console.WriteLine("Department: {0}", Department);
        }

        public void AddPrivilege()
        {
            Console.WriteLine("Privileges:");
        }

        public override bool HasAcces()
        {
            return true;
        }
    }
}