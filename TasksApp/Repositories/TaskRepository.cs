using Microsoft.Data.SqlClient;
using TasksApp.Models;
using TasksApp.Config;

namespace TasksApp.Repositories
{
    internal class TaskRepository
    {
        internal async Task<List<TaskModel>> RetrieveTaskList()
        {
            var taskList = new List<TaskModel>();

            try
            {
                await using SqlConnection conn = DB.GetConnection();
                {
                    await conn.OpenAsync();

                    var query = "SELECT id, titulo, descripcion, completada, fechacreacion FROM tareas";

                    await using var cmd = new SqlCommand(query, conn);

                    await using var reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        var task = new TaskModel
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Title = reader.GetString(reader.GetOrdinal("titulo")),
                            Description = reader.GetString(reader.GetOrdinal("descripcion")),
                            Completed = reader.GetBoolean(reader.GetOrdinal("completada")),
                            CreationDate = reader.GetDateTime(reader.GetOrdinal("fechacreacion"))
                        };

                        taskList.Add(task);
                    }
                }

                return taskList;
            } catch (Exception e) {
                Console.WriteLine("Cannot retrieve tasks...\n" + e.Message);
                return taskList;
            }
        }

        
    }
}
