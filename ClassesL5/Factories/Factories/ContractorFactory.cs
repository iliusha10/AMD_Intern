using System.Collections.Generic;
using Domain.Domain;
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

        public Contractor CreateContractor(string fname, string lname, string bdate, Company company, double workexp,
            double salary)
        {
            var contractor = new Contractor(fname, lname, bdate, company, workexp, salary);
            OnContractorCreation(contractor);
            return contractor;
        }

        public void OnContractorCreation(Contractor contractor)
        {
            _displayInfoAction.DisplayInfo(contractor);
            //contractor.DisplayAll();
        }
    }
}