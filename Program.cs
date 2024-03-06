// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

class Program
{
    static List<CustomTask> tasks = new List<CustomTask>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Task Tracker Menu:");
            Console.WriteLine("1. Add a Task");
            Console.WriteLine("2. View All Tasks");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        AddTask();
                        break;
                    case 2:
                        ViewTasks();
                        break;
                    case 3:
                        MarkTaskAsCompleted();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter task name: ");
        string name = Console.ReadLine();

        Console.Write("Enter task description: ");
        string description = Console.ReadLine();

        Console.Write("Enter due date (YYYY-MM-DD): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
        {
            CustomTask newTask = new CustomTask { Name = name, Description = description, DueDate = dueDate, IsCompleted = false };
            tasks.Add(newTask);

            Console.WriteLine("Task added successfully!");
        }
        else
        {
            Console.WriteLine("Invalid date format. Please use YYYY-MM-DD.");
        }
    }

    static void ViewTasks()
    {
        Console.WriteLine("All Tasks:");

        foreach (var task in tasks)
        {
            Console.WriteLine($"Name: {task.Name}");
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Due Date: {task.DueDate.ToShortDateString()}");
            Console.WriteLine($"Status: {(task.IsCompleted ? "Completed" : "Pending")}");
            Console.WriteLine();
        }
    }

    static void MarkTaskAsCompleted()
    {
        Console.Write("Enter the index of the task to mark as completed: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < tasks.Count)
        {
            tasks[index].IsCompleted = true;
            Console.WriteLine("Task marked as completed!");
        }
        else
        {
            Console.WriteLine("Invalid index. Please enter a valid index.");
        }
    }
}

class CustomTask
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
}
