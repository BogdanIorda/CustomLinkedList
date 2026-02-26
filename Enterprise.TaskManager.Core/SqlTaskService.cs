using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.TaskManager.Core
{
    public class SqlTaskService : ITaskService
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void AddTask(string description)
        {
            TaskItem task = new TaskItem();
            task.Description = description;

            _context.Tasks.Add(task);

            _context.SaveChanges();
        }

        public void RemoveTask(string description)
        {
            var taskToRemove = _context.Tasks.FirstOrDefault(t => t.Description == description);

            if (taskToRemove == null)
            {
                Console.WriteLine("Task not found");
                return;
            }
            _context.Tasks.Remove(taskToRemove);

            _context.SaveChanges();
        }

        public void ShowAllTasks()
        {
            var allTasks = _context.Tasks.ToList();

            if (allTasks.Count == 0)
            {
                Console.WriteLine("No tasks found in the database");
                return;
            }

            foreach (var task in allTasks)
            {
                Console.WriteLine($"Task {task.Id}: {task.Description}");
            }
        }
    }
}