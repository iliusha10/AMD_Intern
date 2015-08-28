using System;

namespace Domain.Domain
{
    public class Project
    {
        public Project(int projectId, string projectName, string decription)
        {
            //WorkerList = workerList;
            ProjectName = projectName;
            ProjectId = projectId;
            ProjectDescription = decription;
            Logger.Logger.AddToLog("Creating new project");
        }

        public override string ToString()
        {
            return ProjectName;
        }

        //public IEnumerable<Person> WorkerList;
        public int ProjectId { get; private set; }
        public string ProjectName { get; private set; }
        public string ProjectDescription { get; private set; }


        public void DisplayAll()
        {
            Console.WriteLine();
            Console.WriteLine("{0} {1} {2}", ProjectId, ProjectName, ProjectDescription);
        }

        public static void AddTask(int taskid)
        {
            int taskId = taskid;
            Console.WriteLine("Added a task with {0} id number", taskId);
        }

        public static void AddTask(string tasksubj)
        {
            string taskSubj = tasksubj;
            Console.WriteLine("Added a task with subject: {0} ", taskSubj);
        }
    }
}