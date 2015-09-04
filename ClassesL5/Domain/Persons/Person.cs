using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Company;
using Domain.Interfaces;
using Domain.Privileges;

namespace Domain.Persons
{
    public class Person : Entity, IPrivileges
    {
        //public Person(string fName, string lName, string bdate)
        //{
        //    if (string.IsNullOrWhiteSpace(fName))
        //        throw new ArgumentException("First name is required.");
        //    if (string.IsNullOrWhiteSpace(lName))
        //        throw new ArgumentException("Last name is required.");

        //    FName = fName;
        //    LName = lName;

        //    try
        //    {
        //        DateOfBirth = DateTime.Parse(bdate);
        //    }
        //    catch (ArgumentOutOfRangeException e)
        //    {
        //        Console.Write(LName);
        //        throw new ArgumentOutOfRangeException("Birthdate is out of range.", e);
        //    }
        //}

        public Person(string fName, string lName, string bdate, Dictionary<string, int> skillsDictionary,
            Address address, Company.Company company)
        {
            if (string.IsNullOrWhiteSpace(fName))
                throw new ArgumentException("First name is required.");
            if (string.IsNullOrWhiteSpace(lName))
                throw new ArgumentException("Last name is required.");
            FName = fName;
            LName = lName;
            try
            {
                DateOfBirth = DateTime.Parse(bdate);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Write(LName);
                throw new ArgumentOutOfRangeException("Birthdate is out of range.", e);
            }

            SkillsList = skillsDictionary.Select(x => new PersonSkills(this, x.Key, x.Value)).ToList();
            PrivilegeList = new List<PersonPrivilege>();
            Address = address;
            Company = company;
        }


        [Obsolete]
        protected Person()
        {
        }

        public virtual string FName { get; protected set; }
        public virtual string LName { get; protected set; }
        public virtual DateTime DateOfBirth { get; protected set; }
        public virtual IList<PersonSkills> SkillsList { get; protected set; }
        public virtual IList<PersonPrivilege> PrivilegeList { get; protected set; }
        public virtual Address Address { get; protected set; }
        public virtual Company.Company Company { get; protected set; }

        public override string ToString()
        {
            return string.Format("{0, -15} {1, -15} {2, -15}", FName, LName, DateOfBirth);
        }

        public virtual void AddPrivilege()
        {
            
        }

        public virtual bool HasAcces()
        {
            return false;
        }

        //public virtual int Age
        //{
        //    get { return DateTime.Now.Year - _dateOfBirth.Year; }
        //    protected set {} ;
        //}

        protected virtual void DisplayPersonInfo()
        {
            Console.WriteLine("Name: {0} {1}", FName, LName);
            Console.WriteLine("Birth Date: " + DateOfBirth.ToString("dd/MM/yyyy") + ".");
            //Console.WriteLine("Age: {0}", Age);
            //Console.WriteLine();
            //Console.WriteLine("Skills: ");
            //ShowSkills();
        }

        public virtual void DisplayMainInfo()
        {
            DisplayPersonInfo();

            Console.WriteLine();
        }


        public virtual void DisplayAll()
        {
            //Console.WriteLine("Age: {0}", Age);
            DisplayPersonInfo();
        }


        public virtual void Rename(string fname, string lname)
        {
            FName = fname;
            LName = lname;
            Console.WriteLine("Renaming person");
        }

        public virtual void ChangeBDate(string date)
        {
            DateOfBirth = DateTime.Parse(date);
            Console.WriteLine("Changing birth date");
        }
    }
}