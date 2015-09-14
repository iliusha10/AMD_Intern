using System.Collections.Generic;
using Domain.CompanyAssets;

namespace Repository.Interfaces
{
    public interface IAddressRepository : IRepository
    {
        void AddAddress(Address address);
        void UpdateAddress(long id, string street, string city);
        void DeleteAddress(long id);
        void CheckAdress(string street, string city);
    }
}