using Domain.CompanyAssets;

namespace Domain.Mapping
{
    public class AddressMap : EntityMap<Address>
    {
        #region Public members

        public AddressMap()
        {
            Map(x => x.City).Not.Nullable();
            Map(x => x.Street).Not.Nullable();
            HasOne(x => x.Person); 
            HasOne(x => x.Company);
        }

        #endregion
    }
}