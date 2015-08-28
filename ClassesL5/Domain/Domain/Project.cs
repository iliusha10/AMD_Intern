using System;

namespace Domain.Domain
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

        public virtual Company Company { get; protected set; }
        public virtual string ProjectName { get; protected set; }
        public virtual string ProjectDescription { get; protected set; }

        public new virtual string ToString()
        {
            return ProjectName;
        }

        [Obsolete]
        protected Project()
        {
        }

        public virtual void DisplayAll()
        {
            Console.WriteLine();
            Console.WriteLine("{1} {2}", ProjectName, ProjectDescription);
        }

        public virtual void AddTask(int taskid)
        {
            int taskId = taskid;
            Console.WriteLine("Added a task with {0} id number", taskId);
        }

        public virtual void AddTask(string tasksubj)
        {
            string taskSubj = tasksubj;
            Console.WriteLine("Added a task with subject: {0} ", taskSubj);
        }
    }
}