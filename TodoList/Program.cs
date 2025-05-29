using System;
using TodoList.Repository;
using TodoList.Services;
using TodoList.UI;

class Program
{
    public static void Main(string[] args)
    {
        ITodoRepository todoRepository = new JsonTaskRepository("Tasks.json");
        TodoService todoService = new TodoService(todoRepository);

        ConsoleUI ui = new ConsoleUI(todoService);
        ui.Run();

    }
}