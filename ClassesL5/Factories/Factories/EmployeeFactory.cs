using System.Collections.Generic;
using Domain.Domain;
using InterfaceActions.Actions;

namespace Factories.Factories
{
    public class EmployeeFactory
    {
        private readonly IDisplayInfoAction _displayInfoAction;

        public EmployeeFactory(IDisplayInfoAction displayInfoAction)
        {
            _displayInfoAction = displayInfoAction;
        }

        public Employee CreateEmployee(string fname, string lname, string bdate, Company company, double workexp,
            double salary, string department)
        {
            var employee = new Employee(fname, lname, bdate, company, workexp, salary, department);
            OnEmployeeCreation(employee);
Logger.Logger.AddToLog("EmployeeFactory|CreateEmployee Employee");
IPrivileges a = employee;
            IPrivileges b = new HollidayPrivilege(a);
            IPrivileges c = new LunchTichetsPrivilege(b);
            IPrivileges d = new SalaryBonusPrivilege(c);
            d.AddPrivilege();
            var salaryCalculator = new SalaryCalculator();
            employee.Salary = salaryCalculator.Calculate(employee.Salary, new EmployeeSalaryCalculator());

            return employee;
        }

        public void OnEmployeeCreation(Employee employee)
        {
            _displayInfoAction.DisplayInfo(employee);
            //employee.DisplayAll();
        }
    }
}