using System;
using System.Collections.Generic;
using Domain.Domain;
using Factories.Factories;
using Infrastructure.IoC;

namespace ClassesL5
{
    public class EmployeeGenerator
    {
        private static readonly EmployeeFactory EmployeeFactory = ServiceLocator.Get<EmployeeFactory>();

        public static IList<Employee> CreateNewEmployees(int number, Company comp)
        {
            var employeeList = new List<Employee>();

            for (int i = 0; i < number; i++)
            {
                var employee = EmployeeFactory.CreateEmployee(String.Format("Employee {0}", i + 1), "Black", i + 15,
                    i + 1, i + 1980, i*750, comp, i + 1, "Department");
                employeeList.Add(employee);
            }

            return employeeList;
        }
    }
}