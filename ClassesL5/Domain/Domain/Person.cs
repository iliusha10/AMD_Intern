using System;
using System.Collections.Generic;

namespace Domain.Domain
{
    public class Person
    {
        private DateTime _dateOfBirth;

        public virtual bool HasAcces()
        {
            return false;
        }

        protected Person(string fname, string lname, int bdate, int bmonth, int byear, double salary)
        {
            if (string.IsNullOrWhiteSpace(fname))
                throw new ArgumentException("First name is required.");
            if (string.IsNullOrWhiteSpace(lname))
                throw new ArgumentException("Last name is required.");

            FName = fname;
            LName = lname;
            Salary = salary;

            //var Skills = new Dictionary<string, int>();
            //var Skills = new Dictionary<string, int>();
            try
            {
                _dateOfBirth = new DateTime(byear, bmonth, bdate);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Write(LName);
                throw new ArgumentOutOfRangeException("Birthdate is out of range.", e);
            }
        }


        public string FName { get; private set; }
        public string LName { get; private set; }
        public double Salary { get; set; }


        public int Age
        {
            get { return DateTime.Now.Year - _dateOfBirth.Year; }
        }


        //public abstract double calcBonus(double salary);


        protected void DisplayPersonInfo()
        {
            Console.WriteLine("Name: {0} {1}", FName, LName);
            Console.WriteLine("Birth Date: " + _dateOfBirth.ToString("dd/MM/yyyy") + ".");
            //Console.WriteLine("Age: {0}", Age);
            //Console.WriteLine();
            //Console.WriteLine("Skills: ");
            //ShowSkills();
        }

        public void DisplayMainInfo()
        {
            DisplayPersonInfo();
            //Console.WriteLine();
        }


        public virtual void DisplayAll()
        {
            Console.WriteLine("Age: {0}", Age);
            DisplayPersonInfo();
        }


        public Dictionary<string, int> Skills { get; private set; }


        public void AddSkill(string skillName, int level)
        {
            try
            {
                Skills.Add(skillName, level);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An skill with the name {0} already exist", skillName, level);
                int value;
                Skills.TryGetValue(skillName, out value);
                if (value < level)
                {
                    Skills[skillName] = level;
                    Console.WriteLine("Updated skill level from {0} to {1}", value, level);
                }
                else Console.WriteLine("The skill is already updated", skillName, level);
            }
        }


        public void ShowSkills()
        {
            if (Skills.Count < 1) Console.WriteLine("There is no Skills");
            else
                foreach (KeyValuePair<string, int> skill in Skills)
                {
                    Console.WriteLine("Key = {0}, Value = {1}", skill.Key, skill.Value);
                }
        }
    }
}