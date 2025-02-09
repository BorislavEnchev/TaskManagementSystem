using TaskManagementSystem.DAL.Repositories.Interfaces;
using TaskManagementSystem.BLL.Interfaces;

namespace TaskManagementSystem.BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task CreateTaskAsync(DAL.Models.Task task)
        {
            await _taskRepository.AddAsync(task);
            await _taskRepository.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(DAL.Models.Task task)
        {
            _taskRepository.Update(task);
            await _taskRepository.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);
            if (task != null)
            {
                _taskRepository.Delete(task);
                await _taskRepository.SaveChangesAsync();
            }
        }

        public async Task<DAL.Models.Task> GetTaskByIdAsync(int taskId)
        {
            return await _taskRepository.GetByIdAsync(taskId);
        }

        public async Task<IEnumerable<DAL.Models.Task>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllAsync();
        }

        public async Task<IEnumerable<DAL.Models.Task>> GetTasksByStatusAsync(DAL.Enums.TaskStatus status)
        {
            return await _taskRepository.GetTasksByStatusAsync(status);
        }

        public async Task<IEnumerable<DAL.Models.Task>> SearchTasksAsync(string searchText, DAL.Enums.TaskStatus? status)
        {
            var tasks = await _taskRepository.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                tasks = tasks.Where(t =>
                    t.Description.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                    (t.AssignedTo != null && t.AssignedTo.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                );
            }

            if (status.HasValue)
            {
                tasks = tasks.Where(t => t.Status == status.Value);
            }

            return tasks.ToList();
        }
    }
}
