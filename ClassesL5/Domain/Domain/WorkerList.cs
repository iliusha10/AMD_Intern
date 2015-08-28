using System.Collections.Generic;

namespace Domain.Domain
{
    public class WorkerList
    {
        public static List<Person> workerList = new List<Person>();

        public void AddWorker(Person p)
        {
            workerList.Add(p);
        }

        public void RemoveWorker()
        {
        }
    }
}