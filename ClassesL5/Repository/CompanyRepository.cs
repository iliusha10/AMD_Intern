using System;
using System.Collections.Generic;
using Domain;
using Domain.Row;
using Domain.CompanyAssets;
using NHibernate.Transform;
using Repository.Interfaces;

namespace Repository
{
    public class CompanyRepository : Repository, ICompanyRepository
    {

        public void AddCompany(IEnumerable<Company> companyList)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    foreach (var company in companyList)
                    {
                        _session.SaveOrUpdate(company);
                    }
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

        public IList<CompanyName> GetAllCompanyNames()
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    CompanyName names = null;

                    var result = _session.QueryOver<Company>()
                        .SelectList(list => list
                            .Select(c => c.Id).WithAlias(() => names.Id)
                            .Select(c => c.CompanyName).WithAlias(() => names.CompanyNames))
                        .TransformUsing(Transformers.AliasToBean<CompanyName>())
                        .List<CompanyName>();
                    return result;

                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("ComapnyRepository | GetAllNames | {0}", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }

        public IList<CompanyAllInfo> GetCompanyAllInfo(long id)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    Address address = null;
                    Company company = null;
                    CompanyAllInfo all = null;

                    var result = _session.QueryOver(() => company)
                        .JoinAlias(()=> company.Address, ()=> address )
                        .Where(()=> company.Id == id)
                        .SelectList(list => list
                            .Select(() => company.Id).WithAlias(() => all.Id)
                            .Select(() => company.CompanyName).WithAlias(() => all.CompanyName)
                            .Select(()=> company.Activity).WithAlias(()=>all.Activity)
                            .Select(()=>address.City).WithAlias(()=>all.City)
                            .Select(()=>address.Street).WithAlias(()=>all.Street))
                        .TransformUsing(Transformers.AliasToBean<CompanyAllInfo>())
                        .List<CompanyAllInfo>();
                    return result;

                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("ComapnyRepository | GetCompanyAllInfo | {0}", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }
    }
}