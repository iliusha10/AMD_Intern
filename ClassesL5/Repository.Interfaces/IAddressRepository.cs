using System.Collections.Generic;
using Domain.CompanyAssets;

namespace Repository.Interfaces
{
    public interface IAddressRepository : IRepository
    {
        void AddAddress(Address address);
        void UpdateAddress(Address currentAddress, string city, string street);
        void DeleteAddress(long id);
        //Address CheckAdress(string street, string city);
    }
}