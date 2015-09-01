using System;
using System.Collections.Generic;
using Domain;
using Domain.Domain;
using Repository.Interfaces;

namespace Repository
{
    public class CompanyRepository : Repository, ICompanyRepository
    {

        public void AddCompany(Company company)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {

                    _session.SaveOrUpdate((company));
                    transaction.Commit();
                    Console.WriteLine("Inserting Company in DB Successfull ");
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("CompanyRepository | AddCompany | {0}", ex);
                    transaction.Rollback();
                }
            }
        }

        public void UpdateCompany(long id, string name = null, FieldOfActivity activity = FieldOfActivity.None)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    var company = _session.Load<Company>(id);
                    if (name != null)
                        company.Rename(name);

                    if (activity != FieldOfActivity.None)
                        company.ChangeFieldofActivity(activity);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("ComapnyRepository | UpdateCompany | {0}", ex);
                    transaction.Rollback();
                }
            }
        }

        public void DeleteCompany(long id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    var company = _session.Load<Company>(id);
                    _session.Delete(company);
                    transaction.Commit();
                    Console.WriteLine("Deleted company");
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("ComapnyRepository | DeleteCompany | {0}", ex);
                    transaction.Rollback();
                }
            }
        }
    }
}