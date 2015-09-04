using System;
using System.Collections.Generic;
using Domain.Company;

namespace Domain.Persons
{
    public class Intern : Person
    {
        public Intern(string fName, string lName, string bdate, Dictionary<string, int> skillsDictionary,
            Address address, Company.Company company, double avmark)
            : base(fName, lName, bdate, skillsDictionary, address, company)
        {
            AverageMark = avmark;
        }

        [Obsolete]
        protected Intern()
        {
        }

        public virtual double AverageMark { get; protected set; }


        public virtual void DisplayAll()
        {
            Console.WriteLine("Intern:");
            DisplayPersonInfo();
            Console.WriteLine("Company: {0}", Company);
            Console.WriteLine("Average Mark: {0}", AverageMark);
            Console.WriteLine();
        }
    }
}