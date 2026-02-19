namespace Enterprise.TaskManager.Core
{
    public interface ITaskService
    {
        void AddTask(string description);

        void ShowAllTasks();

        void RemoveTask(string description);
    }
}