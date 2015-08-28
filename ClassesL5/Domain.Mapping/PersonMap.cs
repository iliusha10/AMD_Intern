using Domain.Domain;
using FluentNHibernate.Conventions;

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
        }
    }
}