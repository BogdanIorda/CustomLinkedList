using Enterprise.TaskManager.Core;

ITaskService taskService = new LinkedListTaskService();

while (true)
{
    Console.Clear();

    Console.WriteLine("[1] Add Task");
    Console.WriteLine("[2] Show All Tasks");
    Console.WriteLine("[3] Remove Task");
    Console.WriteLine("[4] Exit Task");
    Console.WriteLine();

    string action = Console.ReadLine() ?? string.Empty;

    switch (action)
    {
        case "1":
            Console.Write("Enter task description: ");

            string task = Console.ReadLine() ?? string.Empty;
            taskService.AddTask(task);
            break;

        case "2":
            taskService.ShowAllTasks();
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
            break;

        case "3":
            Console.Write("Which task should be removed? ");
            string taskToRemove = Console.ReadLine() ?? string.Empty;
            taskService.RemoveTask(taskToRemove);
            break;

        case "4":
            return;

        default:
            Console.WriteLine("Invalid command");
            break;
    }
}