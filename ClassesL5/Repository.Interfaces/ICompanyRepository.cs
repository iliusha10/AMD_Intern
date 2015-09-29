using System.Collections.Generic;
using Domain;
using Domain.CompanyAssets;
using Domain.Row;

namespace Repository.Interfaces
{
    public interface ICompanyRepository : IRepository
    {
        void AddCompany(Company companyList);
        void UpdateCompany(Company currentcompany, CompanyAllInfo newcompany);
        void DeleteCompany(long id);
        IList<CompanyName> GetAllCompanyNames();
        IList<CompanyNameAndActivity> GetAllCompanyNamesAndActivity();
        CompanyAllInfo GetCompanyAllInfo(long id);
        IList<CompanyAllInfo> GetAllCompaniesAllInfo();
    }
}