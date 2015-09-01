using Domain.Domain;

namespace Domain.Mapping
{
    public class CompanyMap : EntityMap<Company>
    {
        public CompanyMap()
        {
            References(x => x.Person).Unique();
            Map(x => x.CompanyName).Not.Nullable();
            Map(x => x.Activity).Not.Nullable();
            Map(x => x.Address);
            HasMany(x => x.ProjectList).Cascade.All().Inverse().AsBag();
        }
    }
}