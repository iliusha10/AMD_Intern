using System;
using System.Collections.Generic;
using Domain.Company;
using Domain.Interfaces;

namespace Domain.Persons
{
    public class Contractor : Person, IPrivileges
    {
        public Contractor(string fName, string lName, string bdate, Dictionary<string, int> skillsDictionary,
            Address address, Company.Company company, double workexp, double salary)
            : base(fName, lName, bdate, skillsDictionary, address, company)
        {
            if (workexp <= 0)
                throw new ArgumentException("Work expirience must be positive.");

            WorkExp = workexp;
            Salary = new Salary(this, salary, 0.0);
        }

        [Obsolete]
        protected Contractor()
        {
        }

        public virtual Salary Salary { get; protected set; }
        public virtual double WorkExp { get; protected set; }

        public virtual void AddPrivilege()
        {
            Console.WriteLine("Privileges:");
        }

        //public virtual double calcBonus(double salary)
        //{
        //    double calcbonus;
        //    //Console.WriteLine("Salary = {0}", salary);
        //    //Console.WriteLine("Salary + Bonus = {0}", salary + (salary * 0.2));
        //    return calcbonus = salary + (salary*0.02);
        //}

        public new virtual void DisplayAll()
        {
            Console.WriteLine("Contractor:");
            DisplayPersonInfo();
            //Console.WriteLine("Company: {0}", GetCompanyName());
            //Console.WriteLine("Salary: {0}", Salary);
            //Console.WriteLine("Salary + Bonus: {0}", calcBonus(Salary));
            Console.WriteLine();
        }

        public new virtual bool HasAcces()
        {
            return true;
        }
    }
}