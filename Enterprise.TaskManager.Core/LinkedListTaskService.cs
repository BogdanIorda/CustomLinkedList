using System.Text.Json;

namespace Enterprise.TaskManager.Core
{
    public class LinkedListTaskService : ITaskService
    {
        private class Node
        {
            public string Description;
            public Node Next;

            public Node(string desc)
            {
                Description = desc;
                Next = null!;
            }
        }

        private Node? head;
        private Node? tail;

        public LinkedListTaskService()
        {
            LoadTasksFromFile();
        }

        public void AddTask(string description)

        {
            if (string.IsNullOrWhiteSpace(description)) return;

            var newNode = new Node(description);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail!.Next = newNode;
                tail = newNode;
            }
            SaveTasksToFile();
        }

        public void ShowAllTasks()
        {
            if (head == null)
            {
                Console.WriteLine("No tasks found.");
            }
            var current = head;

            while (current != null)
            {
                Console.WriteLine($"Task: {current.Description}");
                current = current.Next;
            }
        }

        public void RemoveTask(string description)
        {
            if (head == null)
            {
                return;
            }

            if (head.Description.Equals(description))
            {
                head = head.Next;

                if (head == null)
                {
                    tail = null;
                }
                SaveTasksToFile();
                return;
            }

            Node previous = head;
            Node current = head.Next;

            while (current != null)
            {
                if (current.Description.Equals(description, StringComparison.OrdinalIgnoreCase))
                {
                    previous.Next = current.Next;
                    if (current == tail)
                    {
                        tail = previous;
                    }
                    SaveTasksToFile();
                    return;
                }
                else
                {
                    previous = current;
                    current = current.Next;
                }
            }
        }

        private void SaveTasksToFile()
        {
            var taskDescriptions = new List<string>();
            var current = head;

            while (current != null)
            {
                taskDescriptions.Add(current.Description);
                current = current.Next;
            }
            string serializedTasks = JsonSerializer.Serialize(taskDescriptions);

            File.WriteAllText("tasks.json", serializedTasks);
        }

        private void LoadTasksFromFile()
        {
            if (!File.Exists("tasks.json")) return;

            var jsonContent = File.ReadAllText("tasks.json");

            var savedTasks = JsonSerializer.Deserialize<List<string>>(jsonContent);

            foreach (string task in savedTasks!)
            {
                AddTask(task);
            }
        }
    }
}