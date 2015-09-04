using System;
using System.Collections.Generic;
using System.Diagnostics;
using Domain;
using Domain.Company;
using Domain.Persons;
using Domain.Privileges;
using Factories.Factories;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using Infrastructure.IoC;
using Repository;
using Repository.Interfaces;

namespace ClassesL5
{
    internal class Program
    {
        private static  CompanyFactory CompanyFactory;
        private static  ContractorFactory ContractorFactory;
        private static PersonFactory PersonFactory;
        private static  IPersonRepository PersonRepository;
        private static  IPersonSkillsRepository PersonSkillsRepository;
        private static  ICompanyRepository CompanyRepository;
        private static  InternFactory InternFactory;
        private static  EmployeeFactory EmployeeFactory;
        private static ProjectFactory ProjectFactory;




        static Program()
        {
            ServiceLocator.RegisterAll();
           
            NHibernateProfiler.Initialize();
        }

        public static void PopulatingDb(int number)
        {
            var employeelist = new List<Employee>();
            var contractorlist = new List<Contractor>();
            var internlist = new List<Intern>();
            var personsList = new List<Person>();
            var companylist = new List<Company>();
            
            var newAddress = new Address("Monumentul Stefan cel Mare", "Chisinau");
            var newAddress2 = new Address("Aleco Ruso", "Chisinau");
            var newAddress3 = new Address("bd Decebal", "Chisinau");
            var newAddress4 = new Address("bd Miorita", "Chisinau");
            
            var projects = new Dictionary<string, string>
            {
                {"Vien", "Project nr 1"},
                {"Ginger", "Project nr 2"},
                {"Fist", "Project nr 3"}
            };
            var company = CompanyFactory.CreateCompany("Amdaris", FieldOfActivity.IT, "Chisinau", projects);
            CompanyRepository.AddCompany(company);

            var project2 = new Dictionary<string, string> {
                {"Nima", "Project nr 1"},
                {"BJH", "Project nr 2"},
                {"XAF", "Project nr 3"}
            };
            
            var company3 = CompanyFactory.CreateCompany("Amdaris", FieldOfActivity.IT, "Chisinau", projects);
            CompanyRepository.AddCompany(company);
            var project3 = new Dictionary<string, string> {
                {"Nima", "Project nr 1"},
                {"BJH", "Project nr 2"},
                {"XAF", "Project nr 3"}
            };
            var company2 = CompanyFactory.CreateCompany("Google", FieldOfActivity.IT, "Roma", project2);
            CompanyRepository.AddCompany(company2);

            var privilegelist = new List<string>();

            //IPrivileges a = contractor;
            //IPrivileges b = new HollidayPrivilege(a);
            //IPrivileges d = new SalaryBonusPrivilege(b);
            //d.AddPrivilege();

            for (var i = 0; i < number; i++)
            {
                var skills = new Dictionary<string, int> {{"C#", 80 + i}, {"SQL", 90 + i}};
                var person = InternFactory.CreateIntern(string.Format("Person {0}", i + 1), "Smith", "1990-12-13",
                    skills, newAddress, company, 8 + i/10);
                person.AddPrivilege();
                personsList.Add(person);
            }
            //PersonRepository.AddPerson(personsList);

            for (var i = 0; i < number; i++)
            {
                var skills = new Dictionary<string, int> {{"C#", 80 + i}, {"SQL", 90 + i}};
                var person = ContractorFactory.CreateContractor(string.Format("Person {0}", i + 1), "Smith",
                    "1990-12-13",
                    skills, newAddress, company, 2 + i, 1000 + i*10);
                personsList.Add(person);
            }
            //PersonRepository.AddPerson(personsList);

            for (var i = 0; i < number; i++)
            {
                var skills = new Dictionary<string, int> {{"C#", 80 + i}, {"SQL", 90 + i}};
                var person = EmployeeFactory.CreateEmployee(string.Format("Person {0}", i + 1), "Smith", "1990-12-13",
                    skills, newAddress, company, 2 + i, 1000 + i*10, "Software Inginiering",
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

        //JoinQueryOver + Where
        private static void ShowPersonSkillsByFirstname(string firstname)
        {
            var persons = PersonRepository.GetPersonSkillsByFirstname(firstname);
            //var persons = PersonSkillsRepository.GetPersonSkillsByFirstname(firstname);
            persons.PrintToConsole();
        }

        //JoinAlias + Where
        private static void ShowPersonByTaskname(string taskname)
        {
            var persons = PersonRepository.GetPersonByTaskName(taskname);
            persons.PrintToConsole();
        }

        //JoinAlias + SelectList + AliasToBean
        private static void ShowEmployeeDetails1()
        {
            var employee = PersonRepository.GetEmployeeDetails1();
            Console.WriteLine("{0, -10} {1, -10} {2, -10} {3, -10} {4, -10}", "FirstName", "LastName", 
                "DateOfBirth", "Department", "Role");
            foreach (var em in employee)
            {
                Console.WriteLine(em);
            }
        }

        //SingleOrDefault + where
        private static void ShowPersonLastnameById(long id)
        {
            var lastname = PersonRepository.GetPersonLastnameById(id);
            Console.WriteLine(lastname);
            //persons.PrintToConsole();
        }

        //Future + SelectProjectionList
        private static void ShowAllPersonsFirstAndLastNames_ProjectionList()
        {
            var persons = PersonRepository.GetAllFirstAndLastNames_ProjectionList();
            foreach (var p in persons)
            {
                Console.WriteLine("{0} {1}", p[0], p[1]);
            }
        }

        //JoinAlias + SelectGroup+SelectCount + Where(Restrictions) + AliasToBean
        private static void ShowPersonRowsHavingMoreThanOneSkill()
        {
            const string template = "{0, -15} {1, -15} {2, -15} {3, -15}";
            var clients = PersonRepository.GetPersonRowsHavingMoreThanOneSkill();

            Console.WriteLine(template, "PersonID", "Firstname", "Lastname", "Tasks");

            foreach (var row in clients)
            {
                Console.WriteLine(row);
            }
        }

        //DistinctRootEntity
        private static void ShowAllPersonsWithSkills()
        {
            var persons = PersonRepository.GetAllPersonsWithSkills();

            Console.WriteLine("There are {0} persons records with skills", persons.Count);
        }

        //private static void ShowPersonByLNameOrByFName(name)
        //{
        //    var persons = PersonRepository.GetPersonByLNameOrByFName(Emma);
        //}



        private static void Main(string[] args)
        {
            EmployeeFactory = ServiceLocator.Get<EmployeeFactory>();
            ProjectFactory = ServiceLocator.Get<ProjectFactory>();
            InternFactory = ServiceLocator.Get<InternFactory>();
            CompanyFactory = ServiceLocator.Get<CompanyFactory>();
            ContractorFactory = ServiceLocator.Get<ContractorFactory>();
            PersonFactory = ServiceLocator.Get<PersonFactory>();
            PersonRepository = ServiceLocator.Get<IPersonRepository>();
            PersonSkillsRepository = ServiceLocator.Get<IPersonSkillsRepository>();
            CompanyRepository = ServiceLocator.Get<ICompanyRepository>();

           
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


                //ShowAllPersons();
                //ShowPersonSkillsByFirstname("Person 1");
                //ShowPersonByTaskname("Task 1");
                //ShowPersonLastnameById(3003);
                // ShowEmployeeDetails1();
                //ShowPersonRowsHavingMoreThanOneSkill();
                //ShowAllPersonsWithSkills();
                //ShowAllPersonsFirstAndLastNames_ProjectionList();

                //ShowPersonByLNameOrByFName;

                TestPrivelesAdd();



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

        private static void TestPrivelesAdd()
        {
            var newAddress = new Address("Monumentul Stefan cel Mare", "Chisinau");
            var skills = new Dictionary<string, int> {{"C#", 80}, {"SQL", 90}};
            var project2 = new Dictionary<string, string>
            {
                {"Nima", "Project nr 1"},
                {"BJH", "Project nr 2"},
                {"XAF", "Project nr 3"}
            };


            var emp = EmployeeFactory.CreateEmployee("John", "Doe", "1980-04-01", skills, newAddress,
                CompanyFactory.CreateCompany("Imea", FieldOfActivity.IT, "Chisinau", project2), 20, 1300, "Test",
                "Testing Ingineer");
            var salary= new Salary(emp, "2015.02.02", 1200);
            PersonRepository.AddPerson(new List<Person>() {emp});
            foreach (var variable in emp.PrivilegeList)
            {
                Console.WriteLine(variable);
            }
            ;
        }
    }


    internal class InternValidationException : Exception
    {
        public object PersonName;
    }
}