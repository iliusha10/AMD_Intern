using System;
using System.Collections.Generic;

namespace Domain.CompanyAssets
{
    public class Project : Entity
    {
        public Project(Company company, string projectName, string decription)
        {
            //WorkerList = workerList;
            ProjectName = projectName;
            ProjectDescription = decription;
            Company = company;
            Logger.Logger.AddToLog("Creating new project");
            TaskList = new List<Task>();
        }

        [Obsolete]
        protected Project()
        {
        }

        public virtual Company Company { get; protected set; }
        public virtual string ProjectName { get; protected set; }
        public virtual string ProjectDescription { get; protected set; }
        public virtual IList<Task> TaskList { get; protected set; }

        public new virtual string ToString()
        {
            return ProjectName;
        }

        public virtual void DisplayAll()
        {
            Console.WriteLine();
            Console.WriteLine("{0} {1}", ProjectName, ProjectDescription);
        }

        public virtual void AddTask(Task task)
        {
            TaskList.Add(task);
        }
    }
}