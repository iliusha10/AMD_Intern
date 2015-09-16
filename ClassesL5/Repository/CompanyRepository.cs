using System;
using System.Collections.Generic;
using System.Linq;
using Domain.CompanyAssets;
using Domain.Row;
using NHibernate.Transform;
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
                    _session.SaveOrUpdate(company);
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



        public void UpdateCompany(Company currentcompany, CompanyAllInfo newcompany)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    currentcompany.ChangeData(newcompany);
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
                var comp = _session.Load<Company>(id);
                _session.Delete(comp);

                //var queryString = string.Format("delete {0} where id = :id", typeof (Company));
                //session.CreateQuery(queryString)
                //    .SetParameter("id", id)
                //    .ExecuteUpdate();

                transaction.Commit();
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
                    Logger.Logger.AddToLog("ComapnyRepository | GetCompanyAllInfo | {0}", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }

        public IList<CompanyNameAndActivity> GetAllCompanyNamesAndActivity()
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    CompanyNameAndActivity dto = null;

                    var result = _session.QueryOver<Company>()
                        .SelectList(list => list
                            .Select(c => c.Id).WithAlias(() => dto.Id)
                            .Select(c => c.CompanyName).WithAlias(() => dto.CompanyNames)
                            .Select(c => c.Activity).WithAlias(() => dto.Activity))
                        .TransformUsing(Transformers.AliasToBean<CompanyNameAndActivity>())
                        .List<CompanyNameAndActivity>();
                    return result;
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("ComapnyRepository | GetAllCompanyNamesAndActivity | {0}", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }

        public CompanyAllInfo GetCompanyAllInfo(long id)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    Address address = null;
                    Company company = null;
                    CompanyAllInfo all = null;

                    var result = _session.QueryOver(() => company)
                        .JoinAlias(() => company.Address, () => address)
                        .Where(() => company.Id == id)
                        .SelectList(list => list
                            .Select(() => company.Id).WithAlias(() => all.Id)
                            .Select(() => company.CompanyName).WithAlias(() => all.CompanyName)
                            .Select(() => company.Activity).WithAlias(() => all.Activity)
                            .Select(() => company.Address.Id).WithAlias(() => all.AddressId)
                            .Select(() => address.City).WithAlias(() => all.City)
                            .Select(() => address.Street).WithAlias(() => all.Street))
                        .TransformUsing(Transformers.AliasToBean<CompanyAllInfo>())
                        .List<CompanyAllInfo>();
                    return result.FirstOrDefault();
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