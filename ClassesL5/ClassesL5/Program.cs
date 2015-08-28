using System;
using System.Collections.Generic;
using System.Diagnostics;
using Domain;
using Domain.Domain;
using Domain.Interfaces;
using Domain.Privileges;
using Domain.Proxy;
using Factories.Factories;
using Infrastructure.IoC;

namespace ClassesL5
{
    internal class Program
    {
        private static readonly CompanyFactory CompanyFactory;
        private static readonly InternFactory InternFactory;
        private static readonly EmployeeFactory EmployeeFactory;
        private static readonly ContractorFactory ContractorFactory;
        private static readonly ProjectFactory ProjectFactory;

        
        //public static List 

        static Program()
        {
            ServiceLocator.RegisterAll();
            EmployeeFactory = ServiceLocator.Get<EmployeeFactory>();
            InternFactory = ServiceLocator.Get<InternFactory>();
            CompanyFactory = ServiceLocator.Get<CompanyFactory>();
            ContractorFactory = ServiceLocator.Get<ContractorFactory>();
            ProjectFactory = ServiceLocator.Get<ProjectFactory>();
        }

        private static void Main(string[] args)
        {
            try
            {
                //decorator pattern
                Logger.Logger.AddToLog("----Begining of the program-----");
                //var Workers = new WorkerList();

                var comp = CompanyFactory.CreateCompany(1, "Amdaris", FieldOfActivity.IT, "Puskin 22", "Chisinau");
                var director = new Director("Dart", "Weider", 31, 12, 1980, 5000);
                director.DisplayMainInfo();
                IPrivileges a = director;
                IPrivileges b = new KingOfTheWorldPrivilege(a);
                b.AddPrivilege();
                //var comp2 = CompanyFactory.CreateCompany(2, "Google", FieldOfActivity.IT, "Varlaam 1", "Balti");
                Console.ReadLine();


                //var interns = InternGenerator.CreateNewInterns(2, comp);
                //var employee = EmployeeGenerator.CreateNewEmployees(2, comp2);
                var intern = InternFactory.CreateIntern("Wano", "Smith", 1, 1, 1990, 500, 6, comp);
                var intern2 = InternFactory.CreateIntern("Ion", "Bamby", 10, 10, 2000, 525, 8.5, comp);
                var employee = EmployeeFactory.CreateEmployee("Wano", "Smith", 14, 3, 1991, 2000, comp, 4, "QA");
                var employee2 = EmployeeFactory.CreateEmployee("Ursula", "Black", 14, 3, 1991, 2000, comp, 4, "System testing department");
                var employee3 = EmployeeFactory.CreateEmployee("Jim", "Newman", 14, 3, 1991, 2000, comp, 4, "Development");
                var contractor = ContractorFactory.CreateContractor("Jack", "Bilbons", 30, 3, 1950, 1500, comp, 1);
                


                //Proxy
                var appointment = new DirectorProxy(intern, director);
                appointment.NewAppontment(DateTime.Today);
                var appointment2 = new DirectorProxy(contractor, director);
                appointment2.NewAppontment(DateTime.Today);
                Console.ReadLine();

                //observer
                var hr = new HumanResources();
                ProjectFactory.Subscribe(director);
                ProjectFactory.Subscribe(hr);
                ProjectFactory.CreateProject(1, "Rufus", "Making first project");
                Console.ReadLine();

                //TDD
                var internlist = new List<Intern>();
                internlist.Add(intern);
                internlist.Add(intern2);
                var hiredList = hr.Hire(internlist);

                foreach (var x in hiredList)
                {
                    Console.WriteLine("{0} {1}", x.FName, x.LName);
                }
                Console.ReadLine();

                //optional param
                hr.IsAbsent("Vasile");
                hr.IsAbsent("Vasile", false);
                hr.IsAbsent(nume: "Vasile", cause: "Is getting married" );
                Console.ReadLine();



                //var Skills = new Dictionary<string, int>();
                //Skills.Add("PHP", 6);
                //Skills.Add("HTML", 7);
                //Skills.Add("C#", 9);
                //var internfactory = new InternFactory(new DisplayAll());
                //var i1 = InternFactory.CreateIntern("John", "Sunday", 1, 1, 1990, 9.08, comp);
                // i1.AddSkill("PHP", 5);
                //i1.AddSkill("HTML", 5);
                //i1.AddSkill("C#", 5);
                //Console.ReadLine();

                //var c1 = ContractorFactory.CreateContractor("Jack", "Bilbons", 30, 3, 1950, comp, 1, 500);
                //c1.AddSkill("PHP", 5);
                //c1.AddSkill("HTML", 5);
                //c1.AddSkill("C#", 5);
                //Console.ReadLine();


                //var e1 = EmployeeFactory
                //.CreateEmployee("Vano", "Smith", 20, 2, 2000, comp2, 4, 2000,
                //"East Production Department");
                //e1.AddSkill("PHP", 8);
                //e1.AddSkill("HTML", 8);
                //e1.AddSkill("C#", 8);
                //Console.ReadLine();
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