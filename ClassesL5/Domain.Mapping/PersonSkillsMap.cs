using Domain.Company;

namespace Domain.Mapping
{
    public class PersonSkillsMap : EntityMap<PersonSkills>
    {
        #region Public members

        public PersonSkillsMap()
        {
            References(x => x.Person);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Level).Not.Nullable();
        }

        #endregion
    }
}