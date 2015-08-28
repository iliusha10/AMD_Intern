using Bl.SalaryCalculator;
using Domain.Domain;
using Domain.Interfaces;
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

        public Employee CreateEmployee(string fname, string lname, int bdate, int bmonth, int byear, double salary,
            Company company, double workexp, string department)
        {
            var employee = new Employee(fname, lname, bdate, bmonth, byear, salary, company, workexp, department);
            Logger.Logger.AddToLog("EmployeeFactory|CreateEmployee Employee");
            OnEmployeeCreation(employee);
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
        }
    }
}