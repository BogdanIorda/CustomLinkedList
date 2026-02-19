# Custom Linked List in C#

A console-based Task Manager built from scratch to understand how data structures and memory work in .NET. Instead of using the built-in `List<T>`, I made a custom singly linked list.

## What I Learned
* **Interfaces:** Using an `ITaskService` interface to separate the application's menu from the underlying logic.
* **Encapsulation:** Keeping the `Node` class and memory pointers (`head`, `tail`) private so they can't be accidentally modified from outside the class.
* **Memory Management:** Writing the pointer logic to bypass and remove a node, and learning how the .NET Garbage Collector automatically cleans up that unreferenced data.
* **Pointers:** Using a tail pointer to add new tasks instantly without looping through the entire list.
* **Pointers:** Using a tail pointer to add new tasks instantly without looping through the entire list.