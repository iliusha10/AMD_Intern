using System;
using System.Collections.Generic;

namespace Domain.Company
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
            Console.WriteLine("{1} {2}", ProjectName, ProjectDescription);
        }

        public virtual void AddTask(int taskid)
        {
            var taskId = taskid;
            Console.WriteLine("Added a task with {0} id number", taskId);
        }

        public virtual void AddTask(string tasksubj)
        {
            var taskSubj = tasksubj;
            Console.WriteLine("Added a task with subject: {0} ", taskSubj);
        }
    }
}