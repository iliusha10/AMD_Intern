using System;
using System.Collections.Generic;
using Domain.Interfaces;

namespace Domain.Domain
{
    public class Intern : Person, IPrivileges
    {
        public Intern(string fName, string lName, string bdate, Dictionary<string, int> skillsDictionary,
            IList<Privileges.Privileges> privilegeList, Address address, Company company, double avmark)
            : base(fName, lName, bdate, skillsDictionary, privilegeList, address, company)
        {
            AverageMark = avmark;
        }

        [Obsolete]
        protected Intern()
        {
        }

        public virtual double AverageMark { get; protected set; }

        public virtual void AddPrivilege()
        {
            Console.WriteLine("Priveleges:");
            Console.WriteLine();
        }

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