using System;
using System.Collections.Generic;

namespace Domain.Domain
{
    public class Intern : Person
    {
        public readonly double AverageMark;
        public Company Company { get; set; }


        public Intern(string fname, string lname, string bdate, double avmark, Company company)
            : base(fname, lname, bdate)
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
            Console.WriteLine("Intern:");
            DisplayPersonInfo();
            Console.WriteLine("Company: {0}", Company);
            Console.WriteLine("Average Mark: {0}", AverageMark);
            Console.WriteLine();
        }
    }
}