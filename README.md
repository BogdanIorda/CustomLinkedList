Simple Task Manager (.NET)



This is a console application I built to learn how C# connects to a database. 



What it does

\- You can add tasks to a list.

\- You can view all your tasks.

\- You can delete tasks by typing their name.

\- All tasks are saved permanently in a local SQL database.



How it was built

Originally, I built this from scratch using a custom Linked List and saved the data to a `.json` text file to learn about memory and file storage. 



I have now upgraded the project to use Entity Framework (EF) Core and SQL Server to learn how professional applications store data. I used Interfaces (Dependency Injection) to swap out the old text-file engine for the new database engine without having to rewrite my user menu.



Tech Stack

\- C# / .NET 10 (Console App)

\- Entity Framework Core

\- SQL Server (LocalDB)



How to run it on your machine

1\. Open the project in Visual Studio.

2\. Go to Tools > NuGet Package Manager > Package Manager Console.

3\. Type `Update-Database` and hit Enter. (This will automatically build the SQL table on your computer).

4\. Press the Green Play button to start the app.

