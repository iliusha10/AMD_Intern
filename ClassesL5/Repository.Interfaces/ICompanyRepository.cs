﻿using System.Collections.Generic;
using Domain;
using Domain.CompanyAssets;
using Domain.Row;

namespace Repository.Interfaces
{
    public interface ICompanyRepository : IRepository
    {
        void AddCompany(IEnumerable<Company> companyList);
        void UpdateCompany(long id, string name = null, FieldOfActivity activity = 0);
        void DeleteCompany(long id);
        IList<CompanyName> GetAllCompanyNames();
        IList<CompanyAllInfo> GetCompanyAllInfo(long id);
    }
}