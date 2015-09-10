using System;
using Domain.Persons;

namespace Domain.CompanyAssets
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
        public virtual Contractor Contractor { get; protected set; }

        public override string ToString()
        {
            return string.Format("{0, -15} {1, -15} {2, -15}", TaskName, TaskDescription, Deadline);
        }

        public virtual void DisplayAll()
        {
            Console.WriteLine("{0} {1} {2} {3}", TaskName, TaskDescription, Deadline, Project);
        }

        public virtual void AddWorker(Contractor worker)
        {
            Contractor = worker;
        }

        
    }
}