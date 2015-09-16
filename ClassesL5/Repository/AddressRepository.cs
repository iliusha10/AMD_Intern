using System;
using Domain.CompanyAssets;
using Repository.Interfaces;

namespace Repository
{
    public class AddressRepository : Repository, IAddressRepository
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

        public void UpdateAddress(Address currentAddress, string city, string street)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    //var address = _session.Load<Address>(id);
                    currentAddress.ChangeAddress(street, city);
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

        //public Address CheckAdress(string street, string city)
        //{
        //    using (var tran = _session.BeginTransaction())
        //    {
        //        try
        //        {
        //            var address = _session.QueryOver<Address>()
        //                .Where(x => x.Street == street)
        //                .Where(x => x.City == city)
        //                .Select(x => x.Id)
        //                .SingleOrDefault<Address>();

        //            return address;
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        //}
    }
}