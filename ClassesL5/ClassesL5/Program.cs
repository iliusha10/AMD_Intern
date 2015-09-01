using System;
using System.Collections.Generic;
using System.Diagnostics;
using Domain;
using Domain.Domain;
using Domain.Privileges;
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
        private static PersonFactory PersonFactory;
        private static readonly IPersonRepository PersonRepository;
        private static readonly ICompanyRepository CompanyRepository;
        private static readonly InternFactory InternFactory;
        private static readonly EmployeeFactory EmployeeFactory;
        private static ProjectFactory ProjectFactory;

        static Program()
        {
            ServiceLocator.RegisterAll();
            EmployeeFactory = ServiceLocator.Get<EmployeeFactory>();
            ProjectFactory = ServiceLocator.Get<ProjectFactory>();
            InternFactory = ServiceLocator.Get<InternFactory>();
            CompanyFactory = ServiceLocator.Get<CompanyFactory>();
            ContractorFactory = ServiceLocator.Get<ContractorFactory>();
            PersonFactory = ServiceLocator.Get<PersonFactory>();
            PersonRepository = ServiceLocator.Get<IPersonRepository>();
            CompanyRepository = ServiceLocator.Get<ICompanyRepository>();
            NHibernateProfiler.Initialize();
        }

        public static void PopulatingDb(int number)
        {
            var personsList = new List<Person>();
            var newAddress = new Address("Monumentul Stefan cel Mare", "Chisinau");
            var projects = new Dictionary<string, string>
            {
                {"Vien", "Project nr 1"},
                {"Ginger", "Project nr 2"},
                {"Fist", "Project nr 3"}
            };
            var company = CompanyFactory.CreateCompany("Amdaris", FieldOfActivity.IT, "Chisinau", projects);
            CompanyRepository.AddCompany(company);

            var project2 = new Dictionary<string, string>
            {
                {"Nima", "Project nr 1"},
                {"BJH", "Project nr 2"},
                {"XAF", "Project nr 3"}
            };
            var company2 = CompanyFactory.CreateCompany("Google", FieldOfActivity.IT, "Roma", project2);
            CompanyRepository.AddCompany(company2);

            var privilegelist = new List<Privileges>();

            //IPrivileges a = contractor;
            //IPrivileges b = new HollidayPrivilege(a);
            //IPrivileges d = new SalaryBonusPrivilege(b);
            //d.AddPrivilege();

            for (var i = 0; i < number; i++)
            {
                var skills = new Dictionary<string, int> {{"C#", 80 + i}, {"SQL", 90 + i}};
                var person = InternFactory.CreateIntern(string.Format("Person {0}", i + 1), "Smith", "1990-12-13",
                    skills, privilegelist, newAddress, company, 8 + i/10);
                personsList.Add(person);
            }
            //PersonRepository.AddPerson(personsList);

            for (var i = 0; i < number; i++)
            {
                var skills = new Dictionary<string, int> {{"C#", 80 + i}, {"SQL", 90 + i}};
                var person = ContractorFactory.CreateContractor(string.Format("Person {0}", i + 1), "Smith",
                    "1990-12-13",
                    skills, privilegelist, newAddress, company, 2 + i, 1000 + i*10);
                personsList.Add(person);
            }
            //PersonRepository.AddPerson(personsList);

            for (var i = 0; i < number; i++)
            {
                var skills = new Dictionary<string, int> {{"C#", 80 + i}, {"SQL", 90 + i}};
                var person = EmployeeFactory.CreateEmployee(string.Format("Person {0}", i + 1), "Smith", "1990-12-13",
                    skills, privilegelist, newAddress, company, 2 + i, 1000 + i*10, "Software Inginiering",
                    "Software developer");
                personsList.Add(person);
            }
            PersonRepository.AddPerson(personsList);
        }


        //public static void AddNewPersons(int number)
        //{
        //    var personsList = new List<Person>();

        //    for (var i = 0; i < number; i++)
        //    {
        //        var skills = new Dictionary<string, int> {{"C#", 80 + i}, {"SQL", 90 + i}};
        //        var person = PersonFactory.CreatePersonWSkills(string.Format("Person {0}", i + 1), "Smith", "1990-12-13",
        //            skills);
        //        personsList.Add(person);
        //    }
        //    PersonRepository.AddPerson(personsList);
        //}

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

        private static void ShowAllPersons()
        {
            var persons = PersonRepository.GetAll();
            persons.PrintToConsole();
        }


        private static void Main(string[] args)
        {
            try
            {
                //decorator pattern
                Logger.Logger.AddToLog("----Begining of the program-----");

                //AddNewPersons(5);
                //PersonRepository.UpdatePerson(15016, "White", "Dude", "1999-1-31");
                //PersonRepository.UpdatePerson(19022, lname: "White", fname: "Dude");
                //PersonRepository.UpdatePerson(15015, bdate: "2005-12-12");
                //PersonRepository.DeletePerson(15019);
                //PopulatingDb(5);


                
                Console.ReadLine();

////Proxy
//                var appointment = new DirectorProxy(intern, director);
//                appointment.NewAppontment(DateTime.Today);
//                var appointment2 = new DirectorProxy(contractor, director);
//                appointment2.NewAppontment(DateTime.Today);
//                Console.ReadLine();

////observer
//                var hr = new HumanResources();
//                ProjectFactory.Subscribe(director);
//                ProjectFactory.Subscribe(hr);
//                ProjectFactory.CreateProject(1, "Rufus", "Making first project");
//                Console.ReadLine();

//                //TDD
//                var internlist = new List<Intern>();
//                internlist.Add(intern);
//                internlist.Add(intern2);
//                var hiredList = hr.Hire(internlist);
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
                Logger.Logger.AddToLog("-------The End-------");
                Debug.WriteLine("Debug: Good luck!");
            }
        }
    }


    internal class InternValidationException : Exception
    {
        public object PersonName;
    }
}