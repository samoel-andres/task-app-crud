using TasksApp.Services;

namespace TasksApp.Controllers
{
    internal static class TaskController
    {
        internal static async Task ExecuteOption(int option)
        {
            var service = new TaskService();

            switch (option)
            {
                case 1:
                    Console.WriteLine();

                    await service.ShowTaskList();

                    Console.WriteLine();
                    break;
                case 2:
                    string title = "";
                    string description = "";

                    do
                    {
                        if (string.IsNullOrWhiteSpace(title))
                        {
                            Console.WriteLine("\nTask title:");
                            title = Console.ReadLine()!.ToLower().Trim();
                        }

                        if (string.IsNullOrWhiteSpace(description))
                        {
                            Console.WriteLine("\nTask description: ");
                            description = Console.ReadLine()!.ToLower().Trim();
                        }
                        
                    } while (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description));

                    Console.WriteLine();

                    await service.NewRecord(title, description);

                    Console.WriteLine();
                    break;
                case 3:
                    int id = -1;
                    string newTitle = "";
                    string newDescription = "";
                    bool newCompleted = false;

                    do
                    {
                        if (id == -1)
                        {
                            Console.WriteLine("\nTask ID:");
                            string value = Console.ReadLine()!.Trim();
                            if (int.TryParse(value, out int result))
                            {
                                id = result;
                            }
                        }

                        if (string.IsNullOrWhiteSpace(newTitle))
                        {
                            Console.WriteLine("\nNew title:");
                            newTitle = Console.ReadLine()!.ToLower().Trim();
                        }

                        if (string.IsNullOrWhiteSpace(newDescription))
                        {
                            Console.WriteLine("\nNew description:");
                            newDescription = Console.ReadLine()!.ToLower().Trim();
                        }

                        Console.WriteLine("\nDid you finish your task? (Y/N)");
                        string value2 = Console.ReadLine()!.ToLower().Trim();
                        if (value2 == "y")
                        {
                            newCompleted = true;
                        }
                        else
                        {
                            newCompleted = false;
                        }
                    } while (id == -1 || string.IsNullOrWhiteSpace(newTitle) || string.IsNullOrWhiteSpace(newDescription));

                    Console.WriteLine();

                    await service.UpdateRecord(id, newTitle, newDescription, newCompleted);

                    Console.WriteLine();
                    break;
                case 4:
                    int id2 = -1;

                    do
                    {
                        if (id2 == -1)
                        {
                            Console.WriteLine("\nTask ID to remove:");
                            string value3 = Console.ReadLine()!.Trim();
                            if (int.TryParse(value3, out int result))
                            {
                                id2 = result;
                            }
                        }
                    } while (id2 == -1);

                    Console.WriteLine();

                    await service.RemoveRecord(id2);

                    Console.WriteLine();
                    break;
                case 5:
                    Console.WriteLine("\nExiting...");
                    break;
                default:
                    Console.WriteLine("\nType a number between 1 and 5.\n");
                    break;
            }
        }
    }
}
