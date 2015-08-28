using Domain;
using Domain.Domain;
using InterfaceActions.Actions;

namespace Factories.Factories
{
    public class CompanyFactory
    {
        private readonly ICompany _displayInfoAction;

        public CompanyFactory(ICompany displayInfoAction)
        {
            _displayInfoAction = displayInfoAction;
        }

        public Company CreateCompany(int companyId, string name, FieldOfActivity activity, string street,
            string city)
        {
            var company = new Company(companyId, name, activity, street, city);
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