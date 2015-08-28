using System;
using Domain.Interfaces;

namespace Domain.Domain
{
    public class Intern : Person, IPrivileges
    {
        [Obsolete]
        protected Intern()
        {
        }

        public Intern(string fname, string lname, string bdate, double avmark, Company company)
            : base(fname, lname, bdate)
        {
            AverageMark = avmark;
            Company = company;
        }

        public virtual Company Company { get; protected set; }
        public virtual double AverageMark { get; protected set; }

        public virtual void DisplayAll()
        {
            Console.WriteLine("Intern:");
            DisplayPersonInfo();
            Console.WriteLine("Company: {0}", Company);
            Console.WriteLine("Average Mark: {0}", AverageMark);
            Console.WriteLine();
        }

        public virtual void AddPrivilege()
        {
            Console.WriteLine("Priveleges:");
            Console.WriteLine();
        }
    }
}