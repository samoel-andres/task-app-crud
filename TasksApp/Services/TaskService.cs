using TasksApp.Repositories;

namespace TasksApp.Services
{
    internal class TaskService
    {
        private readonly TaskRepository repo = new TaskRepository();

        internal async Task ShowTaskList()
        {
            var taskList = await repo.RetrieveTaskList();

            if (taskList.Count == 0)
            {
                Console.WriteLine("There are no tasks...");
                return;
            }

            Console.WriteLine($"[ {"ID".PadRight(4)}\t{"Title task".PadRight(20)}\t{"Description".PadRight(50)}\t{"Completed".PadRight(10)}\t{"Creation date".PadRight(18)} ]");
            foreach(var task in taskList)
            {
                Console.WriteLine($"[ {task.Id.ToString().PadRight(4)}\t{task.Title.PadRight(20)}\t{task.Description.PadRight(50)}\t{(task.Completed ? "y" : "n").PadRight(10) }\t{task.CreationDate.ToString().PadRight(18)} ]");
            }
        }
        
        internal async Task NewRecord(string title, string description)
        {
            var id = await repo.CreateNewRecord(title, description);

            if (id == -1)
            {
                Console.WriteLine("Record not saved...");
                return;
            }

            Console.WriteLine($"Record saved with ID: {id}...");
        }

        internal async Task UpdateRecord(int id, string title, string description, bool completed)
        {
            var updatedTask = await repo.UpdateRecord(id, title, description, completed);

            if (updatedTask == null)
            {
                Console.WriteLine("Record not updated...");
                return;
            }

            Console.WriteLine("ID\tTitle task\tDescription\tCompleted\tCreation date");
            Console.WriteLine($"[{updatedTask.Id}\t{updatedTask.Title}\t{updatedTask.Description}\t{(updatedTask.Completed ? "Y" : "N")}\t{updatedTask.CreationDate}]");
        }

        internal async Task RemoveRecord(int id)
        {
            bool removed = await repo.DeleteRecord(id);

            if (!removed)
            {
                Console.WriteLine("Record not removed...");
                return;
            }

            Console.WriteLine("Record removed...");
        }
    }
}
