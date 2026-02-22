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

        public void AddTask(string description)

        {
            if (string.IsNullOrWhiteSpace(description)) return;

            var newNode = new Node(description);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
                return;
            }
            else
            {
                tail!.Next = newNode;
                tail = newNode;
            }
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
                    return;
                }
                else
                {
                    previous = current;
                    current = current.Next;
                }
            }
        }
    }
}