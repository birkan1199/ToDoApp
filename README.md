# To-Do List App

A simple console-based To-Do List application developed with C#.

This project allows users to create, view, update, complete, and delete tasks. Tasks can also be saved to a text file and loaded again when the application starts.

## Features

- Add new tasks
- View all tasks
- Mark tasks as completed
- Update existing tasks
- Delete tasks
- Set a date for each task
- Set a priority for each task
- Save tasks to a text file
- Load saved tasks when the application starts

## Project Structure

The project contains two main classes:

### Program

The `Program` class contains the main application logic and menu system.

Methods used in the application:

- `AddTask()` - Adds a new task.
- `ViewTasks()` - Displays all tasks.
- `CompleteTask()` - Marks a selected task as completed.
- `UpdateTask()` - Updates the information of an existing task.
- `DeleteTask()` - Deletes a selected task.
- `SaveToFile()` - Saves all tasks to a text file.
- `LoadFromFile()` - Loads previously saved tasks from the text file.

### Gorev

The `Gorev` class represents a task.

Each task contains:

- `Id` - Unique task ID
- `Baslik` - Task title
- `Aciklama` - Task description
- `Tarih` - Task date
- `Oncelik` - Task priority
- `TamamlandiMi` - Completion status

## Data Storage

Tasks are stored in a `List<Gorev>` while the application is running.

```csharp
List<Gorev> gorevler = new List<Gorev>();
```

Tasks can be permanently saved to a `tasks.txt` file using `StreamWriter`.

When the application starts, previously saved tasks are loaded from `tasks.txt` using `StreamReader`.

Example stored task:

```text
1,Finish Homework,Complete the C# project,2026-09-25,High,False
```

The values represent:

```text
ID, Title, Description, Date, Priority, Completed
```

## Menu

```text
1. Add Task
2. View Tasks
3. Complete Task
4. Update Task
5. Delete Task
6. Save to File
7. Exit
```

## Technologies

- C#
- .NET
- Console Application
- Visual Studio
- File I/O
- LINQ
- List Collections

## Author

**Arda Birkan Berker**

GitHub: birkan1199
