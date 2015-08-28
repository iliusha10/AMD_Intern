using Domain.Domain;

namespace Domain.Mapping
{
    public class PersonMap : EntityMap<Person>
    {
        public PersonMap()
        {
            Map(x => x.FName).Not.Nullable();
            Map(x => x.LName).Not.Nullable();
            Map(x => x._dateOfBirth);
            HasMany(x => x.SkillsList).Cascade.All().Inverse().AsBag();
        }
    }
}