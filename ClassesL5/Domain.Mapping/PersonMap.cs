using Domain.Domain;

namespace Domain.Mapping
{
    public class PersonMap : EntityMap<Person>
    {
        public PersonMap()
        {
            Map(x => x.FName).Not.Nullable();
            Map(x => x.LName).Not.Nullable();
            Map(x => x.DateOfBirth).Not.Nullable();
            HasMany(x => x.SkillsList).Cascade.All().Inverse().AsBag();
            //Map(x => x.PrivilegeList).Not.Nullable();
            //HasMany(x => x.Address).Unique().Not.Nullable();
            HasOne(x => x.Address).PropertyRef(x => x.Id).Fetch.Join();
            HasOne(x => x.Company).PropertyRef(x => x.Id).Fetch.Join();


            //HasMany()
        }
    }
}