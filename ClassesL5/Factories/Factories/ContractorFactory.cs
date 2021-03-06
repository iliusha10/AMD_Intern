﻿using System.Collections.Generic;
using Domain.Company;
using Domain.Interfaces;
using Domain.Persons;
using Domain.Privileges;
using InterfaceActions.Actions;

namespace Factories.Factories
{
    public class ContractorFactory
    {
        private readonly IDisplayInfoAction _displayInfoAction;

        public ContractorFactory(IDisplayInfoAction displayInfoAction)
        {
            _displayInfoAction = displayInfoAction;
        }

        public Contractor CreateContractor(string fName, string lName, string bdate,
            Dictionary<string, int> skillsDictionary,
            Address address, Company company, double workexp, double salary)
        {
            var contractor = new Contractor(fName, lName, bdate, skillsDictionary,  address, company,
                workexp, salary);
            OnContractorCreation(contractor);
            Logger.Logger.AddToLog("ContractorFactory|CreateContractor Contractor");
            //IPrivileges a = contractor;
            //IPrivileges b = new HollidayPrivilege(a);
            //IPrivileges d = new SalaryBonusPrivilege(b);
            //d.AddPrivilege();
            //var salaryCalculator = new SalaryCalculator();
            //contractor.Salary = salaryCalculator.Calculate(contractor.Salary, new ContractorSalaryCalculator());
            return contractor;
        }

        public void OnContractorCreation(Contractor contractor)
        {
            var a = contractor;
            IPrivileges b = new HollidayPrivilege(a);
            b.AddPrivilege();
            IPrivileges d = new SalaryBonusPrivilege(a);
            d.AddPrivilege();
            _displayInfoAction.DisplayInfo(contractor);
            //contractor.DisplayAll();
        }
    }
}