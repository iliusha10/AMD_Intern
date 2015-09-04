using Domain.Company;

namespace Domain.Mapping
{
    public class ProjectMap : EntityMap<Project>
    {
        #region Public members

        public ProjectMap()
        {
            References(x => x.Company);
            Map(x => x.ProjectName).Not.Nullable();
            Map(x => x.ProjectDescription).Not.Nullable();
            HasMany(x => x.TaskList).Cascade.All().Inverse().AsBag();
        }

        #endregion
    }
}