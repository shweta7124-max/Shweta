const int MaxTasks = 10;
List<string> tasks = new List<string>();
bool running = true;

while (running)
{
    DisplayMenu();

    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Please enter a valid number.");
        continue;
    }

    switch (choice)
    {
        case 1:
            AddNewTask(tasks);
            break;

        case 2:
            DisplayTasks(tasks);
            break;

        case 3:
            DeleteTask(tasks);
            break;

        case 4:
            DisplayTaskSummary(tasks);
            break;

        case 0:
            Console.WriteLine("Thank you for using Student Daily Planner!");
            running = false;
            break;

        default:
            Console.WriteLine("Invalid choice. Try again.");
            break;
    }
}

void DisplayMenu()
{
    Console.WriteLine("\nStudent Daily Planner");
    Console.WriteLine("---------------------");
    Console.WriteLine("1. Add a new task");
    Console.WriteLine("2. Display all tasks");
    Console.WriteLine("3. Delete a task");
    Console.WriteLine("4. View task summary");
    Console.WriteLine("0. Exit");
    Console.Write("Enter your choice: ");
}

void AddNewTask(List<string> taskList)
{
    if (taskList.Count >= MaxTasks)
    {
        Console.WriteLine("Task limit reached!");
        return;
    }

    Console.Write("Enter task description: ");
    string description = Console.ReadLine() ?? "";

    if (string.IsNullOrWhiteSpace(description))
    {
        Console.WriteLine("Task description cannot be empty.");
        return;
    }

    Console.WriteLine("Choose priority: 1. Low  2. Medium  3. High");
    Console.Write("Priority: ");

    if (!int.TryParse(Console.ReadLine(), out int priorityChoice)
        || priorityChoice < 1 || priorityChoice > 3)
    {
        Console.WriteLine("Invalid priority. Task was not added.");
        return;
    }

    TaskPriority priority = priorityChoice switch
    {
        1 => TaskPriority.Low,
        2 => TaskPriority.Medium,
        3 => TaskPriority.High,
        _ => TaskPriority.Medium
    };

    taskList.Add($"{description} - Priority: {priority}");
    Console.WriteLine("New task saved successfully!");
}

void DisplayTasks(List<string> taskList)
{
    if (taskList.Count == 0)
    {
        Console.WriteLine("Your planner is empty.");
        return;
    }

    Console.WriteLine("\nYour Daily Tasks:");

    for (int i = 0; i < taskList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {taskList[i]}");
    }
}

void DeleteTask(List<string> taskList)
{
    if (taskList.Count == 0)
    {
        Console.WriteLine("There are no tasks to delete.");
        return;
    }

    DisplayTasks(taskList);

    Console.Write("Enter task number to delete: ");

    if (int.TryParse(Console.ReadLine(), out int number)
        && number >= 1 && number <= taskList.Count)
    {
        taskList.RemoveAt(number - 1);
        Console.WriteLine("Task deleted successfully.");
    }
    else
    {
        Console.WriteLine("Invalid task number.");
    }
}

void DisplayTaskSummary(List<string> taskList)
{
    Console.WriteLine($"\nTotal tasks: {taskList.Count}");
    Console.WriteLine($"Maximum task limit: {MaxTasks}");
    Console.WriteLine($"Available spaces: {MaxTasks - taskList.Count}");
}

enum TaskPriority
{
    Low,
    Medium,
    High
}