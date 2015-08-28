using System;
using Domain.Exceptions;

namespace Domain.Domain
{
    public class Company
    {
        public Company(int companyId, string name, FieldOfActivity activity, string street, string city)
        {
            CompanyAddress adress = CompanyAddress.Address;
            adress.SetCity(city);
            adress.SetStreet(street);
            CompanyName = name;
            Activity = activity;
            CompanyId = companyId;
        }

        public override string ToString()
        {
            return CompanyName;
        }

        public int CompanyId { get; private set; }
        public FieldOfActivity Activity { get; private set; }
        public string CompanyName { get; private set; }


        public static void JobValidation(Intern intern)
        {
            //if (intern.workExp < 2)
            //{
            //    InternValidationException exc1 = new InternValidationException(intern.LName, "Not enough work experience");
            //    //Console.WriteLine("static public void JobValidation(Intern intern)");
            //    throw exc1;

            //}

            //if (intern.Age < 16)
            //{
            //    InternValidationException exc2 = new InternValidationException(intern.LName, "Too young to work");
            //    throw exc2;
            //}

            if (intern.AverMark < 8)
            {
                InternValidationException exc2 = new InternValidationException(intern.LName, "Average mark is too small");
                throw exc2;
            }
        }

        public void DisplayAll()
        {
Console.WriteLine();
            CompanyAddress adress = CompanyAddress.Address;
            Console.WriteLine("{2} Company {0}: {1} - {3} {4}", CompanyId, CompanyName, Activity, adress.Street,
                adress.City);
        }
    }
}