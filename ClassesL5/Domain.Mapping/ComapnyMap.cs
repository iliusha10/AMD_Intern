using Domain.Domain;

namespace Domain.Mapping
{
    public class CompanyMap : EntityMap<Company>
    {
        public CompanyMap()
        {
            Map(x => x.CompanyName).Not.Nullable();
            Map(x => x.Activity).Not.Nullable();
            
            //HasMany(x=>x.)
            Map(x => x.Address);
            HasMany(x => x.ProjectList).Cascade.All().Inverse().AsBag();
        }
    }
}