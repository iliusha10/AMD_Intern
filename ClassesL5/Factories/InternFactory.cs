using System;
using System.Collections.Generic;
using Domain.CompanyAssets;
using Domain.Persons;
using Domain.Privileges;
using InterfaceActions.Actions;

namespace Factories
{
    public class InternFactory
    {
        private readonly IDisplayInfoAction _displayInfoAction;

        public InternFactory(IDisplayInfoAction displayInfoAction)
        {
            _displayInfoAction = displayInfoAction;
        }

        public Intern CreateIntern(string fName, string lName, DateTime bdate, Dictionary<string, int> skillsDictionary,
            Address address, Company company, double avmark)
        {
            Logger.Logger.AddToLog("InternFactory|CreateIntern Intern");
            var intern = new Intern(fName, lName, bdate, skillsDictionary, address, company, avmark);
            OnInternCreation(intern);
            //IPrivileges a = intern;
            //IPrivileges b = new HollidayPrivilege(a);
            //IPrivileges d = new SalaryBonusPrivilege(b);
            //d.AddPrivilege();
            //var salaryCalculator = new SalaryCalculator();
            //intern.Salary = salaryCalculator.Calculate(intern.Salary, new InternSalaryCalculator());
            return intern;
        }

        public void OnInternCreation(Intern intern)
        {
            var a = intern;
            var b = new HollidayPrivilege(a);
            b.AddPrivilege();
            _displayInfoAction.DisplayInfo(intern);
            //intern.DisplayAll();
        }
    }
}