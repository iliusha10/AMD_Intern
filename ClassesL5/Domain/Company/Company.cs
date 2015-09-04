using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Persons;

namespace Domain.Company
{
    public class Company : Entity
    {
        public Company(string name, FieldOfActivity activity, string address,
            Dictionary<string, string> projectDictionary)
        {
            CompanyName = name;
            Activity = activity;
            Address = address;
            ProjectList = projectDictionary.Select(x => new Project(this, x.Key, x.Value)).ToList();

        }

        public virtual int CompanyId { get; protected set; }
        public virtual FieldOfActivity Activity { get; protected set; }
        public virtual string CompanyName { get; protected set; }
        public virtual string Address { get; protected set; }
        public virtual IList<Project> ProjectList { get; protected set; }
        public virtual Person Person { get; protected set; }

        [Obsolete]
        protected Company()
        {
        }

        public virtual string ToString()
        {
            return CompanyName;
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

        public virtual void Rename(string name)
        {
            CompanyName = name;
            Console.WriteLine("Renaming company");
        }

        public virtual void ChangeFieldofActivity(FieldOfActivity activity)
        {
            Activity = activity;
            Console.WriteLine("Changing Field of Activity");
        }
    }
}