using System.Collections.Generic;
using Domain;
using Domain.CompanyAssets;
using InterfaceActions.Actions;

namespace Factories
{
    public class CompanyFactory
    {
        private readonly ICompany _displayInfoAction;

        public CompanyFactory(ICompany displayInfoAction)
        {
            _displayInfoAction = displayInfoAction;
        }

        public Company CreateCompany(string name, FieldOfActivity activity, Address address)
        {
            var company = new Company(name, activity, address);
            OnCompanyCreation(company);
            Logger.Logger.AddToLog("CompanyFactory|CreateCompany Company");
            return company;
        }

        public void OnCompanyCreation(Company company)
        {
            _displayInfoAction.ShowCpmpanyInfo(company);
        }
    }
}