using Domain.Domain;

namespace Domain.Mapping
{
    public class TaskMap : EntityMap<Task>
    {
        #region Public members

        public TaskMap()
        {
            References(x => x.Person);
            References(x => x.Project);
            Map(x => x.TaskName).Not.Nullable();
            Map(x => x.TaskDescription).Not.Nullable();
            Map(x => x.Deadline).Not.Nullable();
        }

        #endregion
    }
}