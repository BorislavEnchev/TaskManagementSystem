using TaskManagementSystem.DAL.Models;
using Task = System.Threading.Tasks.Task;

namespace TaskManagementSystem.BLL.Interfaces
{
    public interface ICommentService
    {
        Task AddCommentAsync(Comment comment);
        Task<int> AddCommentWithIdAsync(Comment comment);
        Task UpdateCommentAsync(Comment comment);
        Task DeleteCommentAsync(int commentId);
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task<IEnumerable<Comment>> GetAllCommentsAsync();
        Task<IEnumerable<Comment>> GetCommentsByTaskIdAsync(int taskId);
    }
}
