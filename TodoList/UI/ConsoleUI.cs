using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Entities;
using TodoList.Services;

namespace TodoList.UI
{
    class ConsoleUI
    {
        private readonly TodoService _service;

        public ConsoleUI(TodoService todoservice)
        {
            _service = todoservice;
        }

        public void Run()
        {
            Task.Run(() =>  SimulateDueTaskNotificationAsync());
            while (true)
            {

                Console.Clear();
                Console.WriteLine("==== TODO LIST MENU ====");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View All Tasks");
                Console.WriteLine("3. Search Task by Title");
                Console.WriteLine("4. View Tasks Due Today");
                Console.WriteLine("5. View Overdue Tasks");
                Console.WriteLine("6. Mark Task as Completed");
                Console.WriteLine("7. Delete Task");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ViewAllTasks();
                        break;
                    case "3":
                        SearchByTitle();
                        break;
                    case "4":
                        ViewDueToday();
                        break;
                    case "5":
                        ViewOverdue();
                        break;
                    case "6":
                        MarkCompleted();
                        break;
                    case "7":
                        DeleteTask();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void AddTask()
        {
            Console.Clear();
            Console.WriteLine("=== Add New Task ===");

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Due Date (yyyy-mm-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
            {
                Console.WriteLine("Invalid date format. Press Enter to return to menu.");
                Console.ReadLine();
                return;
            }

            Todo newTask = new Todo
            {
                Title = title,
                Description = description,
                DueDate = dueDate
            };

            try
            {
                _service.Add(newTask);
                Console.WriteLine("Task added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Press Enter to return to menu.");
            Console.ReadLine();
        }
        private void ViewAllTasks()
        {
            Console.Clear();
            Console.WriteLine("=== All Tasks ===");

            var tasks = _service.GetAll();

            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
            }
            else
            {
                foreach (var task in tasks)
                {
                    Console.WriteLine($"ID: {task.Id}");
                    Console.WriteLine($"Title: {task.Title}");
                    Console.WriteLine($"Description: {task.Description}");
                    Console.WriteLine($"Due Date: {task.DueDate:yyyy-MM-dd}");
                    Console.WriteLine($"Created At: {task.CreatedAt:yyyy-MM-dd HH:mm}");
                    Console.WriteLine($"Completed: {(task.IsCompleted ? "Yes" : "No")}");
                    Console.WriteLine(new string('-', 30));
                }
            }

            Console.WriteLine("Press Enter to return to menu.");
            Console.ReadLine();
        }
        private void SearchByTitle()
        {
            Console.Clear();
            Console.WriteLine("=== Search Task by Title ===");

            Console.Write("Enter title: ");
            string title = Console.ReadLine();

            try
            {
                var task = _service.SearchByTitle(title);

                Console.WriteLine($"\nID: {task.Id}");
                Console.WriteLine($"Title: {task.Title}");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine($"Due Date: {task.DueDate:yyyy-MM-dd}");
                Console.WriteLine($"Created At: {task.CreatedAt:yyyy-MM-dd HH:mm}");
                Console.WriteLine($"Completed: {(task.IsCompleted ? "Yes" : "No")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPress Enter to return to menu.");
            Console.ReadLine();
        }
        private void ViewDueToday()
        {
            Console.Clear();
            Console.WriteLine("=== Tasks Due Today ===");

            var tasks = _service.GetTasksDueToday();

            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks due today.");
            }
            else
            {
                foreach (var task in tasks)
                {
                    Console.WriteLine($"ID: {task.Id}");
                    Console.WriteLine($"Title: {task.Title}");
                    Console.WriteLine($"Due Date: {task.DueDate:yyyy-MM-dd}");
                    Console.WriteLine($"Completed: {(task.IsCompleted ? "Yes" : "No")}");
                    Console.WriteLine(new string('-', 30));
                }
            }

            Console.WriteLine("Press Enter to return to menu.");
            Console.ReadLine();
        }
        private void ViewOverdue()
        {
            Console.Clear();
            Console.WriteLine("=== Overdue Tasks ===");

            var tasks = _service.GetOverDueTasks();

            if (tasks.Count == 0)
            {
                Console.WriteLine("No overdue tasks.");
            }
            else
            {
                foreach (var task in tasks)
                {
                    Console.WriteLine($"ID: {task.Id}");
                    Console.WriteLine($"Title: {task.Title}");
                    Console.WriteLine($"Due Date: {task.DueDate:yyyy-MM-dd}");
                    Console.WriteLine($"Completed: {(task.IsCompleted ? "Yes" : "No")}");
                    Console.WriteLine(new string('-', 30));
                }
            }

            Console.WriteLine("Press Enter to return to menu.");
            Console.ReadLine();
        }
        private void MarkCompleted()
        {
            Console.Clear();
            Console.WriteLine("=== Mark Task as Completed ===");

            Console.Write("Enter Task ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID format.");
                Console.WriteLine("Press Enter to return to menu.");
                Console.ReadLine();
                return;
            }

            try
            {
                var task = _service.GetById(id);
                if (task.IsCompleted)
                {
                    Console.WriteLine("This task is already completed.");
                }
                else
                {
                    task.IsCompleted = true;
                    _service.Update(task);
                    Console.WriteLine("Task marked as completed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Press Enter to return to menu.");
            Console.ReadLine();
        }

        private void DeleteTask()
        {
            Console.Clear();
            Console.WriteLine("=== Delete Task ===");

            Console.Write("Enter Task ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID format.");
                Console.WriteLine("Press Enter to return to menu.");
                Console.ReadLine();
                return;
            }

            try
            {
                var task = _service.GetById(id); // Verifica que existe antes de borrar

                Console.WriteLine($"Are you sure you want to delete task '{task.Title}'? (y/n): ");
                string confirm = Console.ReadLine().ToLower();

                if (confirm == "y")
                {
                    _service.Delete(id);
                    Console.WriteLine("Task deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Deletion cancelled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Press Enter to return to menu.");
            Console.ReadLine();
        }
        private async Task SimulateDueTaskNotificationAsync()
        {
            await Task.Delay(1000); // Espera 10 segundos

            int currentPositionLeft = Console.GetCursorPosition().Left;
            int currentPositionTop = Console.GetCursorPosition().Top;
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            Console.SetCursorPosition(consoleWidth-100, consoleHeight-11);
            var overdueTasks = _service.GetOverDueTasks();
            var dueTodayTasks = _service.GetTasksDueToday();

            Console.WriteLine("\n\n=== Notification ===");

            if (dueTodayTasks.Any())
            {
                Console.WriteLine("⚠ You have tasks due today:");
                foreach (var task in dueTodayTasks)
                {
                    Console.WriteLine($"- {task.Title} (Due: {task.DueDate:yyyy-MM-dd})");
                }
            }

            if (overdueTasks.Any())
            {
                Console.WriteLine("\n⛔ You have overdue tasks:");
                foreach (var task in overdueTasks)
                {
                    Console.WriteLine($"- {task.Title} (Due: {task.DueDate:yyyy-MM-dd})");
                }
            }

            if (!dueTodayTasks.Any() && !overdueTasks.Any())
            {
                Console.WriteLine("✅ No tasks due or overdue.");
            }

            Console.WriteLine("\n=====================\n");
            
            Console.SetCursorPosition(currentPositionLeft, currentPositionTop);
        }


    }
}
