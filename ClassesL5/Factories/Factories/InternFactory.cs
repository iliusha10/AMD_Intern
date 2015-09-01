using System.Collections.Generic;
using Domain.Domain;
using Domain.Privileges;
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

        public Intern CreateIntern(string fName, string lName, string bdate, Dictionary<string, int> skillsDictionary,
            IList<Privileges> privilegeList, Address address, Company company, double avmark)
        {
            Logger.Logger.AddToLog("InternFactory|CreateIntern Intern");
            var intern = new Intern(fName, lName, bdate, skillsDictionary, privilegeList, address, company, avmark);
            OnInternCreation(intern);
//IPrivileges a = intern;
//            IPrivileges b = new HollidayPrivilege(a);
//            IPrivileges d = new SalaryBonusPrivilege(b);
//            d.AddPrivilege();
            //var salaryCalculator = new SalaryCalculator();
            //intern.Salary = salaryCalculator.Calculate(intern.Salary, new InternSalaryCalculator());
            return intern;
        }

        public void OnInternCreation(Intern intern)
        {
            _displayInfoAction.DisplayInfo(intern);
            //intern.DisplayAll();
        }
    }
}