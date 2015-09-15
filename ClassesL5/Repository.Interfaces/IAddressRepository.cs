using System.Collections.Generic;
using Domain.CompanyAssets;

namespace Repository.Interfaces
{
    public interface IAddressRepository : IRepository
    {
        void AddAddress(Address address);
        void UpdateAddress(Address oldaddress, Address newaddress);
        void DeleteAddress(long id);
        void CheckAdress(string street, string city);
        Address GetAddressById(long id);
    }
}