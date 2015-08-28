using System.Collections.Generic;
using Domain;
using Domain.Domain;

namespace Repository.Interfaces
{
    public interface ICompanyRepository : IRepository
    {
        void AddCompany(Company company);
        void UpdateCompany(long id, string name = null, FieldOfActivity activity = 0);
        void DeleteCompany(long id);
    }
}