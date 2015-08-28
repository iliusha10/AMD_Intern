using System;
using System.Collections.Generic;

namespace Domain.Domain
{
    public class Contractor : Person, IPrivileges
    {
        protected readonly double WorkExp;
        private string contractorCompany = "contractorCompany";

        public Contractor(string fname, string lname, string bdate, Company company, double workexp,
            double salary)
            : base(fname, lname, bdate)
        {
            if (workexp <= 0)
                throw new ArgumentException("Work expirience must be positive.");
            if (salary <= 0)
                throw new ArgumentException("Salary must be positive.");
            WorkExp = workexp;
            Salary = salary;
        }

        public double Salary { get; private set; }

        /*public override string GetCompanyName()
        {
            company = "contractorCompany";
            //Console.WriteLine("Contractor / GetCompanyName()");
            return company;
        }*/

        public virtual double calcBonus(double salary)
        {
            double calcbonus;
            //Console.WriteLine("Salary = {0}", salary);
            //Console.WriteLine("Salary + Bonus = {0}", salary + (salary * 0.2));
            return calcbonus = salary + (salary*0.02);
        }

        public override void DisplayAll()
        {
            Console.WriteLine("Contractor:");
            DisplayPersonInfo();
            //Console.WriteLine("Company: {0}", GetCompanyName());
            Console.WriteLine("Salary: {0}", Salary);
            Console.WriteLine("Salary + Bonus: {0}", calcBonus(Salary));
            Console.WriteLine();
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