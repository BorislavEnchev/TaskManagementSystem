namespace TaskManagementSystem.BLL.Interfaces
{
    public interface ITaskService
    {
        Task CreateTaskAsync(DAL.Models.Task task);
        Task UpdateTaskAsync(DAL.Models.Task task);
        Task DeleteTaskAsync(int taskId);
        Task<DAL.Models.Task> GetTaskByIdAsync(int taskId);
        Task<IEnumerable<DAL.Models.Task>> GetAllTasksAsync();
        Task<IEnumerable<DAL.Models.Task>> GetTasksByStatusAsync(DAL.Enums.TaskStatus status);
        Task<IEnumerable<DAL.Models.Task>> SearchTasksAsync(string searchText, DAL.Enums.TaskStatus? status);
    }
}
