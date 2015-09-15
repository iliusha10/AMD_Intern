using System;
using System.Collections.Generic;
using Domain.Persons;

namespace Domain.CompanyAssets
{
    public class Company : Entity
    {
        public Company(string name, FieldOfActivity activity, Address address)
        {
            CompanyName = name;
            Activity = activity;
            Address = address;
            ProjectList = new List<Project>();
            PersonList = new List<Person>();
        }

        [Obsolete]
        protected Company()
        {
        }

        public virtual FieldOfActivity Activity { get; protected set; }
        public virtual string CompanyName { get; protected set; }
        public virtual Address Address { get; protected set; }
        public virtual IList<Project> ProjectList { get; protected set; }
        public virtual IList<Person> PersonList { get; protected set; }

        public virtual string ToString()
        {
            return CompanyName;
        }

        public virtual void AddProject(Project project)
        {
            ProjectList.Add(project);
        }


        public virtual void AddPerson(Person person)
        {
            PersonList.Add(person);
        }

        //public static void JobValidation(Intern intern)
        //{
        //    //if (intern.workExp < 2)
        //    //{
        //    //    InternValidationException exc1 = new InternValidationException(intern.LName, "Not enough work experience");
        //    //    //Console.WriteLine("static public void JobValidation(Intern intern)");
        //    //    throw exc1;

        //    //}

        //    //if (intern.Age < 16)
        //    //{
        //    //    InternValidationException exc2 = new InternValidationException(intern.LName, "Too young to work");
        //    //    throw exc2;
        //    //}

        //    if (intern.AverageMark < 8)
        //    {
        //        InternValidationException exc2 = new InternValidationException(intern.LName, "Average mark is too small");
        //        throw exc2;
        //    }
        //}

        public virtual void DisplayAll()
        {
            Console.WriteLine();
            //CompanyAddress adress = CompanyAddress.Address;
            //Console.WriteLine("{2} Company {0}: {1} - {3} {4}", CompanyId, CompanyName, Activity, adress.Street,
            //    adress.City);
        }

        public virtual void ChangeData(Company company, string name, FieldOfActivity activity, string city,
            string street)
        {
            company.CompanyName = name;
            company.Activity = activity;
            if ((company.Address.City != city) || (company.Address.Street != street))
            {
                var address = new Address(street, city);
                company.Address = address;
            }
        }

        public virtual void ChangeFieldofActivity(FieldOfActivity activity)
        {
            Activity = activity;
        }
    }
}