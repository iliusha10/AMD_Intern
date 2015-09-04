using Domain.Persons;

namespace Domain.Mapping
{
    public class PersonMap : EntityMap<Person>
    {
        public PersonMap()
        {
            Map(x => x.FName).Not.Nullable();
            Map(x => x.LName).Not.Nullable();
            Map(x => x.DateOfBirth).Not.Nullable();
            HasMany(x => x.SkillsList).Cascade.All().Inverse();
            HasMany(x => x.PrivilegeList).Cascade.All();
            HasOne(x => x.Address).PropertyRef(x => x.Id).Fetch.Join();
            HasOne(x => x.Company).PropertyRef(x => x.Id).Fetch.Join();

        }
    }
}