using System;
using System.Collections.Generic;
using Domain.Company;
using Domain.Persons;
using Factories.Factories;
using Infrastructure.IoC;

namespace ClassesL5
{
    public class InternGenerator
    {
        private static readonly InternFactory InternFactory = ServiceLocator.Get<InternFactory>();

        public static IList<Intern> CreateNewInterns(int number, Company comp)
        {
            var internList = new List<Intern>();

            //for (int i = 0; i < number; i++)
            //{
            //    //var intern = InternFactory.CreateIntern(String.Format("Intern {0}", i + 1), "Smith", i + 3, i + 1,
            //    //    i + 1990, i + 1, comp);
            //    internList.Add(new Intern());
            //}
            return internList;
        }
    }
}