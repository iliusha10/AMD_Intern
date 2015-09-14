using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.CompanyAssets;
using Repository.Interfaces;

namespace Repository
{
    class AddressRepository: Repository, IAddressRepository
    {
        public void AddAddress(Address address)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.SaveOrUpdate(address);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("AddressRepository | AddAddress | {0}", ex);
                    transaction.Rollback();
                }
            }
        }

        public void UpdateAddress(long id, string street, string city)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    var address = _session.Load<Address>(id);
                    address.ChangeAddress(street, city);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("AddressRepository | UpdateAddress | {0}", ex);
                    transaction.Rollback();
                }
            }
        }

        public void DeleteAddress(long id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    var address = _session.Load<Address>(id);
                    _session.Delete(address);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Logger.Logger.AddToLog("AddressRepository | DeleteAddress | {0}", ex);
                    transaction.Rollback();
                }
            }
        }

        public void CheckAdress(string street, string city)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    //var address = _session.QueryOver<Address>()
                    //    .Where()
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }
    }
}
