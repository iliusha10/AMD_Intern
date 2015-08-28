using System;
using Domain.Interfaces;

namespace Domain.Domain
{
    public class Contractor : Person, IPrivileges
    {
        protected readonly double WorkExp;
        //private string contractorCompany = "contractorCompany";

        public Contractor(string fname, string lname, int bdate, int bmonth, int byear, double salary, Company company,
            double workexp)
            : base(fname, lname, bdate, bmonth, byear, salary)
        {
            if (workexp <= 0)
                throw new ArgumentException("Work expirience must be positive.");
            //if (salary <= 0)
                //throw new ArgumentException("Salary must be positive.");
            WorkExp = workexp;
        }

        /*public override string GetCompanyName()
        {
            company = "contractorCompany";
            //Console.WriteLine("Contractor / GetCompanyName()");
            return company;
        }*/

        //public virtual double calcBonus(double salary)
        //{
        //    double calcbonus;
        //    return calcbonus = salary + (salary*0.02);
        //}

        public override void DisplayAll()
        {
            Console.WriteLine();
            Console.WriteLine("Contractor:");
            DisplayPersonInfo();
            //Console.WriteLine("Company: {0}", GetCompanyName());
            Console.WriteLine("Salary: {0}", Salary);
            //Console.WriteLine("Salary + Bonus: {0}", calcBonus(Salary));
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