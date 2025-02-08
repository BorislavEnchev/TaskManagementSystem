using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.DAL.Contexts;
using TaskManagementSystem.DAL.Repositories.Interfaces;

namespace TaskManagementSystem.DAL.Repositories
{
    public class TaskRepository : Repository<Models.Task>, ITaskRepository
    {
        private readonly TaskManagementContext _context;

        public TaskRepository(TaskManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Task>> GetTasksByStatusAsync(Enums.TaskStatus status)
        {
            return await _context.Tasks.Where(t => t.Status == status).ToListAsync();
        }
    }
}
