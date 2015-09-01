using Domain.Domain;

namespace Domain.Mapping
{
    public class AddressMap : EntityMap<Address>
    {
        #region Public members

        public AddressMap()
        {
            References(x => x.Person).Unique();
            Map(x => x.City).Not.Nullable();
            Map(x => x.Street).Not.Nullable();
            //HasOne(x => x.Person).PropertyRef(x => x.Id);
            //Map(x => x.Person).Unique();
        }

        #endregion
    }
}