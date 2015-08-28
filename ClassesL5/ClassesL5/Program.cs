using System;
using System.Collections.Generic;
using System.Diagnostics;
using Domain.Domain;
using Factories.Factories;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using Infrastructure.IoC;
using Repository.Interfaces;

namespace ClassesL5
{
    internal class Program
    {
        private static readonly CompanyFactory CompanyFactory;
        private static readonly ContractorFactory ContractorFactory;
        private static readonly PersonFactory PersonFactory;
        private static readonly IPersonRepository PersonRepository;


        static Program()
        {
            ServiceLocator.RegisterAll();
            CompanyFactory = ServiceLocator.Get<CompanyFactory>();
            ContractorFactory = ServiceLocator.Get<ContractorFactory>();
            PersonFactory = ServiceLocator.Get<PersonFactory>();
            PersonRepository = ServiceLocator.Get<IPersonRepository>();
            NHibernateProfiler.Initialize();
        }


        public static void AddNewPersons(int number)
        {
            var personsList = new List<Person>();

            for (var i = 0; i < number; i++)
            {
                 var skills = new Dictionary<string, int>() ; 
                skills.Add("C#", 80 + i);
                skills.Add("SQL", 90 + i); 
                var person = PersonFactory.CreatePersonWSkills(string.Format("Person {0}", i + 1), "Smith", "1990-12-13", skills);
                personsList.Add(person);
            }
            PersonRepository.AddPerson(personsList);

        } 
        
        //public static void SaveNewPersons(int number)
        //{
        //    var personsList = new List<Person>();

        //    for (var i = 0; i < number; i++)
        //    {
        //        var person = PersonFactory.CreatePersonWSkills(string.Format("Person {0}", i + 1), "Smith", "1990-12-13", new List<PersonSkills>() { new PersonSkills("C#", 80 + i), new PersonSkills("SQL", 90 + i) });
        //        personsList.Add(person);
        //    }
        //    PersonRepository.Save(personsList);
        //}


        private static void Main(string[] args)
        {

            try
            {
                
                //AddNewPersons(5);
                //PersonRepository.UpdatePerson(15016, "White", "Dude", "1999-1-31");
                //PersonRepository.UpdatePerson(19022, lname: "White", fname: "Dude");
                //PersonRepository.UpdatePerson(15015, bdate: "2005-12-12");
                //PersonRepository.DeletePerson(15019);

                Console.ReadLine();
            }
            catch (InternValidationException exc1)
            {
                Console.WriteLine("{1} = {0}", exc1.Message, exc1.PersonName);
                Console.ReadLine();
                //throw;
            }
            catch (ArgumentOutOfRangeException exc2)
            {
                Console.WriteLine(" = {0}", exc2.Message);
                Console.ReadLine();
                //throw;
            }
            catch (NullReferenceException exc3)
            {
                Console.WriteLine(" = {0}", exc3.Message);
                Console.ReadLine();
                //throw;
            }
            finally
            {
                Debug.WriteLine("Debug: Good luck!");
            }
        }
    }


    internal class InternValidationException : Exception
    {
        public object PersonName;
    }
}