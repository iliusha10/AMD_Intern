using System.Collections.Generic;
using Domain;
using Domain.CompanyAssets;
using Domain.Row;

namespace Repository.Interfaces
{
    public interface ICompanyRepository : IRepository
    {
        void AddCompany(Company companyList);
        void UpdateCompany(Company oldcompany, Company newcompany);
        void DeleteCompany(long id);
        IList<CompanyName> GetAllCompanyNames();
        CompanyAllInfo GetCompanyAllInfo(long id);
        Company GetCompanyById(long id);
    }
}