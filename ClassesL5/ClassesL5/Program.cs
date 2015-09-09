using System;
using System.Collections.Generic;
using System.Diagnostics;
using Domain;
using Domain.CompanyAssets;
using Domain.Persons;
using Factories;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using Infrastructure.IoC;
using Repository.Interfaces;

namespace ClassesL5
{
    internal class Program
    {
        private static CompanyFactory CompanyFactory;
        private static ContractorFactory ContractorFactory;
        private static PersonFactory PersonFactory;
        private static IPersonRepository PersonRepository;
        private static IPersonSkillsRepository PersonSkillsRepository;
        private static ICompanyRepository CompanyRepository;
        private static InternFactory InternFactory;
        private static EmployeeFactory EmployeeFactory;
        private static ProjectFactory ProjectFactory;
        private static TaskFactory TaskFactory;

        static Program()
        {
            ServiceLocator.RegisterAll();

            NHibernateProfiler.Initialize();
        }

        //public static void PopulatingDb(int number)
        //{
        //    var employeelist = new List<Employee>();
        //    var contractorlist = new List<Contractor>();
        //    var internlist = new List<Intern>();
        //    var personsList = new List<Person>();
        //    var companylist = new List<Company>();

        //    var newAddress = new Address("Monumentul Stefan cel Mare", "Chisinau");
        //    var newAddress2 = new Address("Aleco Ruso", "Chisinau");
        //    var newAddress3 = new Address("bd Decebal", "Chisinau");
        //    var newAddress4 = new Address("bd Miorita", "Chisinau");

        //    var projects = new Dictionary<string, string>
        //    {
        //        {"Vien", "Project nr 1"},
        //        {"Ginger", "Project nr 2"},
        //        {"Fist", "Project nr 3"}
        //    };
        //    var company = CompanyFactory.CreateCompany("Amdaris", FieldOfActivity.IT, "Chisinau", projects);
        //    CompanyRepository.AddCompany(company);

        //    var project2 = new Dictionary<string, string>
        //    {
        //        {"Nima", "Project nr 1"},
        //        {"BJH", "Project nr 2"},
        //        {"XAF", "Project nr 3"}
        //    };

        //    var company3 = CompanyFactory.CreateCompany("Amdaris", FieldOfActivity.IT, "Chisinau", projects);
        //    CompanyRepository.AddCompany(company);
        //    var project3 = new Dictionary<string, string>
        //    {
        //        {"Nima", "Project nr 1"},
        //        {"BJH", "Project nr 2"},
        //        {"XAF", "Project nr 3"}
        //    };
        //    var company2 = CompanyFactory.CreateCompany("Google", FieldOfActivity.IT, "Roma", project2);
        //    CompanyRepository.AddCompany(company2);

        //    var privilegelist = new List<string>();

            //IPrivileges a = contractor;
            //IPrivileges b = new HollidayPrivilege(a);
            //IPrivileges d = new SalaryBonusPrivilege(b);
            //d.AddPrivilege();

            //for (var i = 0; i < number; i++)
            //{
            //    var skills = new Dictionary<string, int> {{"C#", 80 + i}, {"SQL", 90 + i}};
            //    var person = InternFactory.CreateIntern(string.Format("Person {0}", i + 1), "Smith", "1990-12-13",
            //        skills, newAddress, company, 8 + i/10);
            //    person.AddPrivilege();
            //    personsList.Add(person);
            //}
            //PersonRepository.AddPerson(personsList);

            //for (var i = 0; i < number; i++)
            //{
            //    var skills = new Dictionary<string, int> {{"C#", 80 + i}, {"SQL", 90 + i}};
            //    var person = ContractorFactory.CreateContractor(string.Format("Person {0}", i + 1), "Smith",
            //        "1990-12-13",
            //        skills, newAddress, company, 2 + i, 1000 + i*10);
            //    personsList.Add(person);
            //}
            //PersonRepository.AddPerson(personsList);

