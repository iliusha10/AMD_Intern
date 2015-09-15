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
            using (var _session = SessionGenerator.Instance.GetSession())
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

        public void UpdateCompany(Company oldcompany, Company newcompany)
        {
            using (var _session = SessionGenerator.Instance.GetSession())
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    //Company comp = null;
                    //Address addr = null;
                    //CompanyAllInfo row = null;

                    //var company = _session.QueryOver(() => comp)
                    //    .JoinAlias(() => comp.Address, () => addr)
                    //    .SelectList(list => list
                    //        .Select(() => comp.CompanyName).WithAlias(() => row.CompanyName)
                    //        .Select(() => comp.Activity).WithAlias(() => row.Activity)
                    //        .Select(() => addr.City).WithAlias(() => row.City)
                    //        .Select(() => addr.Street).WithAlias(() => row.Street))
                    //    .TransformUsing(Transformers.AliasToBean<CompanyAllInfo>())
                    //    .List<CompanyAllInfo>();

//                    company.ChangeData(company, name, activity, city, street);
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
            using (var _session = SessionGenerator.Instance.GetSession())
            using (var transaction = _session.BeginTransaction())
            {
                var comp = _session.Get<Company>(id);
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
            using (var _session = SessionGenerator.Instance.GetSession())
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

        public CompanyAllInfo GetCompanyAllInfo(long id)
        {
            using (var _session = SessionGenerator.Instance.GetSession())
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

        public Company GetCompanyById(long id)
        {
            using (var _session = SessionGenerator.Instance.GetSession())
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    var company = _session.Get<Company>(id);
                    return company;
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