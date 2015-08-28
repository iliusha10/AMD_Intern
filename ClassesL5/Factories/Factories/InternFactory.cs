﻿using System.Collections.Generic;
using Domain.Domain;
using InterfaceActions.Actions;

namespace Factories.Factories
{
    public class InternFactory
    {
        private readonly IDisplayInfoAction _displayInfoAction;

        public InternFactory(IDisplayInfoAction displayInfoAction)
        {
            _displayInfoAction = displayInfoAction;
        }

        public Intern CreateIntern(string fname, string lname, string bdate, double avmark, Company company)
        {
Logger.Logger.AddToLog("InternFactory|CreateIntern Intern");
            var intern = new Intern(fname, lname, bdate, avmark, company);
            OnInternCreation(intern);
IPrivileges a = intern;
            IPrivileges b = new HollidayPrivilege(a);
            IPrivileges d = new SalaryBonusPrivilege(b);
            d.AddPrivilege();
            var salaryCalculator = new SalaryCalculator();
            intern.Salary = salaryCalculator.Calculate(intern.Salary, new InternSalaryCalculator());
            return intern;
               
        }

        public void OnInternCreation(Intern intern)
        {
            _displayInfoAction.DisplayInfo(intern);
            //intern.DisplayAll();
        }
    }
}