            //for (var i = 0; i < number; i++)
            //{
            //    var skills = new Dictionary<string, int> {{"C#", 80 + i}, {"SQL", 90 + i}};
            //    var person = EmployeeFactory.CreateEmployee(string.Format("Person {0}", i + 1), "Smith", "1990-12-13",
            //        skills, newAddress, company, 2 + i, 1000 + i*10, "Software Inginiering",
            //        "Software developer");
            //    personsList.Add(person);
            //}
            //PersonRepository.AddPerson(personsList);
        //}

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
            TaskFactory = ServiceLocator.Get<TaskFactory>();


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
            //var employeelist = new List<Employee>();
           // var contractorlist = new List<Contractor>();
            var projectList = new List<Project>();
            var personsList = new List<Person>();
            var companylist = new List<Company>();

            var newAddress = new Address("Monumentul Stefan cel Mare", "Chisinau");
            var newAddress2 = new Address("Aleco Ruso", "Chisinau");
            var newAddress3 = new Address("bd Decebal", "Chisinau");
            var newAddress4 = new Address("bd Miorita", "Chisinau");
            
            var skills = new Dictionary<string, int> {{"C#", 80}, {"SQL", 90}};
            var skills2 = new Dictionary<string, int> { { "CSS", 80 }, { "PHP", 90 }, { "HTML", 90 } };
            var skills3 = new Dictionary<string, int> { { "JavaScript", 80 }, { "HTML", 90 } };
            var skills4 = new Dictionary<string, int> { { "C++", 80 } };


            var comp = CompanyFactory.CreateCompany("Imea", FieldOfActivity.IT, newAddress2);
            var comp2 = CompanyFactory.CreateCompany("WIKER", FieldOfActivity.IT, newAddress);
            var comp3 = CompanyFactory.CreateCompany("Bones", FieldOfActivity.IT, newAddress3);
            var comp4 = CompanyFactory.CreateCompany("XQT", FieldOfActivity.IT, newAddress4);
            companylist.Add(comp);
            companylist.Add(comp2);
            companylist.Add(comp3);
            companylist.Add(comp4);

            var proj = ProjectFactory.CreateProject(comp, "Nima", "Project nr 1");
            var proj2 = ProjectFactory.CreateProject(comp, "BJH", "Project nr 2");
            var proj3 = ProjectFactory.CreateProject(comp, "XAF", "Project nr 3");
            comp.AddProject(proj);
            comp.AddProject(proj2);
            comp.AddProject(proj3);

            var proj4 = ProjectFactory.CreateProject(comp2, "P1", "Project nr 1");
            var proj5 = ProjectFactory.CreateProject(comp2, "P2", "Project nr 2");
            var proj6 = ProjectFactory.CreateProject(comp2, "P3", "Project nr 3");
            var proj7 = ProjectFactory.CreateProject(comp2, "P4", "Project nr 4");
            var proj8 = ProjectFactory.CreateProject(comp2, "P5", "Project nr 5");
            comp2.AddProject(proj4);
            comp2.AddProject(proj5);
            comp2.AddProject(proj6);
            comp2.AddProject(proj7);
            comp2.AddProject(proj8);

            var proj9 = ProjectFactory.CreateProject(comp3, "1Pr", "Project nr 1");
            var proj10 = ProjectFactory.CreateProject(comp3, "2Pr", "Project nr 2");
            var proj11 = ProjectFactory.CreateProject(comp3, "3Pr", "Project nr 3");
            var proj12 = ProjectFactory.CreateProject(comp3, "4Pr", "Project nr 4");
            var proj13 = ProjectFactory.CreateProject(comp3, "5Pr", "Project nr 5");
            var proj14 = ProjectFactory.CreateProject(comp3, "6Pr", "Project nr 6");
            comp3.AddProject(proj9);
            comp3.AddProject(proj10);
            comp3.AddProject(proj11);
            comp3.AddProject(proj12);
            comp3.AddProject(proj13);
            comp3.AddProject(proj14);


