using System.Collections.Generic;
using Domain;
using Domain.Company;
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

        public Company CreateCompany(string name, FieldOfActivity activity, string address,
            Dictionary<string, string> projectDictionary)
        {
            var company = new Company(name, activity, address, projectDictionary);
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