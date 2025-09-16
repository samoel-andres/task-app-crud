using DotNetEnv;
using TasksApp.Controllers;

namespace TasksApp
{
    internal class TasksApp
    {
        static async Task Main()
        {
            Env.Load();

            var option = 0;

            do
            {
                Console.WriteLine(
                "1. Show task list\n" +
                "2. Add task\n" +
                "3. Update task\n" +
                "4. Remove task\n" +
                "5. Exit\n"
                );

                string? value = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Please, choose an option from the list.\n");
                    continue;
                }

                if (!int.TryParse(value, out int newValue))
                {
                    Console.WriteLine("\nOption undefined...\n");
                    option = 0;
                    continue;
                }
                
                option = newValue;

                await TaskController.ExecuteOption(option);
            } while (option != 5);
            
        }
    }
}