            var task1 = TaskFactory.CreateTask(proj, "Task1", "Description", "12.12.2016");
            var task2 = TaskFactory.CreateTask(proj2, "Task1", "Description", "12.12.2016");
            var task3 = TaskFactory.CreateTask(proj3, "Task1", "Description", "12.12.2016");
            var task4 = TaskFactory.CreateTask(proj4, "Task1", "Description", "12.12.2016");
            var task5 = TaskFactory.CreateTask(proj5, "Task1", "Description", "12.12.2016");
            var task6 = TaskFactory.CreateTask(proj6, "Task1", "Description", "12.12.2016");
            var task7 = TaskFactory.CreateTask(proj7, "Task1", "Description", "12.12.2016");
            var task8 = TaskFactory.CreateTask(proj8, "Task1", "Description", "12.12.2016");
            var task9 = TaskFactory.CreateTask(proj9, "Task1", "Description", "12.12.2016");
            var task10 = TaskFactory.CreateTask(proj10, "Task1", "Description", "12.12.2016");
            var task11 = TaskFactory.CreateTask(proj11, "Task1", "Description", "12.12.2016");
            var task12 = TaskFactory.CreateTask(proj12, "Task1", "Description", "12.12.2016");
            var task13 = TaskFactory.CreateTask(proj13, "Task1", "Description", "12.12.2016");
            var task14 = TaskFactory.CreateTask(proj14, "Task1", "Description", "12.12.2016");
            var task15 = TaskFactory.CreateTask(proj, "Task2", "Description", "12.12.2016");
            var task16 = TaskFactory.CreateTask(proj2, "Task2", "Description", "12.12.2016");
            var task17 = TaskFactory.CreateTask(proj3, "Task2", "Description", "12.12.2016");
            var task18 = TaskFactory.CreateTask(proj4, "Task2", "Description", "12.12.2016");
            var task19 = TaskFactory.CreateTask(proj, "Task3", "Description", "12.12.2016");
            var task20 = TaskFactory.CreateTask(proj2, "Task3", "Description", "12.12.2016");
            proj.AddTask(task1);
            proj.AddTask(task15);
            proj.AddTask(task19);
            proj2.AddTask(task2);
            proj2.AddTask(task16);
            proj2.AddTask(task20);
            proj3.AddTask(task3);
            proj3.AddTask(task17);
            proj4.AddTask(task4);
            proj4.AddTask(task18);
            proj5.AddTask(task5);
            proj6.AddTask(task6);
            proj7.AddTask(task7);
            proj8.AddTask(task8);
            proj9.AddTask(task9);
            proj10.AddTask(task10);
            proj11.AddTask(task11);
            proj12.AddTask(task12);
            proj13.AddTask(task13);
            proj14.AddTask(task14);

            var intern = InternFactory.CreateIntern("Vasile", "Ion", "1990-12-13", skills, newAddress, comp, 80);
            personsList.Add(intern);

            var emp = EmployeeFactory.CreateEmployee("John", "Doe", "1980-04-01", skills2, newAddress, comp, 20, 1400, "Test",
                "Testing Ingineer");
            personsList.Add(emp);

            emp = EmployeeFactory.CreateEmployee("Jim", "Dole", "1990-05-10", skills, newAddress2, comp2, 30, 1500, "Softwer Development",
                "Software developer");
            personsList.Add(emp);

            emp = EmployeeFactory.CreateEmployee("Anne", "Fireman", "1995-12-12", skills3, newAddress3, comp3, 60, 1600, "Test", "Testing Ingineer");
            personsList.Add(emp);

            emp = EmployeeFactory.CreateEmployee("Vanessa", "Ginger", "1996-11-01", skills4, newAddress4, comp4, 70, 1700, "Softwer Development", "Software developer");
            personsList.Add(emp);
            


            CompanyRepository.AddCompany(companylist);
            PersonRepository.AddPerson(personsList);

        }
    }


    internal class InternValidationException : Exception
    {
        public object PersonName;
    }
}