using Bl.SalaryCalculator;
using Domain.Domain;
using Domain.Interfaces;
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

        public Contractor CreateContractor(string fname, string lname, int bdate, int bmonth, int byear, double salary,
            Company company, double workexp)
        {
            var contractor = new Contractor(fname, lname, bdate, bmonth, byear, salary, company, workexp);
            Logger.Logger.AddToLog("ContractorFactory|CreateContractor Contractor");
            OnContractorCreation(contractor);
            IPrivileges a = contractor;
            IPrivileges b = new HollidayPrivilege(a);
            IPrivileges d = new SalaryBonusPrivilege(b);
            d.AddPrivilege();
            var salaryCalculator = new SalaryCalculator();
            contractor.Salary = salaryCalculator.Calculate(contractor.Salary, new ContractorSalaryCalculator());
            return contractor;
        }

        public void OnContractorCreation(Contractor contractor)
        {
            _displayInfoAction.DisplayInfo(contractor);
            //contractor.DisplayAll();
        }
    }
}