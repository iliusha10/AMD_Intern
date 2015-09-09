using Domain.CompanyAssets;
using InterfaceActions.Actions;

namespace Factories
{
    public class TaskFactory
    {
        private readonly ITask _displayInfoAction;

        public TaskFactory(ITask displayInfoAction)
        {
            _displayInfoAction = displayInfoAction;
        }

        public Task CreateTask(Project project, string taskName, string taskDescription, string deadLine)
        {
            var task = new Task(project, taskName, taskDescription, deadLine);
            Logger.Logger.AddToLog("TaskFactory|CreateTask Task");
            OnTaskCreation(task);
            return task;
        }

        public void OnTaskCreation(Task task)
        {
            _displayInfoAction.ShowTaskInfo(task);
        }
    }
}