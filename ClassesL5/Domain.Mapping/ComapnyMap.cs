namespace Domain.Mapping
{
    public class CompanyMap : EntityMap<Company.Company>
    {
        public CompanyMap()
        {
            References(x => x.Person);
            Map(x => x.CompanyName).Not.Nullable();
            Map(x => x.Activity).Not.Nullable();
            Map(x => x.Address);
            HasMany(x => x.ProjectList).Cascade.All().Inverse().AsBag();
        }
    }
}