using System.Threading.Tasks;
using InterfaceActions.Actions;

namespace ActionImplementation
{
    public class TaskInfo : ITask
    {


        public void ShowTaskInfo(Domain.CompanyAssets.Task task)
        {
            task.DisplayAll();
        }
    }
}