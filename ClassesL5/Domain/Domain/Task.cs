using System;

namespace Domain.Domain
{
    public class Task : Entity
    {
        public Task(Project project, string taskName, string taskDescription, string deadLine)
        {
            TaskName = taskName;
            TaskDescription = taskDescription;
            Deadline = DateTime.Parse(deadLine);
            Project = project;
        }

        [Obsolete]
        protected Task()
        {
        }

        public virtual string TaskName { get; protected set; }
        public virtual string TaskDescription { get; protected set; }
        public virtual DateTime Deadline { get; protected set; }
        public virtual Project Project { get; protected set; }
        public virtual Person Person { get; protected set; }
    }
}