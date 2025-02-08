namespace TaskManagementSystem.DAL.Repositories.Interfaces
{
    public interface ITaskRepository : IRepository<Models.Task>
    {
        Task<IEnumerable<Models.Task>> GetTasksByStatusAsync(Enums.TaskStatus status);
    }
}
