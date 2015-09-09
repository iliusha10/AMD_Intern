using Domain.CompanyAssets;
using Domain.Persons;

namespace Domain.Mapping
{
    public class AddressMap : EntityMap<Address>
    {
        #region Public members

        public AddressMap()
        {
            Map(x => x.City).Not.Nullable();
            Map(x => x.Street).Not.Nullable();
            HasOne(x => x.Person).PropertyRef(x => x.Id).Fetch.Join();
            HasOne(x => x.Company).PropertyRef(x => x.Id).Fetch.Join();
        }

        #endregion
    }
}