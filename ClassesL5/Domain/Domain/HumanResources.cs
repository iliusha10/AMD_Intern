using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;

namespace Domain.Domain
{
    public class HumanResources : INotify
    {

        public void Inform(Project p)
        {
            Console.WriteLine("HumanResources: We have only 3 free employee for this project!");
        }

        public List<Intern> Hire(List<Intern> interns)
        {
            var hired = interns.Where(x => x.AverMark >= 8).ToList();
            return hired;
        }

        public void IsAbsent(string nume, bool isMotivatedAbsence = true, string cause = "Unknown")
        {
            string text;
            if (isMotivatedAbsence) text = " ";
            else text = " not ";
            Console.WriteLine("{0} is absent{1}motivated. Cause: {2}", nume, text, cause);
        }
    }
}