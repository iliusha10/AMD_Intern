using System;
using System.Collections.Generic;
using Domain.CompanyAssets;
using Domain.Interfaces;

namespace Domain.Persons
{
    public class Contractor : Person, IPrivileges
    {
        public Contractor(string fName, string lName, string bdate, Dictionary<string, int> skillsDictionary,
            Address address, Company company, double workexp, double salary)
            : base(fName, lName, bdate, skillsDictionary, address, company)
        {
            if (workexp <= 0)
                throw new ArgumentException("Work expirience must be positive.");

            WorkExp = workexp;
            Salary = new Salary(this, salary, 0.0);
            taskList = new List<Task>();
        }

        [Obsolete]
        protected Contractor()
        {
        }

        public virtual Salary Salary { get; protected set; }
        public virtual double WorkExp { get; protected set; }
        public virtual IList<Task> taskList { get; protected set; }

        public override PersonType PersonType
        {
            get { return PersonType.Contractor; }
        }

        public virtual void AddPrivilege()
        {
            Console.WriteLine("Privileges:");
        }


        public new virtual void DisplayAll()
        {
            Console.WriteLine("Contractor:");
            DisplayPersonInfo();
            Console.WriteLine();
        }

        public new virtual bool HasAcces()
        {
            return true;
        }
    }
}