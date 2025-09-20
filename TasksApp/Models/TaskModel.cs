namespace TasksApp.Models
{
    internal class TaskModel
    {
        internal required int Id { get; init; }
        internal required string Title { get; init; }
        internal required string Description { get; init; }
        internal required bool Completed { get; init; }
        internal required DateTime CreationDate { get; init; }
    }
}
