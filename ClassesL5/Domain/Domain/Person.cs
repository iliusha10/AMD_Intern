using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Domain
{
    public class Person : Entity
    {
        public Person(string fName, string lName, string bdate)
        {
            if (string.IsNullOrWhiteSpace(fName))
                throw new ArgumentException("First name is required.");
            if (string.IsNullOrWhiteSpace(lName))
                throw new ArgumentException("Last name is required.");

            FName = fName;
            LName = lName;

            try
            {
                _dateOfBirth = DateTime.Parse(bdate);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Write(LName);
                throw new ArgumentOutOfRangeException("Birthdate is out of range.", e);
            }
        }

        public Person(string fName, string lName, string bdate, Dictionary<string, int> skillsDictionary)
        {
            if (string.IsNullOrWhiteSpace(fName))
                throw new ArgumentException("First name is required.");
            if (string.IsNullOrWhiteSpace(lName))
                throw new ArgumentException("Last name is required.");
            FName = fName;
            LName = lName;
            try
            {
                _dateOfBirth = DateTime.Parse(bdate);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Write(LName);
                throw new ArgumentOutOfRangeException("Birthdate is out of range.", e);
            }

            SkillsList = skillsDictionary.Select(x => new PersonSkills(this, x.Key, x.Value)).ToList();
        }

        [Obsolete]
        protected Person()
        {
        }


        public virtual string FName { get; protected set; }
        public virtual string LName { get; protected set; }
        public virtual DateTime _dateOfBirth { get; protected set; }
        public virtual IList<PersonSkills> SkillsList { get; protected set; }

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
            Console.WriteLine("Birth Date: " + _dateOfBirth.ToString("dd/MM/yyyy") + ".");
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
            _dateOfBirth = DateTime.Parse(date);
            Console.WriteLine("Changing birth date");
        }
    }
}