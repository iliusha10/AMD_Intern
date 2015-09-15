using Domain.CompanyAssets;
using Domain.Persons;

namespace Domain.Mapping
{
    public class CompanyMap : EntityMap<Company>
    {
        public CompanyMap()
        {
            References(x => x.Address).Cascade.SaveUpdate().Fetch.Join();
            Map(x => x.CompanyName).Not.Nullable();
            Map(x => x.Activity).Not.Nullable();
            HasMany(x => x.ProjectList).Cascade.All();
            HasMany(x => x.PersonList).Cascade.SaveUpdate();


        }
    }
}