using System;
using Domain.Interfaces;

namespace Domain.Domain
{
    public class Intern : Person, IPrivileges
    {
        public readonly double AverageMark;
        public Company Company { get; set; }


        public Intern(string fname, string lname, int bdate, int bmonth, int byear, double salary, double avmark, Company company)
            : base(fname, lname, bdate, bmonth, byear, salary)
        {
            AverageMark = avmark;
            Company = company;
        }


        public double AverMark
        {
            get { return AverageMark; }
        }

        
        public override void DisplayAll()
        {
            Console.WriteLine();
            Console.WriteLine("Intern:");
            DisplayPersonInfo();
            Console.WriteLine("Company: {0}", Company);
            Console.WriteLine("Average Mark: {0}", AverageMark);
            
        }

        public void AddPrivilege()
        {
            Console.WriteLine("Priveleges:");
        }

        
    }
}