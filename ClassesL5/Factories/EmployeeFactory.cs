using System;
using System.Collections.Generic;
using Domain.CompanyAssets;
using Domain.Interfaces;
using Domain.Persons;
using Domain.Privileges;
using InterfaceActions.Actions;

namespace Factories
{
    public class EmployeeFactory
    {
        private readonly IDisplayInfoAction _displayInfoAction;

        public EmployeeFactory(IDisplayInfoAction displayInfoAction)
        {
            _displayInfoAction = displayInfoAction;
        }

        public Employee CreateEmployee(string fName, string lName, DateTime bDate,
            Dictionary<string, int> skillsDictionary, Address address,
            Company company, double workexp, Salary salary,
            string department, string function)
        {
            var employee = new Employee(fName, lName, bDate, skillsDictionary,  address, company, workexp,
                salary, department, function);
            OnEmployeeCreation(employee);
            Logger.Logger.AddToLog("EmployeeFactory|CreateEmployee Employee");
            //var salaryCalculator = new SalaryCalculator();
            //employee.Salary = salaryCalculator.Calculate(employee.Salary, new EmployeeSalaryCalculator());

            return employee;
        }

        public void OnEmployeeCreation(Employee employee)
        {
            var a = employee;
            IPrivileges b = new HollidayPrivilege(a);
            b.AddPrivilege();
            b = new LunchTichetsPrivilege(a);
            b.AddPrivilege();
            b = new SalaryBonusPrivilege(a);
            b.AddPrivilege();
            _displayInfoAction.DisplayInfo(employee);
            //employee.DisplayAll();
        }
    }
}