using System;
using System.Collections.Generic;
using Domain.CompanyAssets;
using Domain.Row;

namespace Domain.Persons
{
    public class Intern : Person
    {
        public Intern(string fName, string lName, DateTime bdate, Dictionary<string, int> skillsDictionary,
            Address address, Company company, double avmark)
            : base(fName, lName, bdate, skillsDictionary, address, company)
        {
            AverageMark = avmark;
        }

        [Obsolete]
        protected Intern()
        {
        }

        public virtual double AverageMark { get; protected set; }


        public override PersonType PersonType
        {
            get { return PersonType.Intern; }
        }

        public virtual void DisplayAll()
        {
            Console.WriteLine("Intern:");
            DisplayPersonInfo();
            Console.WriteLine("Company: {0}", Company);
            Console.WriteLine("Average Mark: {0}", AverageMark);
            Console.WriteLine();
        }

        public virtual void UpdateData(InternDetailsDto newintern, Company company)
        {
            //PersonType = newintern.PersonType;
            FName = newintern.Firstname;
            LName = newintern.Lastname;
            DateOfBirth = newintern.BirthDate;
            Company = company;
            AverageMark = newintern.AverageMark;

        }
    }
}