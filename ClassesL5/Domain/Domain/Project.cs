using System;

namespace Domain.Domain
{
    internal class Project
    {
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