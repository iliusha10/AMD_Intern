using System.Collections.Generic;
using Domain.Domain;
using Domain.Privileges;
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

        public Employee CreateEmployee(string fName, string lName, string bdate,
            Dictionary<string, int> skillsDictionary, IList<Privileges> privilegeList, Address address,
            Company company, double workexp, double salary,
            string department, string function)
        {
            var employee = new Employee(fName, lName, bdate, skillsDictionary, privilegeList, address, company, workexp,
                salary, department, function);
            OnEmployeeCreation(employee);
            Logger.Logger.AddToLog("EmployeeFactory|CreateEmployee Employee");
            //var salaryCalculator = new SalaryCalculator();
            //employee.Salary = salaryCalculator.Calculate(employee.Salary, new EmployeeSalaryCalculator());

            return employee;
        }

        public void OnEmployeeCreation(Employee employee)
        {
            _displayInfoAction.DisplayInfo(employee);
            //employee.DisplayAll();
        }
    }
}