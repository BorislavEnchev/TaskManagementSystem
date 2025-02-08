using TaskManagementSystem.DAL.Models;

namespace TaskManagementSystem.DAL.Repositories.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsByTaskIdAsync(int taskId);
    }
}
